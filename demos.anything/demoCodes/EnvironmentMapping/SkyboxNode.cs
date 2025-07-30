﻿using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EnvironmentMapping {
    class SkyboxNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string mvpMat = "mvpMat";
        private const string skybox = "skybox";
        private const string vertexCode = @"#version 330 core

layout(location = 0) in vec3 " + inPosition + @";

uniform mat4 " + mvpMat + @";

out vec3 passTexCoord;

void main()
{
    vec4 position = mvpMat * vec4(inPosition, 1.0); 
    gl_Position = position.xyww;
    passTexCoord = inPosition;
}
";
        private const string fragmentCode = @"#version 330 core

uniform samplerCube " + skybox + @";

in vec3 passTexCoord;

out vec4 color;

void main()
{
    color = texture(skybox, passTexCoord);
}
";
        private Texture texture;

        public Texture SkyboxTexture {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalBmp"></param>
        /// <returns></returns>
        public static SkyboxNode Create(Bitmap[] bitmaps) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, Skybox.strPosition);
            var cullface = new CullFaceSwitch(CullFaceMode.Back);// display back faces only.
            var builder = new RenderMethodBuilder(program, map, cullface);
            var model = new Skybox();
            var node = new SkyboxNode(model, Skybox.strPosition, bitmaps, builder);
            node.EnablePicking = TwoFlags.Children;// sky box should not take part in picking.
            node.Initialize();

            return node;
        }

        private SkyboxNode(Skybox model, string positionNameInIBufferSource, Bitmap[] bitmaps, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
            this.ModelSize = model.ModelSize;
            this.texture = GetCubemapTexture(bitmaps);
        }

        private Texture GetCubemapTexture(Bitmap[] bitmaps) {
            var winGLBitmaps = new WinGLBitmap[bitmaps.Length];
            for (int i = 0; i < bitmaps.Length; i++) {
                winGLBitmaps[i] = new WinGLBitmap(bitmaps[i]);
            }
            var dataProvider = new CubemapDataProvider(
                winGLBitmaps[0], winGLBitmaps[1], winGLBitmaps[2], winGLBitmaps[3], winGLBitmaps[4], winGLBitmaps[5]);
            var storage = new CubemapTexImage2D(GL.GL_RGBA, bitmaps[0].Width, bitmaps[0].Height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();

            return texture;
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

        public void RenderBeforeChildren(CSharpGL.RenderEventArgs arg) {
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform(mvpMat, projectionMat * viewMat * modelMat);
            program.SetUniform(skybox, this.texture);

            method.Render();
        }

        public void RenderAfterChildren(CSharpGL.RenderEventArgs arg) {
        }


        class Skybox : IBufferSource {
            public vec3 ModelSize { get; private set; }

            public Skybox() {
                this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
            }

            public const string strPosition = "position";
            private VertexBuffer positionBuffer;

            private IDrawCommand drawCmd;

            #region IBufferable 成员

            public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
                if (bufferName == strPosition) {
                    if (this.positionBuffer == null) {
                        this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                    }

                    yield return this.positionBuffer;
                }
                else {
                    throw new ArgumentException();
                }
            }

            public IEnumerable<IDrawCommand> GetDrawCommand() {
                if (this.drawCmd == null) {
                    this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Triangles, positions.Length);
                }

                yield return this.drawCmd;
            }

            #endregion

            private const float xLength = 1;
            private const float yLength = 1;
            private const float zLength = 1;
            /// <summary>
            /// six quads' vertexes.
            /// </summary>
            private static readonly vec3[] positions = new vec3[]
            {
                new vec3(-xLength,  yLength, -zLength),
                new vec3(-xLength, -yLength, -zLength),
                new vec3( xLength, -yLength, -zLength),
                new vec3( xLength, -yLength, -zLength),
                new vec3( xLength,  yLength, -zLength),
                new vec3(-xLength,  yLength, -zLength),

                new vec3(-xLength, -yLength,  zLength),
                new vec3(-xLength, -yLength, -zLength),
                new vec3(-xLength,  yLength, -zLength),
                new vec3(-xLength,  yLength, -zLength),
                new vec3(-xLength,  yLength,  zLength),
                new vec3(-xLength, -yLength,  zLength),

                new vec3( xLength, -yLength, -zLength),
                new vec3( xLength, -yLength,  zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3( xLength,  yLength, -zLength),
                new vec3( xLength, -yLength, -zLength),

                new vec3(-xLength, -yLength,  zLength),
                new vec3(-xLength,  yLength,  zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3( xLength, -yLength,  zLength),
                new vec3(-xLength, -yLength,  zLength),

                new vec3(-xLength,  yLength, -zLength),
                new vec3( xLength,  yLength, -zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3( xLength,  yLength,  zLength),
                new vec3(-xLength,  yLength,  zLength),
                new vec3(-xLength,  yLength, -zLength),

                new vec3(-xLength, -yLength, -zLength),
                new vec3(-xLength, -yLength,  zLength),
                new vec3( xLength, -yLength, -zLength),
                new vec3( xLength, -yLength, -zLength),
                new vec3(-xLength, -yLength,  zLength),
                new vec3( xLength, -yLength,  zLength),
            };

        }
    }
}