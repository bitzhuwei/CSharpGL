using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 专为FrameBuffer服务的Texture类型。
    /// </summary>
    public class FramebufferTexture
    {
        private uint[] m_texture_id = new uint[1];
        /// <summary>
        /// 
        /// </summary>
        public uint TextureId { get { return m_texture_id[0]; } }

        /// <summary>
        /// 
        /// </summary>
        public uint TextureTarget { get; private set; }

        private uint m_internalfmt;
        private uint m_fmt;
        private bool m_mipmap;
        private bool m_interpol;

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalfmt"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="mipmap"></param>
        /// <param name="interpol"></param>
        public void setFormat(uint internalfmt, int width, int height, uint format,
            bool mipmap, bool interpol)
        {
            Width = width;
            Height = height;
            m_internalfmt = internalfmt;
            m_fmt = format;
            m_mipmap = mipmap;
            m_interpol = interpol;
            TextureTarget = OpenGL.GL_TEXTURE_2D;

            OpenGL.GenTextures(1, m_texture_id);
            OpenGL.BindTexture(TextureTarget, m_texture_id[0]);
            OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_CLAMP_TO_EDGE);
            OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_CLAMP_TO_EDGE);
            if (mipmap)
            {
                OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR_MIPMAP_LINEAR);
                OpenGL.TexParameterf(TextureTarget, OpenGL.GL_GENERATE_MIPMAP, OpenGL.GL_TRUE);
            }
            else
            {
                if (interpol)
                {
                    OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                    OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                }
                else
                {
                    OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_NEAREST);
                    OpenGL.TexParameterf(TextureTarget, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_NEAREST);
                }
                OpenGL.TexParameteri(TextureTarget, OpenGL.GL_GENERATE_MIPMAP, (int)OpenGL.GL_FALSE);
            }
            OpenGL.TexImage2D(TextureTarget, 0, internalfmt, width, height, 0,
                format, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            OpenGL.BindTexture(TextureTarget, 0);
        }

        internal void resize(int width, int height)
        {
            OpenGL.DeleteTextures(1, m_texture_id);
            setFormat(m_internalfmt, width, height, m_fmt, m_mipmap, m_interpol);
        }

    }
}
