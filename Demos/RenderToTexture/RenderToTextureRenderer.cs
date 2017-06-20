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
        public RenderToTextureRenderer(IRenderable source)
        {
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];
            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(width, height, GL.GL_RGBA, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE),
                new SamplerParameters(
                    TextureWrapping.Repeat,
                    TextureWrapping.Repeat,
                    TextureWrapping.Repeat,
                    TextureFilter.Linear,
                    TextureFilter.Linear));
            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(width, height, GL.GL_RGBA);
            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(width, height, DepthComponentType.DepthComponent24);
            var framebuffer = new Framebuffer();
            framebuffer.Bind();
            framebuffer.Attach(colorBuffer);
            framebuffer.Attach(depthBuffer);
            framebuffer.Attach(texture);
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            this.sourceRenderer = source;
            this.sourceRenderer.RenderingEnabled = false;
            this.Children.Add(source as RendererBase);

            this.rectangle = new LegacyRectangleRenderer();
            this.rectangle.BindingTexture = texture;
            this.Children.Add(rectangle);
        }

        #region IRenderable 成员

        public bool renderingEnabled = true;
        public bool RenderingEnabled
        {
            get { return this.renderingEnabled; }
            set { this.renderingEnabled = value; }
        }

        public void Render(RenderEventArgs arg)
        {
            this.framebuffer.Bind();
            this.sourceRenderer.Render(arg);
            this.framebuffer.Unbind();
        }

        #endregion

        private Framebuffer framebuffer;
        private IRenderable sourceRenderer;
        private LegacyRectangleRenderer rectangle;

    }
}
