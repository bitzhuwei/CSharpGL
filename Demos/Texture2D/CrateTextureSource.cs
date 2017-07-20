using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL;

namespace Texture2D
{
    class CrateTextureSource : ITextureSource
    {
        private static readonly Texture texture;
        static CrateTextureSource()
        {
            var bmp = new System.Drawing.Bitmap(@"Crate.bmp");
            texture = new Texture(TextureTarget.Texture2D,
                new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, bmp.Width, bmp.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new BitmapDataProvider(bmp)));
            texture.BuiltInSampler.Add(new TexParameteri(GL.GL_TEXTURE_WRAP_S, "GL_TEXTURE_WRAP_S", (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(GL.GL_TEXTURE_WRAP_T, "GL_TEXTURE_WRAP_T", (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(GL.GL_TEXTURE_WRAP_R, "GL_TEXTURE_WRAP_R", (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(GL.GL_TEXTURE_MIN_FILTER, "GL_TEXTURE_MIN_FILTER", (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(GL.GL_TEXTURE_MAG_FILTER, "GL_TEXTURE_MAG_FILTER", (int)GL.GL_LINEAR));

            texture.Initialize();
            bmp.Dispose();
        }
        #region ITextureSource 成员

        public Texture BindingTexture { get { return texture; } }

        #endregion
    }
}
