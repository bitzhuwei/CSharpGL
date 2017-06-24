using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render To Texture.
    /// This demonstracts how to render to texture.
    /// </summary>
    public class RTTRenderer : RendererBase, IRenderable, ITextureSource
    {
        /// <summary>
        /// Billboard's width(in pixels).
        /// </summary>
        public int Width
        {
            get { return (int)_width; }
            set { _width = (int)value; }
        }

        /// <summary>
        /// Billboard's height(in pixels).
        /// </summary>
        public int Height
        {
            get { return (int)_height; }
            set { _height = (int)value; }
        }

        /// <summary>
        /// Kepp this billboard in front of everything?
        /// </summary>
        public bool KeepFront { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TransparentBackground { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get { return this.helper.BindingTexture; } }

        public RTTRenderer(int width, int height, ICamera innerCamera)
        {
            this.Width = width;
            this.Height = height;
            this.Camera = innerCamera;

            this.helper = new RTTHelper();
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (this._width <= 0 || this._height <= 0) { return; }

            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            this.framebuffer = this.helper.GetFramebuffer(this.Width, this.Height);
            framebuffer.Bind();
            GL.Instance.Viewport(0, 0, this.Width, this.Height);
            {
                int[] value = new int[4];
                GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, value);
                {
                    vec3 color = this.BackgroundColor.ToVec3();
                    if (this.TransparentBackground)
                    {
                        GL.Instance.ClearColor(color.x, color.y, color.z, 0.0f);
                    }
                    else
                    {
                        GL.Instance.ClearColor(color.x, color.y, color.z, 1.0f);
                    }
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                }

                {
                    var args = new RenderEventArgs(this.Camera);
                    foreach (var item in this.Children)
                    {
                        RenderAction.Render(item, args);
                    }
                }

                GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
            }
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);
            this.framebuffer.Unbind();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        private Framebuffer framebuffer;
        private RTTHelper helper;
        private float _width;
        private float _height;
    }
}
