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
            texture = new Texture(TextureTarget.Texture2D, new BitmapFiller(
                new System.Drawing.Bitmap(@"Crate.bmp"), 0, (int)GL.GL_RGBA, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, true),
                new SamplerParameters());
            texture.Initialize();
        }
        #region ITextureSource 成员

        public Texture BindingTexture { get { return texture; } }

        #endregion
    }
}
