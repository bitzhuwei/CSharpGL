using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe partial class Texture : IDisposable {
        /// <summary>
        /// 0 means GL.GL_TEXTURE0, 1 means GL.GL_TEXTURE1, ...
        /// </summary>
        public uint textureUnitIndex;

        /// <summary>
        /// binding target of this texture.
        /// </summary>
        public TextureTarget Target {
            get {
                var storage = this.Storage;
                if (storage == null) {
                    throw new Exception(string.Format("storage not specified for texture!"));
                }

                return storage.target;
            }
        }

        /// <summary>
        /// texture's id/name from glGenTextures().
        /// 纹理名（用于标识一个纹理，由OpenGL指定）。
        /// </summary>
        public readonly uint id;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="texParameters"></param>
        public Texture(TexStorageBase storage, params TexParameter[] texParameters)
            : this(storage, null, texParameters) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="mipmapBuilder"></param>
        /// <param name="texParameters"></param>
        public Texture(TexStorageBase storage, MipmapBuilder? mipmapBuilder, params TexParameter[] texParameters) {
            var ids = stackalloc GLuint[1];
            var gl = GL.current; if (gl != null) {
                gl.glGenTextures(1, ids);
            }
            this.id = ids[0];
            this.Storage = storage;
            this.mipmapBuilder = mipmapBuilder;
            this.builtInSampler.AddRange(texParameters);
        }

        /// <summary>
        ///
        /// </summary>
        public void Bind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindTexture((uint)this.Target, this.id);
        }

        /// <summary>
        ///
        /// </summary>
        public void Unbind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindTexture((uint)this.Target, 0);
        }

        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize() {
            var gl = GL.current; if (gl == null) { return; }
            if (!this.initialized) {
                TextureTarget target = this.Target;
                gl.glBindTexture((GLenum)target, this.id);

                this.builtInSampler.Apply(target);
                this.Storage.Apply();
                var mipmapBuilder = this.mipmapBuilder;
                if (mipmapBuilder != null) { mipmapBuilder.GenerateMipmmap((GLenum)target); }

                gl.glBindTexture((GLenum)target, 0);

                this.initialized = true;
            }
        }

        /// <summary>
        /// setup texture's image data.
        /// </summary>
        public TexStorageBase Storage { get; private set; }

        /// <summary>
        /// setup texture's sampler properties with default built-in sampler object.
        /// </summary>
        public readonly BuiltInSampler builtInSampler = new BuiltInSampler();

        private MipmapBuilder? mipmapBuilder;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Target:{0}, Id:{1}", this.Target, this.id);
        }
    }
}
