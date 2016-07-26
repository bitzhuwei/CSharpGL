using System;
using System.Drawing.Imaging;

namespace CSharpGL
{
    class GLFontTexture : IDisposable
    {
        public readonly uint TextureID;
        public readonly int Width;
        public readonly int Height;

        public GLFontTexture(BitmapData dataSource)
        {
            Width = dataSource.Width;
            Height = dataSource.Height;

            OpenGL.Enable(OpenGL.GL_TEXTURE_2D);

            OpenGL.Hint(HintTarget.PerspectiveCorrection, HintMode.Nicest);

            var ids = new uint[1];
            OpenGL.GenTextures(1, ids);
            this.TextureID = ids[0];
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, TextureID);

            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);

            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA, Width, Height, 0,
                OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, dataSource.Scan0);

            OpenGL.Disable(OpenGL.GL_TEXTURE_2D);

            //TODO: tmp commented.
            //GLGui.usedTextures++;
        }

        public void Dispose()
        {
            OpenGL.DeleteTextures(1, new uint[] { this.TextureID });
            //TODO: tmp commented.
            //GLGui.usedTextures--;
        }

        ~GLFontTexture()
        {
            //TODO: tmp commented.
            //lock (GLGui.toDispose)
            //{
            //    GLGui.toDispose.Add(this);
            //}
        }
    }
}
