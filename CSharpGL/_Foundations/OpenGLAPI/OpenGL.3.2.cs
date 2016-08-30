using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class OpenGL
    {

        #region OpenGL 3.2

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public delegate void glGetInteger64i_v(uint target, uint index, Int64[] data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetBufferParameteri64v(uint target, uint pname, Int64[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="texture"></param>
        /// <param name="level"></param>
        public delegate void glFramebufferTexture(uint target, uint attachment, uint texture, int level);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_CORE_PROFILE_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_COMPATIBILITY_PROFILE_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINES_ADJACENCY = 0x000A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_STRIP_ADJACENCY = 0x000B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRIANGLES_ADJACENCY = 0x000C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PATCHES = 0xE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROGRAM_POINT_SIZE = 0x8642;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_SHADER = 0x8DD9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_VERTICES_OUT = 0x8916;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_INPUT_TYPE = 0x8917;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_OUTPUT_TYPE = 0x8918;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_PROFILE_MASK = 0x9126;

        #endregion

    }
}
