using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public partial class GL
    {
        #region OpenGL 2.0

        //  Constants
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BLEND_EQUATION_RGB = 0x8009;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;

        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_STENCIL_BACK_FUNC = 0x8800;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_STENCIL_BACK_FAIL = 0x8801;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_MAX_DRAW_BUFFERS = 0x8824;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER0 = 0x8825;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER1 = 0x8826;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER2 = 0x8827;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER3 = 0x8828;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER4 = 0x8829;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER5 = 0x882A;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER6 = 0x882B;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER7 = 0x882C;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER8 = 0x882D;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER9 = 0x882E;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER10 = 0x882F;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER11 = 0x8830;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER12 = 0x8831;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER13 = 0x8832;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER14 = 0x8833;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_DRAW_BUFFER15 = 0x8834;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BLEND_EQUATION_ALPHA = 0x883D;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_MAX_VERTEX_ATTRIBS = 0x8869;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FRAGMENT_SHADER = 0x8B30;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_VERTEX_SHADER = 0x8B31;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TESS_CONTROL_SHADER = 0x8E88;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_TESS_EVALUATION_SHADER = 0x8E87;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_VARYING_FLOATS = 0x8B4B;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SHADER_TYPE = 0x8B4F;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_VEC2 = 0x8B50;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_VEC3 = 0x8B51;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_VEC4 = 0x8B52;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_VEC2 = 0x8B53;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_VEC3 = 0x8B54;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_VEC4 = 0x8B55;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_BOOL = 0x8B56;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_BOOL_VEC2 = 0x8B57;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_BOOL_VEC3 = 0x8B58;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_BOOL_VEC4 = 0x8B59;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_MAT2 = 0x8B5A;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_MAT3 = 0x8B5B;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FLOAT_MAT4 = 0x8B5C;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_1D = 0x8B5D;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D = 0x8B5E;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_3D = 0x8B5F;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_CUBE = 0x8B60;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_1D_SHADOW = 0x8B61;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D_SHADOW = 0x8B62;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_DELETE_STATUS = 0x8B80;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPILE_STATUS = 0x8B81;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_LINK_STATUS = 0x8B82;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_VALIDATE_STATUS = 0x8B83;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_INFO_LOG_LENGTH = 0x8B84;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_ATTACHED_SHADERS = 0x8B85;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_UNIFORMS = 0x8B86;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SHADER_SOURCE_LENGTH = 0x8B88;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_ATTRIBUTES = 0x8B89;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_CURRENT_PROGRAM = 0x8B8D;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_LOWER_LEFT = 0x8CA1;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_UPPER_LEFT = 0x8CA2;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_STENCIL_BACK_REF = 0x8CA3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;

        #endregion OpenGL 2.0
    }
}