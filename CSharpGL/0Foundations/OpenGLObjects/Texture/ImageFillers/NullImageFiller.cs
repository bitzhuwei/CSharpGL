using System;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content with IntPtr.Zero.
    /// </summary>
    public class NullImageFiller : ImageFiller
    {
        private int width;
        private int height;
        private uint internalFormat;
        private uint format;
        private uint type;

        /// <summary>
        /// build texture's content with IntPtr.Zero.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        public NullImageFiller(int width, int height, uint internalFormat, uint format, uint type)
        {
            this.width = width;
            this.height = height;
            this.internalFormat = internalFormat;
            this.format = format;
            this.type = type;
        }

        /// <summary>
        ///
        /// </summary>
        public override void Fill(TextureTarget target)
        {
            OpenGL.TexImage2D((uint)TextureTarget.Texture2D, 0,
                internalFormat,// OpenGL.GL_RGBA,
                width, height, 0,
                this.format,// OpenGL.GL_RGBA,
                this.type,// OpenGL.GL_UNSIGNED_BYTE,
                IntPtr.Zero);
        }
    }
}