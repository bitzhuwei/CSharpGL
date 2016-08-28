using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ByteImageBuilder : ImageBuilder
    {
        private byte[] content;
        private int width;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        public ByteImageBuilder(byte[] content, int width)
        {
            this.content = content;
            this.width = width;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        public override void Build()
        {
            OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexImage1D((uint)BindTextureTarget.Texture1D, 0, OpenGL.GL_RGBA8, this.width, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, content);
        }
    }
}
