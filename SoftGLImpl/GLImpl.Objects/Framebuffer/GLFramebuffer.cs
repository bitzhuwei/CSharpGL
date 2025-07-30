using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class GLFramebuffer : IDisposable {

        //public readonly GLenum/*BindFramebufferTarget*/ Target;
        public readonly GLuint Id;

        public GLFramebuffer(/*GLenum target,*/ GLuint id) {
            //this.Target = target;
            this.Id = id;
        }

        /// <summary>
        /// glGet(GL_MAX_COLOR_ATTACHMENTS, ..);
        /// </summary>
        internal const int maxColorAttachments = 8;
        private IGLAttachable?[] colorbufferAttachments = new IGLAttachable[maxColorAttachments]; // OpenGL supports at least 8 color attachement points.

        #region for default framebuffer object only.

        public IGLAttachable? FrontLeft { get { return this.colorbufferAttachments[0]; } set { this.colorbufferAttachments[0] = value; } }

        public IGLAttachable? FrontRight { get { return this.colorbufferAttachments[1]; } set { this.colorbufferAttachments[1] = value; } }

        public IGLAttachable? BackLeft { get { return this.colorbufferAttachments[2]; } set { this.colorbufferAttachments[2] = value; } }

        public IGLAttachable? BackRight { get { return this.colorbufferAttachments[3]; } set { this.colorbufferAttachments[3] = value; } }

        #endregion for default framebuffer object only.

        public IGLAttachable?[] ColorbufferAttachments { get { return this.colorbufferAttachments; } }

        public IGLAttachable? DepthbufferAttachment { get; set; }

        public IGLAttachable? StencilbufferAttachment { get; set; }

        private List<uint> drawBuffers = new List<uint>();
        public IList<uint> DrawBuffers { get { return this.drawBuffers; } }

        public List<IGLAttachable?> GetCurrentColorBuffers() {
            var list = new List<IGLAttachable?>();
            foreach (var item in this.drawBuffers) {
                uint index = colorbuffer2index[item];
                var colorbuffer = this.colorbufferAttachments[index];
                list.Add(colorbuffer);
            }

            return list;
        }

        /// <summary>
        /// GL.XXX -> index
        /// </summary>
        private static readonly Dictionary<uint, uint> colorbuffer2index = new();
        static GLFramebuffer() {
            Dictionary<uint, uint> dict = colorbuffer2index;
            dict.Add(GL.GL_FRONT_LEFT, 0);
            dict.Add(GL.GL_FRONT_RIGHT, 1);
            dict.Add(GL.GL_BACK_LEFT, 2);
            dict.Add(GL.GL_BACK_RIGHT, 3);
            for (uint i = 0; i < maxColorAttachments; i++) {
                dict.Add(GL.GL_COLOR_ATTACHMENT0 + i, i);
            }
        }
    }

    static class DrawBufferHelper {
        public static uint ToIndex(this uint drawBuffer) {
            uint result = 0;
            if (GL.GL_FRONT_LEFT <= drawBuffer && drawBuffer <= GL.GL_BACK_RIGHT) { result = drawBuffer - GL.GL_FRONT_LEFT; }
            else if (GL.GL_COLOR_ATTACHMENT0 <= drawBuffer && drawBuffer < GL.GL_COLOR_ATTACHMENT0 + GLFramebuffer.maxColorAttachments) { result = drawBuffer - GL.GL_COLOR_ATTACHMENT0; }
            else { throw new ArgumentOutOfRangeException("drawBuffer"); }

            return result;
        }
    }
}
