//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//namespace CSharpGL
//{
//    /// <summary>
//    /// Create, update and delete a framebuffer object.
//    /// </summary>
//    public partial class Framebuffer : IDisposable
//    {
//        private static readonly uint[] attachment_id =
//        {
//            OpenGL.GL_COLOR_ATTACHMENT0,
//            OpenGL.GL_COLOR_ATTACHMENT1,
//            OpenGL.GL_COLOR_ATTACHMENT2,
//            OpenGL.GL_COLOR_ATTACHMENT3,
//            OpenGL.GL_COLOR_ATTACHMENT4,
//            OpenGL.GL_COLOR_ATTACHMENT5,
//            OpenGL.GL_COLOR_ATTACHMENT6,
//            OpenGL.GL_COLOR_ATTACHMENT7,
//            OpenGL.GL_COLOR_ATTACHMENT8,
//            OpenGL.GL_COLOR_ATTACHMENT9,
//            OpenGL.GL_COLOR_ATTACHMENT10,
//            OpenGL.GL_COLOR_ATTACHMENT11,
//            OpenGL.GL_COLOR_ATTACHMENT12,
//            OpenGL.GL_COLOR_ATTACHMENT13,
//            OpenGL.GL_COLOR_ATTACHMENT14,
//            OpenGL.GL_COLOR_ATTACHMENT15,
//        };

//        private uint[] framebufferId = new uint[1];
//        /// <summary>
//        /// 
//        /// </summary>
//        public uint FramebufferId
//        {
//            get { return framebufferId[0]; }
//        }

//        private List<FramebufferTexture> m_color = new List<FramebufferTexture>();
//        private FramebufferTexture m_depth;
//        /// <summary>
//        /// 
//        /// </summary>
//        public int Width { get; private set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int Height { get; private set; }

//        private static OpenGL.glGenFramebuffersEXT glGenFramebuffers;
//        private static OpenGL.glBindFramebufferEXT glBindFramebuffer;
//        private static OpenGL.glFramebufferTexture2DEXT glFramebufferTexture2D;
//        private static OpenGL.glCheckFramebufferStatusEXT glCheckFramebufferStatus;
//        private static OpenGL.glDeleteFramebuffersEXT glDeleteFramebuffers;
//        private static OpenGL.glDrawBuffers glDrawBuffers;

//        private void InitFramebufferExtensions()
//        {
//            if (glGenFramebuffers == null)
//            {
//                glGenFramebuffers = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>();
//                glBindFramebuffer = OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>();
//                glFramebufferTexture2D = OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>();
//                glCheckFramebufferStatus = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>();
//                glDeleteFramebuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteFramebuffersEXT>();
//            }
//        }

//        private void setup(FramebufferTexture color0, bool depth)
//        {
//            this.Width = color0.Width;
//            this.Height = color0.Width;

//            /* Create render buffer object for depth buffering */
//            if (depth)
//            {
//                m_depth = new FramebufferTexture();
//                m_depth.setFormat(OpenGL.GL_DEPTH_COMPONENT24, this.Width, this.Height, OpenGL.GL_DEPTH_COMPONENT, false, false);
//            }
//            else
//            {
//                m_depth = null;
//            }

//            /* Create and bind new FBO */
//            glGenFramebuffers(1, framebufferId);
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);

//            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                attachment_id[m_color.Count], OpenGL.GL_TEXTURE_2D, color0.TextureId, 0);
//            m_color.Add(color0);

//            if (m_depth != null)
//            {
//                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                    OpenGL.GL_DEPTH_ATTACHMENT, OpenGL.GL_TEXTURE_2D, m_depth.TextureId, 0);
//            }

//            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);

//            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
//            {
//                throw new Exception("Failed to create frame buffer object!");
//            }

//            useAllAttachments();

//            /* Uibind FBO */
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="color"></param>
//        /// <param name="depth"></param>
//        public Framebuffer(List<FramebufferTexture> color, bool depth)
//        {
//            InitFramebufferExtensions();
//            setup(color[0], depth);
//            for (int i = 1; i < color.Count; ++i)
//            {
//                addColorAttachment(color[i]);
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="color0"></param>
//        /// <param name="depth"></param>
//        public Framebuffer(FramebufferTexture color0, bool depth)
//        {
//            InitFramebufferExtensions();
//            setup(color0, depth);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        /// <param name="depth"></param>
//        /// <param name="interpol"></param>
//        public Framebuffer(int width, int height, bool depth, bool interpol)
//        {
//            InitFramebufferExtensions();
//            var texture = new FramebufferTexture();
//            texture.setFormat(OpenGL.GL_RGBA16F, width, height, OpenGL.GL_RGBA, false, interpol);

//            setup(texture, depth);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="tex"></param>
//        public void addColorAttachment(FramebufferTexture tex)
//        {
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
//            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                attachment_id[m_color.Count], tex.TextureTarget, tex.TextureId, 0);
//            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

//            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
//            {
//                throw new Exception("Failed to attach extra color buffer!");
//            }

//            m_color.Add(tex);

//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
//            useAllAttachments();
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="internalfmt"></param>
//        /// <param name="format"></param>
//        /// <param name="mipmap"></param>
//        /// <param name="interpol"></param>
//        public void addColorAttachment(uint internalfmt, uint format, bool mipmap, bool interpol)
//        {
//            var texture = new FramebufferTexture();

//            texture.setFormat(internalfmt, this.Width, this.Height, format, mipmap, interpol);

//            addColorAttachment(texture);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="other"></param>
//        /// <param name="index"></param>
//        public void swapColorAttachment(Framebuffer other, int index)
//        {
//            FramebufferTexture tmp = m_color[index];
//            m_color[index] = other.m_color[index];
//            other.m_color[index] = tmp;

//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
//            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                attachment_id[index], m_color[index].TextureTarget, m_color[index].TextureId, 0);
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, other.framebufferId[0]);
//            glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                attachment_id[index], other.m_color[index].TextureTarget, other.m_color[index].TextureId, 0);
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);

//            ErrorCode error = (ErrorCode)OpenGL.GetError();
//            if (error != ErrorCode.NoError)
//            {
//                throw new Exception(string.Format("OpenGL Error: {0}", error));
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void useAllAttachments()
//        {
//            if (glDrawBuffers == null) { glDrawBuffers = OpenGL.GetDelegateFor<OpenGL.glDrawBuffers>(); }
//            glDrawBuffers(m_color.Count, attachment_id);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void bind()
//        {
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void release()
//        {
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="bits"></param>
//        public void clear(uint bits)
//        {
//            bind();
//            OpenGL.Clear(bits);
//            release();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void bindDraw()
//        {
//            glBindFramebuffer(OpenGL.GL_DRAW_FRAMEBUFFER, framebufferId[0]);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void releaseDraw()
//        {
//            glBindFramebuffer(OpenGL.GL_DRAW_FRAMEBUFFER, 0);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void bindRead()
//        {
//            glBindFramebuffer(OpenGL.GL_READ_FRAMEBUFFER, framebufferId[0]);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void releaseRead()
//        {
//            glBindFramebuffer(OpenGL.GL_READ_FRAMEBUFFER, 0);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="i"></param>
//        public FramebufferTexture color(int i)
//        {
//            return m_color[i];
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public FramebufferTexture depth() { return m_depth; }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        public void resize(int width, int height)
//        {
//            this.Width = width;
//            this.Height = height;
//            for (int i = 0; i < m_color.Count; ++i)
//            {
//                m_color[i].resize(this.Width, this.Height);
//            }

//            if (m_depth != null)
//            {
//                m_depth.resize(this.Width, this.Height);
//            }

//            // rebind the textures
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, framebufferId[0]);
//            for (int i = 0; i < m_color.Count; ++i)
//            {
//                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                   attachment_id[i], OpenGL.GL_TEXTURE_2D, m_color[i].TextureId, 0);
//            }
//            if (m_depth != null)
//            {
//                glFramebufferTexture2D(OpenGL.GL_FRAMEBUFFER,
//                   OpenGL.GL_DEPTH_ATTACHMENT, OpenGL.GL_TEXTURE_2D, m_depth.TextureId, 0);
//            }
//            // check status
//            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);
//            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
//            {
//                throw new Exception("Failed to create frame buffer object!");
//            }
//            glBindFramebuffer(OpenGL.GL_FRAMEBUFFER, 0);
//        }

//    }
//}
