using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexStorageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly TextureTarget target;
        /// <summary>
        /// 
        /// </summary>
        public readonly uint internalFormat;
        /// <summary>
        /// 
        /// </summary>
        public readonly int mipmapLevelCount;
        /// <summary>
        /// 
        /// </summary>
        public readonly bool border;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexStorageBase(TextureTarget target, uint internalFormat, int mipmapLevelCount = 1, bool border = false)
        {
            this.target = target;
            this.internalFormat = internalFormat;
            this.mipmapLevelCount = mipmapLevelCount;
            this.border = border;
        }

        /// <summary>
        /// Apply storage command to the texture object.
        /// </summary>
        public abstract void Apply();
    }
}
