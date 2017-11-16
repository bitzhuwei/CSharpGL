using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexStorage3D : TexStorageBase
    {
        private int width;
        private int height;
        private int depth;

        internal static readonly GLDelegates.void_uint_int_uint_int_int_int glTexStorage3D;
        static TexStorage3D()
        {
            glTexStorage3D = GL.Instance.GetDelegateFor("glTexStorage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int) as GLDelegates.void_uint_int_uint_int_int_int;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="mipmapLevelCount"></param>
        public TexStorage3D(Target target, uint internalFormat, int width, int height, int depth, int mipmapLevelCount = 1)
            : base((TextureTarget)target, internalFormat, mipmapLevelCount)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexStorage3D((uint)target, mipmapLevelCount, internalFormat, width, height, depth);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Target : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Texture2DArray = GL.GL_TEXTURE_2D_ARRAY,

            /// <summary>
            /// 
            /// </summary>
            Texture3D = GL.GL_TEXTURE_3D,
        }
    }
}
