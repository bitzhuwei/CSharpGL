using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// Bind a <see cref="GLSampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
    /// </summary>
    partial class GLSampler : List<SamplerParameter> {
        public uint Id { get; private set; }

        internal bool deleteFlag = false;
        public GLSampler(uint id) { this.Id = id; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Sampler: Id:{0}", this.Id);
        }
    }
}
