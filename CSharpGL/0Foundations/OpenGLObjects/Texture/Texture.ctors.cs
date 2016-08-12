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
    public partial class Texture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        public Texture(NewImageBuilder imageBuilder, SamplerBase samplerBuilder)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.ImageBuilder = imageBuilder;
            this.SamplerBuilder = samplerBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="samplerBuilder"></param>
        public Texture(Bitmap bitmap, SamplerBase samplerBuilder)
            : this(new NewBitmapBuilder(bitmap), samplerBuilder)
        {
            this.Target = BindTextureTarget.Texture2D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public Texture(NewImageBuilder imageBuilder,
            TextureWrapping wrapping = TextureWrapping.ClampToEdge,
            TextureFilter textureFiltering = TextureFilter.Linear,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(imageBuilder, new FakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public Texture(Bitmap bitmap,
            TextureWrapping wrapping = TextureWrapping.ClampToEdge,
            TextureFilter textureFiltering = TextureFilter.Linear,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(new NewBitmapBuilder(bitmap), new FakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
            this.Target = BindTextureTarget.Texture2D;
        }
    }
}
