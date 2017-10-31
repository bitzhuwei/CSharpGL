using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    partial class PeelingNode
    {
        private PeelingResource resources;
        private Query query;


    }

    class PeelingResource
    {
        public readonly int width;
        public readonly int height;

        public readonly Framebuffer[] framebuffers = new Framebuffer[2];
        public readonly Texture[] colorAttachments = new Texture[2];
        public readonly Texture[] depthAttachments = new Texture[2];

        public readonly Framebuffer colorBlenderFramebuffer;
        public readonly Texture colorBlenderColorAttachment;

        public PeelingResource(int width, int height)
        {
            this.width = width;
            this.height = height;

            for (int i = 0; i < 2; i++)
            {
                var depthStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_DEPTH_COMPONENT32, 1, 0, width, height, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT);
                var depthTexture = new Texture(TextureTarget.TextureRectangle, depthStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                depthTexture.Initialize();

                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, 1, 0, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(TextureTarget.TextureRectangle, colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();

                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(depthTexture, true);
                framebuffer.Attach(colorTexture, false);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.framebuffers[i] = framebuffer;
                this.colorAttachments[i] = colorTexture;
                this.depthAttachments[i] = depthTexture;
            }

            {
                var colorStorage = new TexImage2D(TexImage2D.Target.TextureRectangle, GL.GL_RGBA, 1, 0, width, height, GL.GL_RGBA, GL.GL_FLOAT);
                var colorTexture = new Texture(TextureTarget.TextureRectangle, colorStorage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST)
                    );
                colorTexture.Initialize();

                var framebuffer = new Framebuffer(width, height);
                framebuffer.Bind();

                framebuffer.Attach(this.depthAttachments[0], true);
                framebuffer.Attach(colorTexture, false);

                framebuffer.CheckCompleteness();
                framebuffer.Unbind();

                this.colorBlenderFramebuffer = framebuffer;
                this.colorBlenderColorAttachment = colorTexture;
            }
        }

        internal void Dispose()
        {
            foreach (var item in this.framebuffers)
            {
                item.Dispose();
            }

            {
                this.colorBlenderFramebuffer.Dispose();
            }
        }
    }
}
