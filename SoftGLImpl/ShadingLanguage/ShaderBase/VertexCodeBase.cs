using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract partial class VertexCodeBase : CodeBase {
        /// <summary>
        /// the index of the vertex currently being processed. When using non-indexed rendering, it is the effective index of the current vertex (the number of vertices processed + the first​ value). For indexed rendering, it is the index used to fetch this vertex from the buffer.
        /// <para>Note: gl_VertexID will have the baseVertex​ parameter added to the index, if there was such a parameter in the rendering command.</para>
        /// </summary>
        public int gl_VertexID;
        /// <summary>
        /// the index of the current instance when doing some form of instanced rendering. The instance count always starts at 0, even when using base instance calls. When not using instanced rendering, this value will be 0.
        /// <para>Warning: This value does not follow the baseInstance​ provided by some instanced rendering functions. gl_InstanceID always falls on the half-open range [0, instancecount​). If you have GLSL 4.60, you may use gl_BaseInstance to compute the proper instance index.</para>
        /// </summary>
        public int gl_InstanceID;
        /// <summary>
        /// Requires GLSL 4.60 or ARB_shader_draw_parameters
        /// <para>the index of the drawing command within multi-draw rendering commands (including indirect multi-draw commands). The first draw command has an ID of 0, increasing by one as the renderer passes through drawing commands.</para>
        /// <para>This value will always be a Dynamically Uniform Expression.</para>
        /// </summary>
        public int gl_DrawID;
        /// <summary>
        /// Requires GLSL 4.60 or ARB_shader_draw_parameters
        /// <para>the value of the baseVertex​ parameter of the rendering command. If the rendering command did not include that parameter, the value of this input will be 0.</para>
        /// </summary>
        public int gl_BaseVertex;
        /// <summary>
        /// Requires GLSL 4.60 or ARB_shader_draw_parame
        /// <para>the value of the baseInstance​ parameter of the instanced rendering command. If the rendering command did not include this parameter, the value of this input will be 0.</para>
        /// </summary>
        public int gl_BaseInstance;

        /// <summary>
        /// the clip-space output position of the current vertex.
        /// </summary>
        //[OutAttribute]
        public vec4 gl_Position;

        /// <summary>
        /// the pixel width/height of the point being rasterized. It only has a meaning when rendering point primitives. It will be clamped to the GL_POINT_SIZE_RANGE.
        /// </summary>
        //[OutAttribute]
        public float gl_PointSize;

        /// <summary>
        /// allows the shader to set the distance from the vertex to each user-defined clipping half-space. A non-negative distance means that the vertex is inside/behind the clip plane, and a negative distance means it is outside/in front of the clip plane. Each element in the array is one clip plane. In order to use this variable, the user must manually redeclare it with an explicit size. With GLSL 4.10 or ARB_separate_shader_objects, the whole gl_PerVertex block needs to be redeclared. Otherwise just the gl_ClipDistance built-in needs to be redeclared.
        /// </summary>
        //[OutAttribute]
        public float[] gl_ClipDistance;

    }
}
