using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public partial class Sampler : SamplerBase, IDisposable
    {
        /// <summary>
        /// sampler's Id.
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        public Sampler(
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : base(parameters, mipmapFiltering)
        {

        }

        private bool initialized = false;
        /// <summary>
        /// 
        /// </summary>
        public void Initialize(uint unit, BindTextureTarget target)
        {
            if (!this.initialized)
            {
                this.DoInitialize(unit, target);
                this.initialized = true;
            }
        }

        private void DoInitialize(uint unit, BindTextureTarget target)
        {
            var ids = new uint[1];
            OpenGL.GenSamplers(1, ids);
            this.Id = ids[0];
            //OpenGL.BindSampler(unit, ids[0]);
            OpenGL.BindSampler(unit, ids[0]);
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.SamplerParameteri(ids[0], OpenGL.GL_TEXTURE_WRAP_R, (int)this.parameters.wrapR);
            OpenGL.SamplerParameteri(ids[0], OpenGL.GL_TEXTURE_WRAP_S, (int)this.parameters.wrapS);
            OpenGL.SamplerParameteri(ids[0], OpenGL.GL_TEXTURE_WRAP_T, (int)this.parameters.wrapT);
            /* Linear filtering usually looks best for text */
            OpenGL.SamplerParameteri(ids[0], OpenGL.GL_TEXTURE_MIN_FILTER, (int)this.parameters.minFilter);
            OpenGL.SamplerParameteri(ids[0], OpenGL.GL_TEXTURE_MAG_FILTER, (int)this.parameters.magFilter);
            // TODO: mipmap not used yet.

            OpenGL.BindSampler(unit, 0);
        }
        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="unit">OpenGL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public override void Bind(uint unit, BindTextureTarget target)
        {
            if (!this.initialized) { this.Initialize(unit, target); }

            OpenGL.BindSampler(unit, this.Id);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="unit"></param>
        ///// <param name="target"></param>
        //public override void Unbind(uint unit, BindTextureTarget target)
        //{
        //    //OpenGL.BindSampler(unit, 0); 
        //    OpenGL.GetDelegateFor<OpenGL.glBindSampler>()(unit, 0);
        //}
    }
}
