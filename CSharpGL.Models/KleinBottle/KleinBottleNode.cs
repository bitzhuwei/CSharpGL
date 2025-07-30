﻿using System.Drawing;
using System.IO;

namespace CSharpGL {
    /// <summary>
    /// Klein bottle.
    /// </summary>
    public partial class KleinBottleNode : PickableNode, IRenderable {
        public static KleinBottleNode Create(KleinBottleModel model) {
            var program = GLProgram.Create(vertexShaderCode, fragmentShaderCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", KleinBottleModel.strPosition);
            map.Add("inTexCoord", KleinBottleModel.strTexCoord);
            var builder = new RenderMethodBuilder(program, map, new LineWidthSwitch(3));
            var node = new KleinBottleNode(model, KleinBottleModel.strPosition, builder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private KleinBottleNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            //string folder = System.Windows.Forms.Application.StartupPath;
            //var bmp = new Bitmap(System.IO.Path.Combine(folder, @"KleinBottle\KleinBottle.png"));
            var bmp = new Bitmap(@"KleinBottle\KleinBottle.png");
            var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            var bmpGL = new GLBitmap(bmp.Width, bmp.Height, 4, data.Scan0);
            var texture = new Texture(new TexImage1D(GL.GL_RGBA, bmp.Width, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmpGL)));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.UnlockBits(data);
            bmp.Dispose();

            var method = this.RenderUnit.Methods[0];
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

            var method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("projectionMat", projection);
            program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}