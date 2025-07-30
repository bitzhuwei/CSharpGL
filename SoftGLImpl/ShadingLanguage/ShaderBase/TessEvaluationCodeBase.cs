using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SoftGLImpl.TessControlCodeBase;

namespace SoftGLImpl {
    public abstract partial class TessEvaluationCodeBase : CodeBase {
        /// <summary>
        /// the location within the tessellated abstract patch for this particular vertex. Every input parameter other than this one will be identical for all TES invocations within a patch.
        /// <para>Which components of this vec3 that have valid values depends on the abstract patch type. For isolines and quads, only the XY components have valid values. For triangles, all three components have valid values. All valid values are normalized floats (on the range [0, 1]).</para>
        /// </summary>
        //[InAttribute]
        public vec3 gl_TessCoord;
        /// <summary>
        /// the vertex count for the patch being processed. This is either the output vertex count specified by the TCS, or the patch vertex size specified by glPatchParameter if no TCS is active. Attempts to index per-vertex inputs by a value greater than or equal to gl_PatchVerticesIn results in undefined behavior.
        /// </summary>
        //[InAttribute]
        public int gl_PatchVerticesIn;
        /// <summary>
        /// the index of the current patch in the series of patches being processed for this draw call. Primitive restart, if used, has no effect on the primitive ID.
        /// </summary>
        //[InAttribute]
        public int gl_PrimitiveID;

        //[patch]
        //[InAttribute]
        public float[] gl_TessLevelOuter;//[4];
        public float[] gl_TessLevelInner;//[2];

        public struct gl_PerVertex {
            vec4 gl_Position;
            float gl_PointSize;
            float[] gl_ClipDistance;
        }
        //[InAttribute]
        public gl_PerVertex[] gl_in;// [gl_MaxPatchVertices];

        /// <summary>
        /// the clip-space output position of the current vertex.
        /// </summary>
        //[OutAttribute]
        vec4 gl_Position;
        /// <summary>
        /// the pixel width/height of the point being rasterized. It only has a meaning when rendering point primitives, which in a TES requires using the point_mode​ input layout qualifier.

        /// </summary>
        //[OutAttribute]
        float gl_PointSize;
        /// <summary>
        /// allows the shader to set the distance from the vertex to each User-Defined Clip Plane. A positive distance means that the vertex is inside/behind the clip plane, and a negative distance means it is outside/in front of the clip plane. Each element in the array is one clip plane. In order to use this variable, the user must manually redeclare it with an explicit size.
        /// </summary>
        //[OutAttribute]
        float[] gl_ClipDistance;

    }
}
