using System;
namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 3.0

        //  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="r"></param>
        ///// <param name="g"></param>
        ///// <param name="b"></param>
        ///// <param name="a"></param>
        //public delegate void glColorMaski(uint index, bool r, bool g, bool b, bool a);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetBooleani_v(uint target, uint index, bool[] data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetIntegeri_v(uint target, uint index, int[] data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glEnablei(uint target, uint index);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glDisablei(uint target, uint index);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate bool glIsEnabledi(uint target, uint index);
        /// <summary>
        ///
        /// </summary>
        /// <param name="primitiveMode"></param>
        public delegate void glBeginTransformFeedback(uint primitiveMode);

        ///// <summary>
        /////
        ///// </summary>
        //public delegate void glEndTransformFeedback();
        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        internal delegate void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);

        /// <summary>
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="bindingPoint">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="bufferName">Buffer name generated from glGenBuffers().</param>
        internal delegate void glBindBufferBase(uint target, uint bindingPoint, uint bufferName);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="count"></param>
        ///// <param name="varyings"></param>
        ///// <param name="bufferMode"></param>
        //public delegate void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="clamp"></param>
        //public delegate void glClampColor(uint target, uint clamp);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mode"></param>
        internal delegate void glBeginConditionalRender(uint id, uint mode);

        /// <summary>
        ///
        /// </summary>
        internal delegate void glEndConditionalRender();

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="stride"></param>
        /// <param name="pointer"></param>
        public delegate void glVertexAttribIPointer(uint index, int size, uint type, int stride, IntPtr pointer);
        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="stride"></param>
        /// <param name="pointer"></param>
        public delegate void glVertexAttribLPointer(uint index, int size, uint type, int stride, IntPtr pointer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIiv(uint index, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIuiv(uint index, uint pname, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1i(uint index, int x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2i(uint index, int x, int y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3i(uint index, int x, int y, int z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4i(uint index, int x, int y, int z, int w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1ui(uint index, uint x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2ui(uint index, uint x, uint y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3ui(uint index, uint x, uint y, uint z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4bv(uint index, sbyte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4ubv(uint index, byte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4usv(uint index, ushort[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="location"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetUniformuiv(uint program, int location, uint[] parameters);
        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="colorNumber"></param>
        /// <param name="name"></param>
        public delegate void glBindFragDataLocation(uint program, uint colorNumber, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="colorNumber"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public delegate void glBindFragDataLocationIndexed(uint program, uint colorNumber, uint index, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public delegate int glGetFragDataLocation(uint program, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public delegate int glGetFragDataIndex(uint program, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        internal delegate void glUniform1ui(int location, uint v0);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal delegate void glUniform2ui(int location, uint v0, uint v1);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        internal delegate void glUniform3ui(int location, uint v0, uint v1, uint v2);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        internal delegate void glUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform1uiv(int location, int count, uint[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform2uiv(int location, int count, uint[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform3uiv(int location, int count, uint[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform4uiv(int location, int count, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIuiv(uint target, uint pname, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIuiv(uint target, uint pname, uint[] parameters);
        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawbuffer"></param>
        /// <param name="value"></param>
        public delegate void glClearBufferiv(uint buffer, int drawbuffer, int[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawbuffer"></param>
        /// <param name="value"></param>
        public delegate void glClearBufferuiv(uint buffer, int drawbuffer, uint[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawbuffer"></param>
        /// <param name="value"></param>
        public delegate void glClearBufferfv(uint buffer, int drawbuffer, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawbuffer"></param>
        /// <param name="depth"></param>
        /// <param name="stencil"></param>
        public delegate void glClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate string glGetStringi(uint name, uint index);

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