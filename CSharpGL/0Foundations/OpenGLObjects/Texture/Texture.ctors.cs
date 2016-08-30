using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Texture.
    /// </summary>
    public partial class Texture
    {
        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        /// <param name="target"></param>
        public Texture(ImageBuilder imageBuilder, SamplerBase samplerBuilder,
            BindTextureTarget target = BindTextureTarget.Texture2D)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.ImageBuilder = imageBuilder;
            this.SamplerBuilder = samplerBuilder;

            this.ActiveTexture = OpenGL.GL_TEXTURE0;
            this.Target = target;
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="samplerBuilder"></param>
        /// <param name="target"></param>
        public Texture(Bitmap bitmap, SamplerBase samplerBuilder,
            BindTextureTarget target = BindTextureTarget.Texture2D)
            : this(new BitmapBuilder(bitmap, target), samplerBuilder, target)
        {
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        /// <param name="target"></param>
        public Texture(ImageBuilder imageBuilder,
            BindTextureTarget target = BindTextureTarget.Texture2D,
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(imageBuilder, new FakeSampler(parameters, mipmapFiltering), target)
        {
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        /// <param name="target"></param>
        public Texture(Bitmap bitmap,
            BindTextureTarget target,
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(new BitmapBuilder(bitmap, target), new FakeSampler(parameters, mipmapFiltering), target)
        {
        }
    }
}
