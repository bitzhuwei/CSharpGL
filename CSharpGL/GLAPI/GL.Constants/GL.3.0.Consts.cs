using System;
namespace CSharpGL
{
    public partial class GL
    {
        #region OpenGL 3.0

        //  Constants
        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPARE_REF_TO_TEXTURE = 0x884E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE0 = 0x3000;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE1 = 0x3001;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE2 = 0x3002;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE3 = 0x3003;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE4 = 0x3004;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE5 = 0x3005;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE6 = 0x3006;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLIP_DISTANCE7 = 0x3007;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_CLIP_DISTANCES = 0x0D32;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAJOR_VERSION = 0x821B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MINOR_VERSION = 0x821C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_NUM_EXTENSIONS = 0x821D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CONTEXT_FLAGS = 0x821E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_DEPTH_BUFFER = 0x8223;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STENCIL_BUFFER = 0x8224;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RED = 0x8225;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RG = 0x8226;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = 0x0001;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA32F = 0x8814;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB32F = 0x8815;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA16F = 0x881A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB16F = 0x881B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLAMP_READ_COLOR = 0x891C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_FIXED_ONLY = 0x891D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_VARYING_COMPONENTS = 0x8B4B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_1D_ARRAY = 0x8C18;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_2D_ARRAY = 0x8C1A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R11F_G11F_B10F = 0x8C3A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB9_E5 = 0x8C3D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_SHARED_SIZE = 0x8C3F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PRIMITIVES_GENERATED = 0x8C87;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RASTERIZER_DISCARD = 0x8C89;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INTERLEAVED_ATTRIBS = 0x8C8C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SEPARATE_ATTRIBS = 0x8C8D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA32UI = 0x8D70;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB32UI = 0x8D71;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA16UI = 0x8D76;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB16UI = 0x8D77;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA8UI = 0x8D7C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB8UI = 0x8D7D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA32I = 0x8D82;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB32I = 0x8D83;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA16I = 0x8D88;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB16I = 0x8D89;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA8I = 0x8D8E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB8I = 0x8D8F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RED_INTEGER = 0x8D94;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_GREEN_INTEGER = 0x8D95;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BLUE_INTEGER = 0x8D96;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB_INTEGER = 0x8D98;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA_INTEGER = 0x8D99;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BGR_INTEGER = 0x8D9A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BGRA_INTEGER = 0x8D9B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_1D_ARRAY = 0x8DC0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D_ARRAY = 0x8DC1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_CUBE_SHADOW = 0x8DC5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC2 = 0x8DC6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC3 = 0x8DC7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC4 = 0x8DC8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_1D = 0x8DC9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_2D = 0x8DCA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_3D = 0x8DCB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_CUBE = 0x8DCC;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_1D_ARRAY = 0x8DCE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_2D_ARRAY = 0x8DCF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_QUERY_WAIT = 0x8E13;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_QUERY_NO_WAIT = 0x8E14;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_QUERY_BY_REGION_WAIT = 0x8E15;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_QUERY_BY_REGION_NO_WAIT = 0x8E16;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BUFFER_ACCESS_FLAGS = 0x911F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BUFFER_MAP_LENGTH = 0x9120;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BUFFER_MAP_OFFSET = 0x9121;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R8 = 0x8229;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R16 = 0x822A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG8 = 0x822B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG16 = 0x822C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R16F = 0x822D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R32F = 0x822E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG16F = 0x822F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG32F = 0x8230;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R8I = 0x8231;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R8UI = 0x8232;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R16I = 0x8233;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R16UI = 0x8234;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R32I = 0x8235;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R32UI = 0x8236;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG8I = 0x8237;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG8UI = 0x8238;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG16I = 0x8239;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG16UI = 0x823A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG32I = 0x823B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG32UI = 0x823C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG = 0x8227;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG_INTEGER = 0x8228;

        #endregion OpenGL 3.0
    }
}