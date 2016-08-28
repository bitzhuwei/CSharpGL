using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public class NullImageBuilder : ImageBuilder
    {
        private int width;
        private int height;
        public NullImageBuilder(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public override void Build()
        {
            OpenGL.TexImage2D((uint)BindTextureTarget.Texture2D, 0, (int)OpenGL.GL_RGBA, width, height, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
        }
    }
}
