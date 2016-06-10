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
        private uint m_texture_target;
        private int m_width;
        private int m_height;
        private uint m_internalfmt;
        private uint m_fmt;
        private bool m_mipmap;
        private bool m_interpol;

        public int width() { return m_width; }
        public int height() { return m_height; }

        public void setFormat(uint internalfmt, int width, int height, uint format,
            bool mipmap, bool interpol)
        {
            m_width = width;
            m_height = height;
            m_internalfmt = internalfmt;
            m_fmt = format;
            m_mipmap = mipmap;
            m_interpol = interpol;
            m_texture_target = OpenGL.GL_TEXTURE_2D;

            OpenGL.GenTextures(1, m_texture_id);
            OpenGL.BindTexture(m_texture_target, m_texture_id[0]);
            OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_CLAMP_TO_EDGE);
            OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_CLAMP_TO_EDGE);
            if (mipmap)
            {
                OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR_MIPMAP_LINEAR);
                OpenGL.TexParameterf(m_texture_target, OpenGL.GL_GENERATE_MIPMAP, OpenGL.GL_TRUE);
            }
            else
            {
                if (interpol)
                {
                    OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                    OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                }
                else
                {
                    OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_NEAREST);
                    OpenGL.TexParameterf(m_texture_target, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_NEAREST);
                }
                OpenGL.TexParameteri(m_texture_target, OpenGL.GL_GENERATE_MIPMAP, (int)OpenGL.GL_FALSE);
            }
            OpenGL.TexImage2D(m_texture_target, 0, internalfmt, width, height, 0,
                format, OpenGL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            OpenGL.BindTexture(m_texture_target, 0);
        }

        internal uint glID()
        {
            return m_texture_id[0];
        }

        internal void resize(int width, int height)
        {
            OpenGL.DeleteTextures(1, m_texture_id);
            setFormat(m_internalfmt, width, height, m_fmt, m_mipmap, m_interpol);
        }

        internal uint glTarget()
        {
            return m_texture_target;
        }
    }
}
