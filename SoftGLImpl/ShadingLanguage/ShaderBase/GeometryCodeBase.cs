using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract partial class GeometryCodeBase : CodeBase {
        public struct gl_PerVertex {
            vec4 gl_Position;
            float gl_PointSize;
            float[] gl_ClipDistance;
        }
        //[InAttribute]
        public gl_PerVertex[] gl_in;

        /// <summary>
        /// the current input primitive's ID, based on the number of primitives processed by the GS since the current drawing command started.
        /// </summary>
        //[InAttribute]
        public int gl_PrimitiveIDIn;
        /// <summary>
        /// Requires GLSL 4.0 or ARB_gpu_shader5
        /// <para>the current instance, as defined when instancing geometry shaders.</para>
        /// </summary>
        //[InAttribute]
        public int gl_InvocationID;

        //public readonly GeometryIn inType;
        //public readonly GeometryOut outType;
        //public readonly int maxVertices;

        /// <summary>
        /// the clip-space output position of the current vertex. This value must be written if you are emitting a vertex to stream 0, unless rasterization is off.
        /// </summary>
        //[OutAttribute]
        public vec4 gl_Position;
        /// <summary>
        /// the pixel width/height of the point being rasterized. It is only necessary to write to this when outputting point primitives.
        /// </summary>
        //[OutAttribute]
        public float gl_PointSize;
        /// <summary>
        /// allows the shader to set the distance from the vertex to each User-Defined Clip Plane. A positive distance means that the vertex is inside/behind the clip plane, and a negative distance means it is outside/in front of the clip plane. In order to use this variable, the user must manually redeclare it (and therefore the interface block) with an explicit size.
        /// </summary>
        //[OutAttribute]
        public float[] gl_ClipDistance;

        /// <summary>
        /// The primitive ID will be passed to the fragment shader. The primitive ID for a particular line/triangle will be taken from the provoking vertex of that line/triangle, so make sure that you are writing the correct value for the right provoking vertex.
        /// <para>The meaning for this value is whatever you want it to be. However, if you want to match the standard OpenGL meaning (ie: what the Fragment Shader would get if no GS were used), you must do this for each vertex before emitting it: gl_PrimitiveID = gl_PrimitiveIDIn;</para>
        /// </summary>
        //[OutAttribute]
        public int gl_PrimitiveID;
        /// <summary>
        /// The gl_Layer output defines which layer in the layered image the primitive goes to. Each vertex in the primitive must get the same layer index. Note that when rendering to cubemap arrays, the gl_Layer value represents layer-faces (the faces within a layer), not the layers of cubemaps.
        /// </summary>
        //[OutAttribute]
        public int gl_Layer;
        // Note: ARB_viewport_array, while technically a 4.1 feature, is widely available on 3.3 hardware, from both NVIDIA and AMD.
        /// <summary>
        /// gl_ViewportIndex, which requires GL 4.1 or ARB_viewport_array, specifies which viewport index to use with this primitive.
        /// </summary>
        //[OutAttribute]
        public int gl_ViewportIndex;

        //public GeometryCodeBase(GeometryIn inType, GeometryOut outType, int maxVertices) {
        //    this.inType = inType; this.outType = outType; this.maxVertices = maxVertices;
        //}

        protected void EmitVertex() { throw new NotImplementedException(); }
        protected void EndPrimitive() { throw new NotImplementedException(); }
    }

    public enum GeometryIn {
        triangles_adjacency,
    }

    public enum GeometryOut {
        triangle_strip
    }
}
