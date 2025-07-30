using CSharpGL;
using demos.OpenGLviaCSharp;

namespace c11d00_Arcball {
    class FormBorderTextureSource : ITextureSource {
        private Texture texture;

        private Texture GetTexture() {
            string folder = System.Windows.Forms.Application.StartupPath;
            //var bmp = new Bitmap(System.IO.Path.Combine(folder, @"form-border.png"));
            var bmp = new Bitmap("media/textures/form-border.png");
            var winGLBitmap = new WinGLBitmap(bmp);
            TexStorageBase storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            return texture;
        }

        public FormBorderTextureSource() {
            this.texture = GetTexture();
        }

        #region ITextureSource 成员

        public Texture BindingTexture {
            get { return this.texture; }
        }

        #endregion
    }
}
