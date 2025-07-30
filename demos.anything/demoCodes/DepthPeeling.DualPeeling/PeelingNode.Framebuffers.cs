using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling {
    class PeelingResource {
        public readonly int width;
        public readonly int height;

        /// <summary>
        /// 
        /// </summary>
        public readonly Framebuffer backBlenderFBO;
        public readonly Texture backBlenderTexture;
        /// <summary>
        /// color attachments:d f b d f b backBlenderTexture.
        /// </summary>
        public readonly Framebuffer peelingSingleFBO;
        public readonly Texture[] depthTextures = new Texture[2];
        public readonly Texture[] frontBlenderTextures = new Texture[2];
        public readonly Texture[] backTmpTextures = new Texture[2];


        // TODO: what is this?
        /// <summary>
        /// 
        /// </summary>
        private const uint GL_FLOAT_RG32_NV = 0x8887;
        public PeelingResource(int width, int height) {
            this.width = width;
            this.height = height;

            uint nextUnit = 0;

            // backBlenderTexture.
            {
                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGB, width, height, GL.GL_RGB, GL.GL_FLOAT);
                var colorTexture = new Texture(colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();
                colorTexture.textureUnitIndex = nextUnit++;
                this.backBlenderTexture = colorTexture;
            }
            // backBlenderFBO.
            {
                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.backBlenderTexture, 0u);
                //var depthBuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                //framebuffer.Attach(FramebufferTarget.Framebuffer, depthBuffer, AttachmentLocation.Depth);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.backBlenderFBO = framebuffer;
            }

            // depthTextures.
            for (int i = 0; i < 2; i++) {
                // TODO: is GL_FLOAT_RG32_NV same with GL_RG32F ?
                //var depthStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL_FLOAT_RG32_NV, width, height, GL.GL_RGB, GL.GL_FLOAT);
                var depthStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RG32F, width, height, GL.GL_RGB, GL.GL_FLOAT);
                var depthTexture = new Texture(depthStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                depthTexture.Initialize();
                depthTexture.textureUnitIndex = nextUnit++;
                this.depthTextures[i] = depthTexture;
            }
            // frontBlenderTextures.
            for (int i = 0; i < 2; i++) {
                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();
                colorTexture.textureUnitIndex = nextUnit++;
                this.frontBlenderTextures[i] = colorTexture;
            }
            // backTmpTextures.
            for (int i = 0; i < 2; i++) {
                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();
                colorTexture.textureUnitIndex = nextUnit++;
                this.backTmpTextures[i] = colorTexture;
            }
            // peelingSingleFBO.
            {
                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.depthTextures[0], 0u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.frontBlenderTextures[0], 1u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.backTmpTextures[0], 2u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.depthTextures[1], 3u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.frontBlenderTextures[1], 4u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.backTmpTextures[1], 5u);
                framebuffer.Attach(Framebuffer.Target.Framebuffer, this.backBlenderTexture, 6u);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.peelingSingleFBO = framebuffer;
            }
        }

        internal void Dispose() {
            //foreach (var item in this.FBOs)
            //{
            //    item.Dispose();
            //}

            //{
            //    this.blenderFBO.Dispose();
            //}
        }
    }
}
