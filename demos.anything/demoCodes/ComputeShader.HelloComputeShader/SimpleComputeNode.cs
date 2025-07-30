using CSharpGL;
using System;
using System.Diagnostics;
using System.IO;

namespace ComputeShader.HelloComputeShader {
    partial class SimpleComputeNode : ModernNode, IRenderable {
        private Texture outputTexture;

        //private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        //private static readonly GLDelegates.void_uint_uint_uint glDispatchCompute;
        //static SimpleComputeNode() {
        //    glBindImageTexture = gl.glGetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
        //    glDispatchCompute = gl.glGetDelegateFor("glDispatchCompute", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SimpleComputeNode Create() {
            var model = new SimpleCompute();
            RenderMethodBuilder compute, render;
            {
                var program = GLProgram.Create((computeShader, Shader.Kind.comp)); Debug.Assert(program != null);
                var map = new AttributeMap();
                compute = new RenderMethodBuilder(program, map);
            }
            {
                var program = GLProgram.Create(renderVert, renderFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("position", SimpleCompute.strPosition);
                render = new RenderMethodBuilder(program, map);
            }

            var node = new SimpleComputeNode(model, compute, render);
            node.Initialize();

            return node;
        }

        private SimpleComputeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        protected override void DoInitialize() {
            base.DoInitialize();
            {
                this.GroupX = 1;
                this.GroupY = 1;
                this.GroupZ = 1;
            }
            {
                // This is the texture that the compute program will write into
                var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, GL.GL_RGBA32F, 256, 256, 8);
                var texture = new Texture(storage);
                texture.Initialize();
                this.outputTexture = texture;
            }
            {
                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("outImage", this.outputTexture);
            }
        }

        private uint maxX;
        private uint maxY;
        private uint maxZ;
        private uint groupX;

        public uint GroupX {
            get { return groupX; }
            set { groupX = value; if (maxX < value) { maxX = value; } }
        }

        private uint groupY;

        public uint GroupY {
            get { return groupY; }
            set { groupY = value; if (maxY < value) { maxY = value; } }
        }

        private uint groupZ;

        public uint GroupZ {
            get { return groupZ; }
            set { groupZ = value; if (maxZ < value) { maxZ = value; } }
        }

        protected override void DisposeUnmanagedResources() {
            this.outputTexture.Dispose();

            base.DisposeUnmanagedResources();
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
            var gl = GL.Current; Debug.Assert(gl != null);

            // reset image
            {
                // Activate the compute program and bind the output texture image
                RenderMethod method = this.RenderUnit.Methods[0];
                GLProgram program = method.Program;
                program.SetUniform("reset", true);
                program.Bind();
                program.PushUniforms();
                uint imageUnit = 0;
                gl.glBindImageTexture(imageUnit, outputTexture.id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
                gl.glDispatchCompute(maxX, maxY, maxZ);
                program.Unbind();
            }
            //{
            //    var image = this.outputTexture.GetImage(256, 256);
            //    image.Save("x0.png");
            //}
            {
                // Activate the compute program and bind the output texture image
                RenderMethod method = this.RenderUnit.Methods[0];
                GLProgram program = method.Program;
                program.SetUniform("reset", false);
                program.Bind();
                program.PushUniforms();
                uint imageUnit = 0;
                gl.glBindImageTexture(imageUnit, outputTexture.id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
                gl.glDispatchCompute(GroupX, GroupY, GroupZ);
                program.Unbind();
            }
            {
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = mat4.identity();

                RenderMethod method = this.RenderUnit.Methods[1];
                GLProgram program = method.Program;
                program.SetUniform("projectionMat", projection);
                program.SetUniform("viewMat", view);
                program.SetUniform("modelMat", model);
                program.SetUniform("outImage", this.outputTexture);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}