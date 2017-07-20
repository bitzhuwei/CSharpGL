using System;

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
        public void Initialize(uint unit, TextureTarget target)
        {
            if (!this.initialized)
            {
                this.DoInitialize(unit, target);
                this.initialized = true;
            }
        }

        private void DoInitialize(uint unit, TextureTarget target)
        {
            var ids = new uint[1];
            glGenSamplers(1, ids);
            this.Id = ids[0];
            //OpenGL.BindSampler(unit, ids[0]);
            glBindSampler(unit, ids[0]);
            /* Clamping to edges is important to prevent artifacts when scaling */
            glSamplerParameteri(ids[0], GL.GL_TEXTURE_WRAP_R, (int)this.parameters.wrapR);
            glSamplerParameteri(ids[0], GL.GL_TEXTURE_WRAP_S, (int)this.parameters.wrapS);
            glSamplerParameteri(ids[0], GL.GL_TEXTURE_WRAP_T, (int)this.parameters.wrapT);
            /* Linear filtering usually looks best for text */
            glSamplerParameteri(ids[0], GL.GL_TEXTURE_MIN_FILTER, (int)this.parameters.minFilter);
            glSamplerParameteri(ids[0], GL.GL_TEXTURE_MAG_FILTER, (int)this.parameters.magFilter);
            // TODO: mipmap not used yet.

            glBindSampler(unit, 0);
        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="unit">GL.GL_TEXTURE0 etc.</param>
        /// <param name="target"></param>
        public override void Bind(uint unit, TextureTarget target)
        {
            if (!this.initialized) { this.Initialize(unit, target); }

            glBindSampler(unit, this.Id);
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

        private static GLDelegates.void_int_uintN glGenSamplers;
        private static GLDelegates.void_uint_uint glBindSampler;
        private static GLDelegates.void_uint_uint_int glSamplerParameteri;

        static Sampler()
        {
            glGenSamplers = GL.Instance.GetDelegateFor("glGenSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindSampler = GL.Instance.GetDelegateFor("glBindSampler", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glSamplerParameteri = GL.Instance.GetDelegateFor("glSamplerParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
        }
    }
}