using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderToTexture
{
    /// <summary>
    /// This demonstracts how to render to texture.
    /// </summary>
    class RenderToTextureRenderer : RendererBase, IRenderable, ITextureSource
    {
        public RenderToTextureRenderer()
        {
            this.RenderBackground = true;

            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];

            this.framebuffer = this.CreateFramebuffer(width, height);
        }

        #region IRenderable 成员

        public bool renderingEnabled = true;
        public bool RenderingEnabled
        {
            get { return this.renderingEnabled; }
            set { this.renderingEnabled = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            Framebuffer framebuffer = this.GetFramebuffer();
            framebuffer.Bind();
            {
                if (this.RenderBackground)
                {
                    GL.Instance.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
                }
                else
                {
                    GL.Instance.ClearColor(0.5f, 0.5f, 0.5f, 0.0f);
                }

                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                // objects will be rendered in this.Children
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            Framebuffer framebuffer = this.GetFramebuffer();
            framebuffer.Unbind();
        }

        #endregion

        private Framebuffer framebuffer;

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RenderBackground { get; set; }

        private Framebuffer GetFramebuffer()
        {
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];

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
            var texture = new Texture(TextureTarget.Texture2D,
            new NullImageFiller(width, height, GL.GL_RGBA, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE),
            new SamplerParameters(
                TextureWrapping.Repeat,
                TextureWrapping.Repeat,
                TextureWrapping.Repeat,
                TextureFilter.Linear,
                TextureFilter.Linear));
            texture.Initialize();
            this.BindingTexture = texture;
            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(width, height, GL.GL_RGBA);
            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(width, height, DepthComponentType.DepthComponent24);
            var framebuffer = new Framebuffer();
            framebuffer.Bind();
            framebuffer.Attach(colorBuffer);//0
            framebuffer.Attach(texture);//1
            framebuffer.Attach(depthBuffer);// special
            framebuffer.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1);// as in 1 in framebuffer.Attach(texture);//1
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();
            return framebuffer;
        }
    }
}
