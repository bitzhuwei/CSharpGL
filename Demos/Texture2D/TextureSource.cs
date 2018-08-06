using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Texture2D
{
    class TextureSource : ITextureSource
    {
        private readonly Texture texture;
        public TextureSource(string filename)
        {
            var bmp = new System.Drawing.Bitmap(filename);
            //bmp.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
            var storage = new TexImageBitmap(bmp);
            texture = new Texture(storage);
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();
            bmp.Dispose();
        }

        #region ITextureSource 成员

        public Texture BindingTexture { get { return texture; } }

        #endregion
    }
}
