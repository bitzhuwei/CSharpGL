using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class DeferredShadingNode : SceneNodeBase, IRenderable, ITextureSource
    {
        private Framebuffer framebuffer;
        private Texture texture;
        private int width;
        private int height;

        #region IRenderable 成员

        public ThreeFlags EnableRendering
        {
            get
            {
                return ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
            }
            set
            {
            }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv(GL.GL_VIEWPORT, viewport);

            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            this.framebuffer.Bind();
            {
                //const float one = 1.0f;
                //GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            framebuffer.Unbind();
        }

        #endregion

        private void Resize(int width, int height)
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
        }

        private Framebuffer CreateFramebuffer(int width, int height)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            {
                var texture = new Texture(new TexImageBitmap(width, height),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.Initialize();
                framebuffer.Attach(FramebufferTarget.Framebuffer, texture, 0u);// 0
                this.texture = texture;
            }
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, AttachmentLocation.Depth);// special
            }
            framebuffer.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0);// as in 0 in framebuffer.Attach(FramebufferTarget.Framebuffer, texture, 0u);// 0
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        #region ITextureSource 成员

        public Texture BindingTexture
        {
            get { return this.texture; }
        }

        #endregion
    }
}
