using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render children to framebuffer, then To Texture.
    /// </summary>
    public class RTTNode : SceneNodeBase, IRenderable, ITextureSource
    {
        /// <summary>
        /// Billboard's width(in pixels).
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Billboard's height(in pixels).
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Billboard's background color.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Camera used in rendering children.
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// Render children to framebuffer, then To Texture.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="innerCamera">Camera used in rendering children.</param>
        /// <param name="framebufferSource">Provides framebuffer.</param>
        public RTTNode(int width, int height, ICamera innerCamera, IFramebufferProvider framebufferSource)
        {
            this.Width = width;
            this.Height = height;
            this.Camera = innerCamera;

            this.framebufferSource = framebufferSource;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren;// not render children in Scene.Render().
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { } // nothing to do.
            //set { this.enableRendering = value; }
        }

        private PolygonOffsetFillState state = new PolygonOffsetFillState();

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (this.Width <= 0 || this.Height <= 0) { return; }

            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            this.framebuffer = this.framebufferSource.GetFramebuffer(this.Width, this.Height);
            framebuffer.Bind();
            GL.Instance.Viewport(0, 0, this.Width, this.Height);
            this.state.On();
            {
                int[] value = new int[4];
                GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, value);
                {
                    vec3 color = this.BackgroundColor.ToVec3();
                    GL.Instance.ClearColor(color.x, color.y, color.z, 0.0f); // 0.0f for alpha channel, in case that transparent background is needed.
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                }
                {
                    const bool firstPass = true, renderThis = true;
                    var args = new RenderEventArgs(this.Camera);
                    foreach (var item in this.Children)
                    {
                        RenderAction.Render(item, args, firstPass, renderThis);
                    }
                }
                {
                    GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);// recover clear color.
                }
            }
            this.state.Off();
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);// recover viewport.
            this.framebuffer.Unbind();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        private Framebuffer framebuffer;
        private IFramebufferProvider framebufferSource;

        #region ITextureSource 成员

        Texture ITextureSource.BindingTexture { get { return this.framebufferSource.BindingTexture; } }

        #endregion
    }
}
