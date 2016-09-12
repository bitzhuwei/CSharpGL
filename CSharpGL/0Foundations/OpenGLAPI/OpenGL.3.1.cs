using System;

namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 3.1

        //  Delegates
        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="primcount"></param>
        public delegate void glDrawArraysInstanced(uint mode, int first, int count, int primcount);

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="primcount"></param>
        public delegate void glDrawElementsInstanced(uint mode, int count, uint type, IntPtr indices, int primcount);

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        public delegate void glDrawElementsBaseVertex(uint mode, int count, uint type, IntPtr indices, int baseVertex);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalformat"></param>
        /// <param name="buffer"></param>
        public delegate void glTexBuffer(uint target, uint internalformat, uint buffer);

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public delegate void glPrimitiveRestartIndex(uint index);

        //  Constants
        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D_RECT = 0x8B63;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_2D_RECT_SHADOW = 0x8B64;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLER_BUFFER = 0x8DC2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_2D_RECT = 0x8DCD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_INT_SAMPLER_BUFFER = 0x8DD0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BUFFER = 0x8C2A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_BUFFER = 0x8C2C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BUFFER_FORMAT = 0x8C2E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_RECTANGLE = 0x84F5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_RECTANGLE = 0x84F6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_RECTANGLE = 0x84F7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RED_SNORM = 0x8F90;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG_SNORM = 0x8F91;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB_SNORM = 0x8F92;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA_SNORM = 0x8F93;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R8_SNORM = 0x8F94;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG8_SNORM = 0x8F95;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB8_SNORM = 0x8F96;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA8_SNORM = 0x8F97;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_R16_SNORM = 0x8F98;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RG16_SNORM = 0x8F99;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGB16_SNORM = 0x8F9A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_RGBA16_SNORM = 0x8F9B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SIGNED_NORMALIZED = 0x8F9C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PRIMITIVE_RESTART = 0x8F9D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PRIMITIVE_RESTART_INDEX = 0x8F9E;

        #endregion OpenGL 3.1
    }
}