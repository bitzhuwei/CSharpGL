﻿using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Skybox {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalBmp"></param>
        /// <returns></returns>
        public static SkyboxNode Create(Bitmap totalBmp) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, Skybox.strPosition);
            var builder = new RenderMethodBuilder(program, map, new CullFaceSwitch(CullFaceMode.Front));
            var model = new Skybox();
            var node = new SkyboxNode(model, Skybox.strPosition, totalBmp, builder);
            node.Initialize();

            return node;
        }

        private SkyboxNode(Skybox model, string positionNameInIBufferSource, Bitmap totalBmp, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
            this.ModelSize = model.ModelSize;
            this.texture = GetCubemapTexture(totalBmp);
        }

        private Texture GetCubemapTexture(Bitmap totalBmp) {
            var dataProvider = GetCubemapDataProvider(totalBmp);
            TexStorageBase storage = new CubemapTexImage2D(GL.GL_RGBA, totalBmp.Width / 4, totalBmp.Height / 3, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();

            return texture;
        }

        private CubemapDataProvider GetCubemapDataProvider(Bitmap totalBmp) {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height * 2, width, height), GraphicsUnit.Pixel);
            }

            var flip = RotateFlipType.Rotate180FlipY;
            right.RotateFlip(flip); left.RotateFlip(flip);
            top.RotateFlip(flip); bottom.RotateFlip(RotateFlipType.Rotate180FlipX);
            back.RotateFlip(flip); front.RotateFlip(flip);
#if DEBUG
            right.Save("right.png"); left.Save("left.png");
            top.Save("top.png"); bottom.Save("bottom.png");
            back.Save("back.png"); front.Save("front.png");
#endif
            var winGLBitmapright = new WinGLBitmap(right, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var winGLBitmapleft = new WinGLBitmap(left, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var winGLBitmaptop = new WinGLBitmap(top, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var winGLBitmapbottom = new WinGLBitmap(bottom, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var winGLBitmapback = new WinGLBitmap(back, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var winGLBitmapfront = new WinGLBitmap(front, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var result = new CubemapDataProvider(winGLBitmapright, winGLBitmapleft,
                winGLBitmaptop, winGLBitmapbottom, winGLBitmapback, winGLBitmapfront);
            return result;
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
                    this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Quads, positions.Length);
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
                new vec3(-xLength, -yLength, +zLength),//  0
				new vec3(+xLength, -yLength, +zLength),//  1
				new vec3(+xLength, +yLength, +zLength),//  2
				new vec3(-xLength, +yLength, +zLength),//  3

				new vec3(+xLength, -yLength, +zLength),//  4
				new vec3(+xLength, -yLength, -zLength),//  5
				new vec3(+xLength, +yLength, -zLength),//  6
				new vec3(+xLength, +yLength, +zLength),//  7
				
				new vec3(-xLength, +yLength, +zLength),//  8
				new vec3(+xLength, +yLength, +zLength),//  9
				new vec3(+xLength, +yLength, -zLength),// 10
				new vec3(-xLength, +yLength, -zLength),// 11
				
				new vec3(+xLength, -yLength, -zLength),// 12
				new vec3(-xLength, -yLength, -zLength),// 13
				new vec3(-xLength, +yLength, -zLength),// 14
				new vec3(+xLength, +yLength, -zLength),// 15
				
				new vec3(-xLength, -yLength, -zLength),// 16
				new vec3(-xLength, -yLength, +zLength),// 17
				new vec3(-xLength, +yLength, +zLength),// 18
				new vec3(-xLength, +yLength, -zLength),// 19
				
				new vec3(+xLength, -yLength, -zLength),// 20
				new vec3(+xLength, -yLength, +zLength),// 21
				new vec3(-xLength, -yLength, +zLength),// 22
				new vec3(-xLength, -yLength, -zLength),// 23
			};

        }
    }
}