using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A texture object.
    /// </summary>
    public partial class Texture : IDisposable
    {
        /// <summary>
        /// OpenGL.GL_TEXTURE0 etc.
        /// </summary>
        public uint ActiveTexture { get; set; }

        /// <summary>
        /// binding target of this texture.
        /// </summary>
        public BindTextureTarget Target { get; set; }

        /// <summary>
        /// texture's id/name.
        /// </summary>
        protected uint[] id = new uint[1];

        /// <summary>
        /// texture's id/name.
        /// 纹理名（用于标识一个纹理，由OpenGL指定），可在shader中用于指定uniform sampler2D纹理变量。
        /// </summary>
        public uint Id { get { return this.id[0]; } }

        ///// <summary>
        ///// 
        ///// </summary>
        //public void Bind()
        //{
        //    OpenGL.BindTexture(this.Target, this.id[0]);
        //    //this.SamplerBuilder.Bind(OpenGL.GL_TEXTURE0 - OpenGL.GL_TEXTURE0, this.Target);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public void Unbind()
        //{
        //    //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
        //    OpenGL.BindTexture(this.Target, 0);
        //}

        private bool initialized = false;
        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(this.ActiveTexture);
                OpenGL.GenTextures(1, id);
                OpenGL.BindTexture(this.Target, id[0]);
                this.SamplerBuilder.Bind(this.ActiveTexture - OpenGL.GL_TEXTURE0, this.Target);
                this.ImageBuilder.Build(this.Target);
                //this.SamplerBuilder.Unbind(OpenGL.GL_TEXTURE0 - OpenGL.GL_TEXTURE0, this.Target);
                OpenGL.BindTexture(this.Target, 0);
                this.initialized = true;
            }
        }

        /// <summary>
        /// setup texture's image data.
        /// </summary>
        public NewImageBuilder ImageBuilder { get; private set; }

        /// <summary>
        /// setup texture's sampler properties.
        /// </summary>
        public SamplerBase SamplerBuilder { get; private set; }

    }
}
