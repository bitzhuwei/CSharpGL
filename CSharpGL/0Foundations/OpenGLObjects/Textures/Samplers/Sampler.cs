using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public class NewSampler : NewSamplerBase
    {
        /// <summary>
        /// sampler's Id.
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewSampler(TextureWrapping wrapping, TextureFilter textureFiltering, MipmapFilter mipmapFiltering)
            : base(wrapping, textureFiltering, mipmapFiltering)
        {

        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="target"></param>
        public override void Build(BindTextureTarget target)
        {
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_S, (int)this.Wrapping);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_T, (int)this.Wrapping);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MIN_FILTER, (int)this.TextureFilter);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MAG_FILTER, (int)this.TextureFilter);

            // TODO: mipmap not used yet.
        }
    }
}
