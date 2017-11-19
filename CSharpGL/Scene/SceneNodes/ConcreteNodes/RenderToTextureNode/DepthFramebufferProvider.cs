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
            //this.BindingTexture = framebuffer.Attach(TextureAttachment.DepthAttachment);//1
            var texture = new Texture(new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_DEPTH_COMPONENT32, width, height, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT),
                // 设置默认滤波模式
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                // 设置深度比较模式
                new TexParameteri(TexParameter.PropertyName.TextureCompareMode, (int)GL.GL_COMPARE_REF_TO_TEXTURE),
                new TexParameteri(TexParameter.PropertyName.TextureCompareFunc, (int)GL.GL_LEQUAL),
                // 设置边界截取模式
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();
            framebuffer.Attach(FramebufferTarget.Framebuffer, texture, AttachmentLocation.Depth);
            this.BindingTexture = texture;

            //framebuffer.Attach(depthBuffer);// special
            //framebuffer.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1);// as in 1 in framebuffer.Attach(texture);//1
            //framebuffer.SetDrawBuffers(GL.GL_NONE);
            framebuffer.SetDrawBuffer(GL.GL_NONE);
            //framebuffer.SetReadBuffer(GL.GL_NONE);
            this.BindingTexture.Bind();
            framebuffer.CheckCompleteness();
            this.BindingTexture.Unbind();
            framebuffer.Unbind();
            return framebuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get; set; }
    }
}
