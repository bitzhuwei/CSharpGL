using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render To Texture.
    /// contains a framebuffer.
    /// </summary>
    public class ColoredFramebufferProvider : IFramebufferSource
    {
        private Framebuffer framebuffer;

        /// <summary>
        /// Gets a framebuffer with specified <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Framebuffer GetFramebuffer(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            if (this.framebuffer == null)
            {
                this.framebuffer = CreateFramebuffer(width, height);
            }
            else
            {
                if (this.framebuffer.Width != width || this.framebuffer.Height != height)
                {
                    this.framebuffer.Dispose();
                    this.framebuffer = CreateFramebuffer(width, height);
                }
            }

            return this.framebuffer;
        }


        private Framebuffer CreateFramebuffer(int width, int height)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            Renderbuffer colorbuffer = framebuffer.Attach(RenderbufferType.ColorBuffer);//0
            Texture texture = framebuffer.Attach(TextureAttachment.ColorAttachment);//1A
            Renderbuffer depthbuffer = framebuffer.Attach(RenderbufferType.DepthBuffer);// special
            framebuffer.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1);// as in 1 in framebuffer.Attach(texture);//1
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            this.BindingTexture = texture;

            return framebuffer;
        }

        public Texture BindingTexture { get; set; }
    }
}
