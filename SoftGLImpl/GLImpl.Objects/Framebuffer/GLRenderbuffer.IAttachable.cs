using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class GLRenderbuffer {
        #region IAttachable

        public uint Format { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// byte*
        /// </summary>
        public IntPtr DataStore { get; private set; }

        /// <summary>
        /// how many bytes in <see cref="DataStore"/>
        /// </summary>
        public int Size { get; private set; }

        #endregion IAttachable
    }
}
