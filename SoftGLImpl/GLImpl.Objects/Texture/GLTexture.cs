using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// Bind a <see cref="GLSampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
    /// </summary>
    internal partial class GLTexture {
        internal GLenum Target { get; private set; }

        internal GLuint Id { get; private set; }

        internal bool deleteFlag = false;

        public GLTexture(GLenum target, GLuint id) {
            this.Target = target;
            this.Id = id;

            this.InitParameters(); // TODO: Is this needed?
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Texture: Id:{0}, T:{1}", this.Id, this.Target);
        }
    }
}
