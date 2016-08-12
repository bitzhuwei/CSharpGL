using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public abstract class NewSamplerBase
    {
        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="wrapping"></param>
        /// <param name="textureFilter"></param>
        /// <param name="mipmapFilter"></param>
        public NewSamplerBase(TextureWrapping wrapping, TextureFilter textureFilter, MipmapFilter mipmapFilter)
        {
            this.wrapping = wrapping;
            this.textureFilter = textureFilter;
            this.mipmapFilter = mipmapFilter;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Setup();

        /// <summary>
        /// 
        /// </summary>
        protected TextureWrapping wrapping;
        /// <summary>
        /// 
        /// </summary>
        protected TextureFilter textureFilter;
        /// <summary>
        /// 
        /// </summary>
        protected MipmapFilter mipmapFilter;

    }
}
