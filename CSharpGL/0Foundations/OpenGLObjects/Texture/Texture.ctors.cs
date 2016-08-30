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
        /// <param name="target"></param>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        public Texture(
            BindTextureTarget target,
            ImageBuilder imageBuilder,
            SamplerBase samplerBuilder)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.ImageBuilder = imageBuilder;
            this.SamplerBuilder = samplerBuilder;
            this.Target = target;

            this.ActiveTexture = OpenGL.GL_TEXTURE0;
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="bitmap"></param>
        /// <param name="samplerBuilder"></param>
        public Texture(BindTextureTarget target,
            Bitmap bitmap,
            SamplerBase samplerBuilder)
            : this(target, new BitmapBuilder(bitmap), samplerBuilder)
        {
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="imageBuilder"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        public Texture(
            BindTextureTarget target,
            ImageBuilder imageBuilder,
            SamplerParameters parameters,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(target, imageBuilder, new FakeSampler(parameters, mipmapFiltering))
        {
        }

        /// <summary>
        /// Texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="bitmap"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        public Texture(
            BindTextureTarget target,
            Bitmap bitmap,
            SamplerParameters parameters,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(target, new BitmapBuilder(bitmap), new FakeSampler(parameters, mipmapFiltering))
        {
        }
    }
}
