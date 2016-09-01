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
            ImageFiller imageBuilder,
            SamplerBase samplerBuilder)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.Target = target;
            this.ImageFiller = imageBuilder;
            this.Sampler = samplerBuilder;

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
            : this(target, new BitmapFiller(bitmap, 0, OpenGL.GL_RGBA, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE), samplerBuilder)
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
            ImageFiller imageBuilder,
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
            : this(target, new BitmapFiller(bitmap, 0, OpenGL.GL_RGBA, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE), new FakeSampler(parameters, mipmapFiltering))
        {
        }
    }
}
