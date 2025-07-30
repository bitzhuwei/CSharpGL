using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class GLTexture {
        private GLImage[]? images;

        /// <summary>
        /// 
        /// </summary>
        GLImage[]? Images { get { return this.images; } }
    }
}
