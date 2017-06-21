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
    class RenderToTextureRenderer : RendererBase, IRenderable
    {
        public RenderToTextureRenderer()
        {
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];
            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(width, height, GL.GL_RGB, GL.GL_RGB, GL.GL_UNSIGNED_BYTE),
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
            this.framebuffer = framebuffer;
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
            this.framebuffer.Bind();
            {
                GL.Instance.ClearColor(0.5f, 0.5f, 0.5f, 1);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                //this.sourceRenderer.RenderBeforeChildren(arg);
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            this.framebuffer.Unbind();
        }

        #endregion

        private Framebuffer framebuffer;

        public Texture BindingTexture { get; set; }

    }
}
