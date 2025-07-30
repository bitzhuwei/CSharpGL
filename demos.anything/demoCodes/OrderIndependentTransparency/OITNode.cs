﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace OrderIndependentTransparency {
    public partial class OITNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inNormal = "inNormal";
        private const string mvpMat = "mvpMat";

        const int buildLists = 0;
        const int resolveLists = 1;
        ///// <summary>
        ///// bind texture to an image unit.(which reminds me of texture unit)
        ///// </summary>
        //private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        //static OITNode() {
        //    glBindImageTexture = gl.glGetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
        //}

        public static OITNode Create(IBufferSource model, string position, string normal, vec3 size) {
            var builders = new RenderMethodBuilder[2];
            {
                var program = GLProgram.Create(buildListsVert, buildListsFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                map.Add(inNormal, normal);
                builders[buildLists] = new RenderMethodBuilder(program, map);
            }
            {
                var program = GLProgram.Create(resolveListsVert, resolveListsFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                builders[resolveLists] = new RenderMethodBuilder(program, map);
            }
            var node = new OITNode(model, position, builders);
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private OITNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

        private int canvasWidth = 0;
        private int canvasHeight = 0;
        private Texture headTexture;
        private PixelUnpackBuffer headClearBuffer;
        private AtomicCounterBuffer atomicCounterBuffer;
        private Texture linkedListTexture;
        private DepthTestSwitch depthTestState;
        private CullFaceSwitch cullFaceState;

        private void UpdateResources(int width, int height) {
            {
                if (this.headTexture != null) { this.headTexture.Dispose(); }

                uint internalformat = GL.GL_R32UI, format = GL.GL_RED_INTEGER, type = GL.GL_UNSIGNED_BYTE;
                TexStorageBase storage = new TexImage2D(TexImage2D.Target.Texture2D, internalformat, width, height, format, type);
                var texture = new Texture(storage,
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                    TexParameter.Create(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST)
                    );
                texture.Initialize();

                this.headTexture = texture;
            }
            // Create buffer for clearing the head pointer texture
            {
                if (this.headClearBuffer != null) { this.headClearBuffer.Dispose(); }

                int length = width * height;
                // NOTE: not all initial values are zero in this unmanged array.
                PixelUnpackBuffer buffer = PixelUnpackBuffer.Create(typeof(uint), length, GLBuffer.Usage.StaticDraw);
                // initialize buffer's value to 0.
                //unsafe
                //{
                //    IntPtr pointer = ptr.MapBuffer(MapBufferAccess.WriteOnly);
                //    var array = (uint*)pointer.ToPointer();
                //    for (int i = 0; i < MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT; i++)
                //    {
                //        array[i] = 0;
                //    }
                //}
                // another way to initialize buffer's value to 0.
                //using (var data = new UnmanagedArray<uint>(1))
                //{
                //    data[0] = 0;
                //    ptr.ClearBufferData(OpenGL.GL_UNSIGNED_INT, OpenGL.GL_RED, OpenGL.GL_UNSIGNED_INT, data);
                //}

                this.headClearBuffer = buffer;
            }
            // Bind it to a texture (for use as a TBO)
            {
                if (this.linkedListTexture != null) { this.linkedListTexture.Dispose(); }

                int length = width * height * 3;
                TextureBuffer buffer = TextureBuffer.Create(typeof(vec4), length, GLBuffer.Usage.DynamicCopy);
                uint internalFormat = GL.GL_RGBA32UI;
                Texture texture = buffer.DumpBufferTexture(internalFormat, autoDispose: true);
                texture.Initialize();
                buffer.Dispose();// dispose it ASAP.

                this.linkedListTexture = texture;
            }
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            // Create the atomic counter buffer
            {
                const int length = 1;
                AtomicCounterBuffer buffer = AtomicCounterBuffer.Create(typeof(uint), length, GLBuffer.Usage.DynamicCopy);
                // another way to do this:
                //uint data = 1;
                //AtomicCounterBuffer buffer = data.GenAtomicCounterBuffer(GLBuffer.BufferUsage.DynamicCopy);
                // Reset atomic counter
                IntPtr data = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe {
                    var array = (uint*)data.ToPointer();
                    array[0] = 0;
                }
                buffer.UnmapBuffer();

                this.atomicCounterBuffer = buffer;
            }

            {
                this.depthTestState = new DepthTestSwitch(false); // disable depth test.
                this.cullFaceState = new CullFaceSwitch(CullFaceMode.Back, false); // disable cull face.
            }
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            {
                int width = arg.Param.Viewport.width, height = arg.Param.Viewport.height;
                if (width != this.canvasWidth || height != this.canvasHeight) {
                    UpdateResources(width, height);
                    this.canvasWidth = width;
                    this.canvasHeight = height;
                }
            }
            {
                this.cullFaceState.On();
                this.depthTestState.On();
            }
            var gl = GL.Current; Debug.Assert(gl != null);
            {
                // Clear head-pointer image
                this.headClearBuffer.Bind();
                this.headTexture.Bind();
                int width = this.canvasWidth, height = this.canvasHeight;
                uint format = GL.GL_RED_INTEGER, type = GL.GL_UNSIGNED_BYTE;
                gl.glTexSubImage2D((uint)GL.GL_TEXTURE_2D, 0, 0, 0, width, height, format, type, IntPtr.Zero);
                this.headTexture.Unbind();
                this.headClearBuffer.Unbind();
            }
            uint imageUnit0 = 0, imageUnit1 = 1;
            {
                // Bind head-pointer image for read-write
                gl.glBindImageTexture(imageUnit0, this.headTexture.id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);
                // Bind linked-list buffer for write
                gl.glBindImageTexture(imageUnit1, this.linkedListTexture.id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);
            }
            {
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                {
                    // first pass
                    RenderMethod method = this.RenderUnit.Methods[buildLists];
                    GLProgram program = method.Program;
                    program.SetUniform(mvpMat, projection * view * model);
                    method.Render();
                }
                {
                    // second pass
                    RenderMethod method = this.RenderUnit.Methods[resolveLists];
                    GLProgram program = method.Program;
                    program.SetUniform(mvpMat, projection * view * model);
                    method.Render();
                }
            }
            {
                gl.glBindImageTexture(imageUnit1, 0, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);
                gl.glBindImageTexture(imageUnit0, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);
            }
            {
                this.cullFaceState.Off();
                this.depthTestState.Off();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
