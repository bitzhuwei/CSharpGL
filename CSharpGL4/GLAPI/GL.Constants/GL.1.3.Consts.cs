namespace CSharpGL
{
    public partial class GL
    {
        #region OpenGL 1.3

        //  Constants
        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE0 = 0x84C0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE1 = 0x84C1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE2 = 0x84C2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE3 = 0x84C3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE4 = 0x84C4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE5 = 0x84C5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE6 = 0x84C6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE7 = 0x84C7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE8 = 0x84C8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE9 = 0x84C9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE10 = 0x84CA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE11 = 0x84CB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE12 = 0x84CC;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE13 = 0x84CD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE14 = 0x84CE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE15 = 0x84CF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE16 = 0x84D0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE17 = 0x84D1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE18 = 0x84D2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE19 = 0x84D3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE20 = 0x84D4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE21 = 0x84D5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE22 = 0x84D6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE23 = 0x84D7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE24 = 0x84D8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE25 = 0x84D9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE26 = 0x84DA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE27 = 0x84DB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE28 = 0x84DC;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE29 = 0x84DD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE30 = 0x84DE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE31 = 0x84DF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_TEXTURE = 0x84E0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MULTISAMPLE = 0x809D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE = 0x80A0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_BUFFERS = 0x80A8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLES = 0x80A9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP = 0x8513;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RGB = 0x84ED;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RGBA = 0x84EE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED = 0x86A1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLAMP_TO_BORDER = 0x812D;

        #endregion OpenGL 1.3
    }
}