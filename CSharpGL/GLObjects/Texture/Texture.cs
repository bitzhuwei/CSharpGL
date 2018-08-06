using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Texture : IDisposable
    {
        /// <summary>
        /// 0 means GL.GL_TEXTURE0, 1 means GL.GL_TEXTURE1, ...
        /// </summary>
        public uint TextureUnitIndex { get; set; }

        /// <summary>
        /// binding target of this texture.
        /// </summary>
        public TextureTarget Target
        {
            get
            {
                var storage = this.Storage;
                if (storage == null)
                {
                    throw new Exception(string.Format("storage not specified for texture!"));
                }

                return storage.target;
            }
        }

        /// <summary>
        /// texture's id/name from glGenTextures().
        /// 纹理名（用于标识一个纹理，由OpenGL指定）。
        /// </summary>
        protected uint[] ids = new uint[1];

        /// <summary>
        /// texture's id/name from glGenTextures().
        /// 纹理名（用于标识一个纹理，由OpenGL指定）。
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="texParameters"></param>
        public Texture(TexStorageBase storage, params TexParameter[] texParameters)
        {
            this.Storage = storage;
            this.builtInSampler.AddRange(texParameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="mipmapBuilder"></param>
        /// <param name="texParameters"></param>
        public Texture(TexStorageBase storage, MipmapBuilder mipmapBuilder, params TexParameter[] texParameters)
        {
            this.Storage = storage;
            this.mipmapBuilder = mipmapBuilder;
            this.builtInSampler.AddRange(texParameters);
        }

        /// <summary>
        ///
        /// </summary>
        public void Bind()
        {
            GL.Instance.BindTexture((uint)this.Target, this.Id);
        }

        /// <summary>
        ///
        /// </summary>
        public void Unbind()
        {
            GL.Instance.BindTexture((uint)this.Target, 0);
        }

        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                GL.Instance.GenTextures(1, ids);
                TextureTarget target = this.Target;
                GL.Instance.BindTexture((uint)target, ids[0]);

                this.builtInSampler.Apply(target);
                this.Storage.Apply();
                MipmapBuilder mipmapBuilder = this.mipmapBuilder;
                if (mipmapBuilder != null) { mipmapBuilder.GenerateMipmmap((uint)target); }

                GL.Instance.BindTexture((uint)target, 0);

                this.initialized = true;
            }
        }

        /// <summary>
        /// setup texture's image data.
        /// </summary>
        public TexStorageBase Storage { get; private set; }

        private BuiltInSampler builtInSampler = new BuiltInSampler();

        /// <summary>
        /// setup texture's sampler properties with default built-in sampler object.
        /// </summary>
        public BuiltInSampler BuiltInSampler
        {
            get { return builtInSampler; }
        }

        private MipmapBuilder mipmapBuilder;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Target:{0}, Id:{1}", this.Target, this.Id);
        }
    }
}
