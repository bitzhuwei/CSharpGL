using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    public abstract partial class TextureBase : IDisposable
    {
        // GL.GL_TEXTURE0(= 0x84C0 = 33984)
        /// <summary>
        /// Which texture unit should I bind to?
        /// <para>0 means GL.GL_TEXTURE0, 1 means GL.GL_TEXTURE1, ...</para>
        /// </summary>
        public uint TextureUnit { get; set; }

        /// <summary>
        /// binding target of this texture.
        /// </summary>
        public TextureTarget Target { get; protected set; }

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
            GL.Instance.BindTexture((uint)this.Target, this.Id);
            //this.SamplerBuilder.Bind(GL.GL_TEXTURE0 - GL.GL_TEXTURE0, this.Target);
        }

        /// <summary>
        ///
        /// </summary>
        public void Unbind()
        {
            //OpenGL.BindTexture(GL.GL_TEXTURE_2D, 0);
            GL.Instance.BindTexture((uint)this.Target, 0);
        }

        private static GLDelegates.void_uint glActiveTexture;
        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                //if (glActiveTexture == null)
                //{ glActiveTexture = GL.Instance.GetDelegateFor("glActiveTexture", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }
                //glActiveTexture(this.TextureUnit + GL.GL_TEXTURE0);
                //GL.Instance.GenTextures(1, id);
                //TextureTarget target = this.Target;
                //GL.Instance.BindTexture((uint)target, id[0]);
                //this.Sampler.Bind(this.TextureUnit, target);
                //this.ImageFiller.Fill();
                ////OpenGL.GenerateMipmap((MipmapTarget)((uint)target));// TODO: does this work?
                ////this.SamplerBuilder.Unbind(GL.GL_TEXTURE0 - GL.GL_TEXTURE0, this.Target);
                //GL.Instance.BindTexture((uint)this.Target, 0);
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
                this.TextureUnit, this.Target, this.Id);
        }
    }
}
