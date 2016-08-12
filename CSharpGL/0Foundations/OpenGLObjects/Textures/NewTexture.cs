using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// base type of all textures.
    /// </summary>
    public partial class NewTexture : IDisposable
    {
        /// <summary>
        /// OpenGL.GL_TEXTURE0 etc.
        /// </summary>
        public uint ActiveTexture { get; set; }

        /// <summary>
        /// OpenGL.GL_TEXTURE_2D etc.
        /// </summary>
        public BindTextureTarget Target { get; set; }

        /// <summary>
        /// texture's id.
        /// </summary>
        protected uint[] id = new uint[1];

        /// <summary>
        /// 纹理名（用于标识一个纹理，由OpenGL指定），可在shader中用于指定uniform sampler2D纹理变量。
        /// </summary>
        public uint Id { get { return this.id[0]; } }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            OpenGL.BindTexture(this.Target, this.id[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind()
        {
            //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            OpenGL.BindTexture(this.Target, 0);
        }

        private bool initialized = false;
        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(OpenGL.GL_TEXTURE0);
                OpenGL.GenTextures(1, id);
                OpenGL.BindTexture(this.Target, id[0]);
                this.SamplerBuilder.Build(this.Target);
                this.ImageBuilder.Build(this.Target);
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
        public NewSamplerBase SamplerBuilder { get; private set; }

    }
}
