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
    public class DepthFramebufferProvider : IFramebufferProvider
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
            //Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(width, height, GL.GL_RGBA);
            //Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(width, height, DepthComponentType.DepthComponent24);
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            //framebuffer.Attach(colorBuffer);//0
            this.BindingTexture = framebuffer.Attach(TextureAttachment.DepthAttachment);//1
            //framebuffer.Attach(depthBuffer);// special
            //framebuffer.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1);// as in 1 in framebuffer.Attach(texture);//1
            //framebuffer.SetDrawBuffers(GL.GL_NONE);
            framebuffer.SetDrawBuffer(GL.GL_NONE);
            framebuffer.SetReadBuffer(GL.GL_NONE);
            this.BindingTexture.Bind();
            framebuffer.CheckCompleteness();
            this.BindingTexture.Unbind();
            framebuffer.Unbind();
            return framebuffer;
        }

        public Texture BindingTexture { get; set; }
    }
}
