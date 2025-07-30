﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;
using demos.anything;

namespace ImageProcessing.GrayFilter {
    partial class GrayFilterNode : PickableNode, IRenderable {
        public static GrayFilterNode Create() {
            var model = new GrayFilterModel();
            var program = GLProgram.Create(renderVert, renderFrag); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", GrayFilterModel.position);
            map.Add("inTexCoord", GrayFilterModel.texCoord);
            var builder = new RenderMethodBuilder(program, map);

            var node = new GrayFilterNode(model, GrayFilterModel.position, builder);
            node.Initialize();

            return node;
        }

        private GrayFilterNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            var bitmap = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bitmap)) {
                g.Clear(Color.Red);
                g.DrawString("CSharpGL", new Font("宋体", 18F), new SolidBrush(Color.Gold), new PointF(0, 40));
            }
            this.UpdateTexture(bitmap);
            bitmap.Dispose();
        }

        public void UpdateTexture(Bitmap bitmap) {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            TexStorageBase storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage);
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("tex", texture);
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

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }

    class GrayFilterModel : IBufferSource {
        public const string position = "positoin";
        private VertexBuffer positionBuffer;
        public const string texCoord = "texCoord";
        private VertexBuffer texCoordBuffer;

        private IDrawCommand drawCmd;

        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-1,  1, 0), new vec3( 1,  1, 0),
            new vec3(-1, -1, 0), new vec3( 1, -1, 0),
        };

        private static readonly vec2[] texCoords = new vec2[]
        {
            new vec2(0, 1), new vec2(1, 1),
            new vec2(0, 0), new vec2(1, 0),
        };

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == position) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == texCoord) {
                if (this.texCoordBuffer == null) {
                    this.texCoordBuffer = texCoords.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.QuadStrip, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
