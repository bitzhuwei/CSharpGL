using System;

namespace CSharpGL
{
    /// <summary>
    /// A texture object.
    /// </summary>
    public partial class Texture : IDisposable
    {
        /// OpenGL.GL_TEXTURE0(= 0x84C0 = 33984)
        /// <summary>
        /// 0 means OpenGL.GL_TEXTURE0, 1 means OpenGL.GL_TEXTURE1, ...
        /// </summary>
        public uint ActiveTextureIndex { get; set; }

        /// <summary>
        /// binding target of this texture.
        /// </summary>
        public TextureTarget Target { get; private set; }

        /// <summary>
        /// texture's id/name.
        /// </summary>
        protected uint[] id = new uint[1];

        /// <summary>
        /// texture's id/name from glGenTextures().
        /// 纹理名（用于标识一个纹理，由OpenGL指定）。
        /// </summary>
        public uint Id { get { return this.id[0]; } }

        ///// <summary>
        /////
        ///// </summary>
        //public bool UseMipmap { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public void Bind()
        {
            OpenGL.BindTexture(this.Target, this.Id);
            //this.SamplerBuilder.Bind(OpenGL.GL_TEXTURE0 - OpenGL.GL_TEXTURE0, this.Target);
        }

        /// <summary>
        ///
        /// </summary>
        public void Unbind()
        {
            //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            OpenGL.BindTexture(this.Target, 0);
        }

        private static OpenGL.glActiveTexture activeTexture;
        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                if (activeTexture == null)
                { activeTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
                activeTexture(this.ActiveTextureIndex + OpenGL.GL_TEXTURE0);
                OpenGL.GenTextures(1, id);
                TextureTarget target = this.Target;
                OpenGL.BindTexture(target, id[0]);
                this.Sampler.Bind(this.ActiveTextureIndex, target);
                this.ImageFiller.Fill();
                OpenGL.GenerateMipmap((MipmapTarget)((uint)target));// TODO: does this work?
                //this.SamplerBuilder.Unbind(OpenGL.GL_TEXTURE0 - OpenGL.GL_TEXTURE0, this.Target);
                OpenGL.BindTexture(this.Target, 0);
                this.initialized = true;
            }
        }

        /// <summary>
        /// setup texture's image data.
        /// </summary>
        public ImageFiller ImageFiller { get; private set; }

        /// <summary>
        /// setup texture's sampler properties.
        /// </summary>
        public SamplerBase Sampler { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ActiveTexture{0}, Target:{1}, Id:{2}",
                this.ActiveTextureIndex, this.Target, this.Id);
        }
    }
}