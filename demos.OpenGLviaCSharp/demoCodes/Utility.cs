using CSharpGL;
using System.Drawing.Imaging;

namespace demos.OpenGLviaCSharp {
    internal static class Utility {

        //public static (GLBitmap glBMP, BitmapData bmpData) LockConvert(Bitmap bmp, GLuint internalFormat) {
        //    var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        //    // TODO: decide pixelBytes according to bmp.PixelFormat
        //    if (!GLBitmap.internalFormat2Bytes.TryGetValue(GL.GL_RGBA, out var pixelBytes)) { pixelBytes = 4; }
        //    var glBMP = new GLBitmap(bmp.Width, bmp.Height, pixelBytes, bmpData.Scan0);

        //    return (glBMP, bmpData);
        //}

        public static Texture LoadTexture1D(string filename) {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, filename));
            var winGLBitmap = new WinGLBitmap(bmp);
            //var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            if (!GLBitmap.internalFormat2Bytes.TryGetValue(GL.GL_RGBA, out var pixelBytes)) { pixelBytes = 4; }
            //var glBMP = new GLBitmap(bmp.Width, bmp.Height, pixelBytes, bmpData.Scan0);
            TexStorageBase storage = new TexImage1D(GL.GL_RGBA, bmp.Width, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                new ImageDataProvider(winGLBitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            //bmp.UnlockBits(bmpData);
            winGLBitmap.Dispose();

            return texture;

        }
        public static Texture LoadTexture2D(string filename) {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, filename));
            var winGLBitmap = new WinGLBitmap(bmp);
            //var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            if (!GLBitmap.internalFormat2Bytes.TryGetValue(GL.GL_RGBA, out var pixelBytes)) { pixelBytes = 4; }
            //var glBMP = new GLBitmap(bmp.Width, bmp.Height, pixelBytes, bmpData.Scan0);
            TexStorageBase storage = new TexImageBitmap(winGLBitmap, GL.GL_RGBA, 1, true);
            var texture = new Texture(storage,
                new TexParameterfv(TexParameter.PropertyName.TextureBorderColor, 1, 0, 0),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            //bmp.UnlockBits(bmpData);
            winGLBitmap.Dispose();

            return texture;
        }
    }
}