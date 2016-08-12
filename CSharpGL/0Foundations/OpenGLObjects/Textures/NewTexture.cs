using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class NewTexture : NewTextureBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        public NewTexture(NewImageBuilder imageBuilder, NewSamplerBase samplerBuilder)
            : base(imageBuilder, samplerBuilder)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewTexture(Bitmap bitmap, NewSamplerBase samplerBuilder)
            : this(new NewBitmapBuilder(bitmap), samplerBuilder)
        {
            this.Target = BindTextureTarget.Texture2D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewTexture(NewImageBuilder imageBuilder, TextureWrapping wrapping, TextureFilter textureFiltering, MipmapFilter mipmapFiltering)
            : this(imageBuilder, new NewFakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
            this.Target = BindTextureTarget.Texture2D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewTexture(Bitmap bitmap, TextureWrapping wrapping, TextureFilter textureFiltering, MipmapFilter mipmapFiltering)
            : this(new NewBitmapBuilder(bitmap), new NewFakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
            this.Target = BindTextureTarget.Texture2D;
        }
    }
}
