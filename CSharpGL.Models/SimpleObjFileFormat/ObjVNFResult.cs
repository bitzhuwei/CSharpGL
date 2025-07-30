using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class ObjVNFResult {
        /// <summary>
        /// 
        /// </summary>
        public Exception Error { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public ObjVNFMesh Mesh { get; internal set; }
    }
}
