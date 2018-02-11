using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling
{
    class PeelingResource
    {
        public readonly int width;
        public readonly int height;

        public readonly Framebuffer[] FBOs = new Framebuffer[2];
        public readonly Texture[] colorTextures = new Texture[2];
        public readonly Texture[] depthTextures = new Texture[2];

        public readonly Framebuffer blenderFBO;
        public readonly Texture blenderColorTexture;

        public PeelingResource(int width, int height)
        {
            this.width = width;
            this.height = height;

            for (int i = 0; i < 2; i++)
            {
                var depthStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_DEPTH_COMPONENT32F, width, height, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT);
                var depthTexture = new Texture(depthStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                depthTexture.Initialize();

                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();

                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(FramebufferTarget.Framebuffer, depthTexture, AttachmentLocation.Depth);
                framebuffer.Attach(FramebufferTarget.Framebuffer, colorTexture, 0u);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.FBOs[i] = framebuffer;
                this.colorTextures[i] = colorTexture;
                this.depthTextures[i] = depthTexture;
            }

            {
                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();

                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(FramebufferTarget.Framebuffer, this.depthTextures[0], AttachmentLocation.Depth);
                framebuffer.Attach(FramebufferTarget.Framebuffer, colorTexture, 0u);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.blenderFBO = framebuffer;
                this.blenderColorTexture = colorTexture;
            }
        }

        internal void Dispose()
        {
            foreach (var item in this.FBOs)
            {
                item.Dispose();
            }

            {
                this.blenderFBO.Dispose();
            }
        }
    }
}
