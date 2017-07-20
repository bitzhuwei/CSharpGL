using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexStorage2D : TexStorageBase
    {
        private Target target;
        private int levels;
        private uint internalFormat;
        private int width;
        private int height;

        private static readonly GLDelegates.void_uint_int_uint_int_int glTexStorage2D;
        static TexStorage2D()
        {
            glTexStorage2D = GL.Instance.GetDelegateFor("glTexStorage2D", GLDelegates.typeof_void_uint_int_uint_int_int) as GLDelegates.void_uint_int_uint_int_int;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public TexStorage2D(Target target, int levels, uint internalFormat, int width, int height)
        {
            this.target = target;
            this.levels = levels;
            this.internalFormat = internalFormat;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexStorage2D((uint)target, levels, internalFormat, width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Target : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Texture1DArray = GL.GL_TEXTURE_1D_ARRAY,

            /// <summary>
            /// 
            /// </summary>
            Texture2D = GL.GL_TEXTURE_2D,
        }
    }
}
