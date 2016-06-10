using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class FrameBuffer
    {
        private static readonly uint[] attachment_id =
        {
			OpenGL.GL_COLOR_ATTACHMENT0_EXT,
			OpenGL.GL_COLOR_ATTACHMENT1_EXT,
			OpenGL.GL_COLOR_ATTACHMENT2_EXT,
			OpenGL.GL_COLOR_ATTACHMENT3_EXT,
			OpenGL.GL_COLOR_ATTACHMENT4_EXT,
			OpenGL.GL_COLOR_ATTACHMENT5_EXT,
			OpenGL.GL_COLOR_ATTACHMENT6_EXT,
			OpenGL.GL_COLOR_ATTACHMENT7_EXT,
			OpenGL.GL_COLOR_ATTACHMENT8_EXT,
			OpenGL.GL_COLOR_ATTACHMENT9_EXT,
			OpenGL.GL_COLOR_ATTACHMENT10_EXT,
			OpenGL.GL_COLOR_ATTACHMENT11_EXT,
			OpenGL.GL_COLOR_ATTACHMENT12_EXT,
			OpenGL.GL_COLOR_ATTACHMENT13_EXT,
			OpenGL.GL_COLOR_ATTACHMENT14_EXT,
			OpenGL.GL_COLOR_ATTACHMENT15_EXT,
        };

        private uint[] m_fbo = new uint[1];
        private List<Texture> m_color;
        private Texture m_depth;
        private int m_width;
        private int m_height;

        private void setup(Texture color0, bool depth)
        {
            m_width = color0.width();
            m_height = color0.height();

            /* Create render buffer object for depth buffering */
            if (depth)
            {
                m_depth = new Texture();
                m_depth.setFormat(OpenGL.GL_DEPTH_COMPONENT24, m_width, m_height, OpenGL.GL_DEPTH_COMPONENT, false, false);
            }
            else
            {
                m_depth = null;
            }

            /* Create and bind new FBO */
            OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>()(1, m_fbo);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);

            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                attachment_id[m_color.Count], OpenGL.GL_TEXTURE_2D, color0.glID(), 0);
            m_color.Add(color0);

            if (m_depth != null)
            {
                OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                    OpenGL.GL_DEPTH_ATTACHMENT_EXT, OpenGL.GL_TEXTURE_2D, m_depth.glID(), 0);
            }

            uint result = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(OpenGL.GL_FRAMEBUFFER_EXT);

            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                throw new Exception("Failed to create frame buffer object!");
            }

            useAllAttachments();

            /* Uibind FBO */
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);
        }

        public FrameBuffer(List<Texture> color, bool depth)
        {
            setup(color[0], depth);
            for (int i = 1; i < color.Count; ++i)
            {
                addColorAttachment(color[i]);
            }
        }

        public FrameBuffer(Texture color0, bool depth)
        {
            setup(color0, depth);
        }
        public FrameBuffer(int width, int height, bool depth, bool interpol)
        {
            Texture texture = new Texture();
            texture.setFormat(OpenGL.GL_RGBA16F, width, height, OpenGL.GL_RGBA, false, interpol);

            setup(texture, depth);
        }

        public void addColorAttachment(Texture tex)
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                attachment_id[m_color.Count], tex.glTarget(), tex.glID(), 0);
            uint result = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(OpenGL.GL_FRAMEBUFFER_EXT);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                throw new Exception("Failed to attach extra color buffer!");
            }

            m_color.Add(tex);

            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);
            useAllAttachments();
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);
        }

        public void addColorAttachment(uint internalfmt, uint format, bool mipmap, bool interpol)
        {
            Texture texture = new Texture();

            texture.setFormat(internalfmt, m_width, m_height, format, mipmap, interpol);

            addColorAttachment(texture);
        }

        public void swapColorAttachment(FrameBuffer other, int index)
        {
            Texture tmp = m_color[index];
            m_color[index] = other.m_color[index];
            other.m_color[index] = tmp;

            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                attachment_id[index], m_color[index].glTarget(), m_color[index].glID(), 0);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,other. m_fbo[0]);
            OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                attachment_id[index], other.m_color[index].glTarget(), other.m_color[index].glID(), 0);
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);

            ErrorCode error = (ErrorCode)OpenGL.GetError();
            if (error != ErrorCode.NoError)
            {
                throw new Exception(string.Format("OpenGL Error: {0}", error));
            }
        }

        public void useAllAttachments()
        {
            OpenGL.GetDelegateFor<OpenGL.glDrawBuffers>()(m_color.Count, attachment_id);
        }

        public void bind()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);
        }
        public void release()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);
        }

        public void clear(uint bits)
        {
            bind();
            OpenGL.Clear(bits);
            release();
        }

        public void bindDraw()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_DRAW_FRAMEBUFFER, m_fbo[0]);
        }
        public void releaseDraw()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_DRAW_FRAMEBUFFER, 0);
        }

        public void bindRead()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_READ_FRAMEBUFFER, m_fbo[0]);
        }
        public void releaseRead()
        {
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_READ_FRAMEBUFFER, 0);
        }

        public Texture color(int i)
        {
            return m_color[i];
        }

        public Texture depth() { return m_depth; }

        public void resize(int width, int height)
        {
            m_width = width;
            m_height = height;
            for (int i = 0; i < m_color.Count; ++i)
            {
                m_color[i].resize(m_width, m_height);
            }

            if (m_depth != null)
            {
                m_depth.resize(m_width, m_height);
            }

            // rebind the textures
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, m_fbo[0]);
            for (int i = 0; i < m_color.Count; ++i)
            {
                OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                   attachment_id[i], OpenGL.GL_TEXTURE_2D, m_color[i].glID(), 0);
            }
            if (m_depth != null)
            {
                OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>()(OpenGL.GL_FRAMEBUFFER_EXT,
                   OpenGL.GL_DEPTH_ATTACHMENT_EXT, OpenGL.GL_TEXTURE_2D, m_depth.glID(), 0);
            }
            // check status
            uint result = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(OpenGL.GL_FRAMEBUFFER_EXT);
            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                throw new Exception("Failed to create frame buffer object!");
            }
            OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>()(OpenGL.GL_FRAMEBUFFER_EXT, 0);
        }

        public uint glID() { return m_fbo[0]; }
        public int width() { return m_width; }
        public int height() { return m_height; }
    }
}
