using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftGLImpl {
    public abstract partial class TessControlCodeBase : CodeBase {
        /// <summary>
        /// the number of vertices in the input patch.
        /// </summary>
        //[InAttribute]
        public int gl_PatchVerticesIn;
        /// <summary>
        /// the index of the current patch within this rendering command.
        /// </summary>
        //[InAttribute]
        public int gl_PrimitiveID;
        /// <summary>
        /// the index of the TCS invocation within this patch. A TCS invocation writes to per-vertex output variables by using this to index them.
        /// </summary>
        //[InAttribute]
        public int gl_InvocationID;
        public struct gl_PerVertex {
            vec4 gl_Position;
            float gl_PointSize;
            float[] gl_ClipDistance;
        }
        //[InAttribute]
        public gl_PerVertex[] gl_in;// [gl_MaxPatchVertices];

        //[patch]
        //[OutAttribute]
        float[] gl_TessLevelOuter;//[4];
        //[patch]
        //[OutAttribute]
        float[] gl_TessLevelInner;//[2];

        /// <summary>
        /// optional. no need to write to gl_out
        /// </summary>
        //[OutAttribute]
        public gl_PerVertex[] gl_out;

    }
}
