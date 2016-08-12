using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Texture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        /// <param name="target"></param>
        public Texture(NewImageBuilder imageBuilder, SamplerBase samplerBuilder,
            BindTextureTarget target = BindTextureTarget.Texture2D)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.ImageBuilder = imageBuilder;
            this.SamplerBuilder = samplerBuilder;

            this.ActiveTexture = OpenGL.GL_TEXTURE0;
            this.Target = target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="samplerBuilder"></param>
        /// <param name="target"></param>
        public Texture(Bitmap bitmap, SamplerBase samplerBuilder,
            BindTextureTarget target = BindTextureTarget.Texture2D)
            : this(new NewBitmapBuilder(bitmap), samplerBuilder, target)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        /// <param name="target"></param>
        public Texture(NewImageBuilder imageBuilder,
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear,
            BindTextureTarget target = BindTextureTarget.Texture2D)
            : this(imageBuilder, new FakeSampler(parameters, mipmapFiltering), target)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        /// <param name="target"></param>
        public Texture(Bitmap bitmap,
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear,
            BindTextureTarget target = BindTextureTarget.Texture2D)
            : this(new NewBitmapBuilder(bitmap), new FakeSampler(parameters, mipmapFiltering), target)
        {
        }
    }
}
