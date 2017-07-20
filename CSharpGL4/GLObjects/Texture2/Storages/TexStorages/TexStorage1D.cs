using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexStorage1D : TexStorageBase
    {
        private int levels;
        private uint internalFormat;
        private int width;

        private static readonly GLDelegates.void_uint_int_uint_int glTexStorage1D;
        static TexStorage1D()
        {
            glTexStorage1D = GL.Instance.GetDelegateFor("glTexStorage1D", GLDelegates.typeof_void_uint_int_uint_int) as GLDelegates.void_uint_int_uint_int;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        public TexStorage1D(int levels, uint internalFormat, int width)
        {
            this.levels = levels;
            this.internalFormat = internalFormat;
            this.width = width;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexStorage1D(GL.GL_TEXTURE_1D, levels, internalFormat, width);
        }
    }
}
