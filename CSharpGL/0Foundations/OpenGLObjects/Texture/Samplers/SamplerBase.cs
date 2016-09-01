using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public abstract class SamplerBase
    {
        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="mipmapFilter"></param>
        public SamplerBase(SamplerParameters parameters, MipmapFilter mipmapFilter)
        {
            if (parameters == null)
            {
                this.parameters = new SamplerParameters();
            }
            else
            {
                this.parameters = parameters;
            }

            this.mipmapFilter = mipmapFilter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit">OpenGL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public abstract void Bind(uint unit, BindTextureTarget target);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="unit"></param>
        ///// <param name="target"></param>
        //public abstract void Unbind(uint unit, BindTextureTarget target);

        /// <summary>
        /// 
        /// </summary>
        protected SamplerParameters parameters;
        /// <summary>
        /// 
        /// </summary>
        protected MipmapFilter mipmapFilter;

        /// <summary>
        /// 
        /// </summary>
        public SamplerParameters Parameters { get { return this.parameters; } }

    }
}
