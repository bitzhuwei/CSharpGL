using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RenderToTexture {
    /// <summary>
    /// Render To Texture.
    /// contains a framebuffer.
    /// </summary>
    public class MultiTargetFramebufferProvider : IFramebufferProvider {
        private Framebuffer framebuffer;

        /// <summary>
        /// Gets a framebuffer with specified <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Framebuffer GetFramebuffer(int width, int height) {
            if (width <= 0) {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0) {
                throw new ArgumentOutOfRangeException("height");
            }

            if (this.framebuffer == null) {
                this.framebuffer = CreateFramebuffer(width, height);
            }
            else {
                if (this.framebuffer.width != width || this.framebuffer.height != height) {
                    this.framebuffer.Dispose();
                    this.framebuffer = CreateFramebuffer(width, height);
                }
            }

            return this.framebuffer;
        }


        private Framebuffer CreateFramebuffer(int width, int height) {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            for (uint location = 0; location < 4; location++) {
                var texture = new Texture(new TexImageBitmap(width, height),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.Initialize();
                framebuffer.Attach(Framebuffer.Target.Framebuffer, texture, location);
                this.outTextures[location] = texture;
            }
            {
                this.BindingTexture = this.outTextures[0];
            }
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, renderbuffer, AttachmentLocation.Depth);// special
            }
            //framebuffer.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + 1);// as in 1 in framebuffer.Attach(Framebuffer.Target.Framebuffer, texture, 1u);// 1
            framebuffer.SetDrawBuffers(
                GL.GL_COLOR_ATTACHMENT0, GL.GL_COLOR_ATTACHMENT0 + 1, GL.GL_COLOR_ATTACHMENT0 + 2, GL.GL_COLOR_ATTACHMENT0 + 3);
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get; set; }

        private Texture[] outTextures = new Texture[4];
        public Texture[] OutTextures { get { return this.outTextures; } }
    }
}
