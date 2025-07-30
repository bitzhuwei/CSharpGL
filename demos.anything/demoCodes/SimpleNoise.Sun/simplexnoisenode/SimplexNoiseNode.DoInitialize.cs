using System;
using System.Drawing;
using CSharpGL;
using demos.anything;

namespace SimpleNoise.Sun {
    partial class SimplexNoiseNode {
        protected override void DoInitialize() {
            base.DoInitialize();

            this.lastTime = DateTime.Now;
            this.RotateSpeed = 0.2f;

            string folder = System.Windows.Forms.Application.StartupPath;
            //var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"sunColor.png"));
            var bitmap = new Bitmap("media/textures/sunColor.png");
            var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var storage = new TexImage1D(GL.GL_RGBA, bitmap.Width, GL.GL_BGRA,
                GL.GL_UNSIGNED_BYTE, new ImageDataProvider(winGLBitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR)
                );
            texture.Initialize();
            bitmap.Dispose();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("sunColor", texture);
        }
    }
}