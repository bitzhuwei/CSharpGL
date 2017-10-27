using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexImageBase
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
        public readonly int border;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalformat"></param>
        /// <param name="border"></param>
        /// <param name="contentProvider"></param>
        public TexImageBase(TextureTarget target, uint internalformat, int border)
        {
            this.target = target; this.internalFormat = internalformat; this.border = border;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Apply();
    }
}
