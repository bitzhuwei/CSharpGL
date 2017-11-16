using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexStorage1D : TexStorageBase
    {
        private int width;

        internal static readonly GLDelegates.void_uint_int_uint_int glTexStorage1D;
        static TexStorage1D()
        {
            glTexStorage1D = GL.Instance.GetDelegateFor("glTexStorage1D", GLDelegates.typeof_void_uint_int_uint_int) as GLDelegates.void_uint_int_uint_int;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="mipmapLevelCount"></param>
        public TexStorage1D(uint internalFormat, int width, int mipmapLevelCount = 1)
            : base(TextureTarget.Texture1D, internalFormat, mipmapLevelCount)
        {
            this.width = width;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexStorage1D(GL.GL_TEXTURE_1D, this.mipmapLevelCount, this.internalFormat, this.width);
        }
    }
}
