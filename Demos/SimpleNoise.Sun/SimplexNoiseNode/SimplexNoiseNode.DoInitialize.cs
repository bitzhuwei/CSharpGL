using System;
using System.Drawing;
using CSharpGL;

namespace SimpleNoise.Sun
{
    partial class SimplexNoiseNode
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.lastTime = DateTime.Now;
            this.RotateSpeed = 0.2f;

            var bitmap = new Bitmap(@"sunColor.png");
            var storage = new TexImage1D(0, GL.GL_RGBA, bitmap.Width, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap));
            var texture = new Texture(TextureTarget.Texture1D, storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR)
                );
            texture.Initialize();
            bitmap.Dispose();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("sunColor", texture);
        }
    }
}