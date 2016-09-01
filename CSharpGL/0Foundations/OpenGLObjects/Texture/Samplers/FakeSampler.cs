using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public class FakeSampler : SamplerBase
    {

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        public FakeSampler(SamplerParameters parameters, MipmapFilter mipmapFiltering)
            : base(parameters, mipmapFiltering)
        {
        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="unit">OpenGL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public override void Bind(uint unit, BindTextureTarget target)
        {
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_R, (int)this.parameters.wrapR);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_S, (int)this.parameters.wrapS);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_T, (int)this.parameters.wrapT);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MIN_FILTER, (int)this.parameters.minFilter);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MAG_FILTER, (int)this.parameters.magFilter);
            // TODO: mipmap filter not working yet.

        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="unit"></param>
        ///// <param name="target"></param>
        //public override void Unbind(uint unit, BindTextureTarget target)
        //{
        //    // nothing to do.
        //}
    }
}
