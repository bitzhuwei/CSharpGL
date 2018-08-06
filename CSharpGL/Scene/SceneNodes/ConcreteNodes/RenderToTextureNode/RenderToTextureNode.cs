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
    public class RenderToTextureNode : SceneNodeBase, IRenderable, ITextureSource
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
        public RenderToTextureNode(int width, int height, ICamera innerCamera, IFramebufferProvider framebufferSource)
        {
            this.Width = width;
            this.Height = height;
            this.Camera = innerCamera;

            this.framebufferSource = framebufferSource;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { } // nothing to do.
            //set { this.enableRendering = value; }
        }

        private PolygonOffsetFillSwitch polygonFillOffset = new PolygonOffsetFillSwitch();

        int[] viewport = new int[4];
        int[] colorClearValue = new int[4];
        ICamera originalCamera;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (this.Width <= 0 || this.Height <= 0) { return; }

            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            this.framebuffer = this.framebufferSource.GetFramebuffer(this.Width, this.Height);
            framebuffer.Bind();
            GL.Instance.Viewport(0, 0, this.Width, this.Height);
            this.polygonFillOffset.On();
            //{
            GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, colorClearValue);
            {
                vec3 color = this.BackgroundColor.ToVec3();
                GL.Instance.ClearColor(color.x, color.y, color.z, 0.0f); // 0.0f for alpha channel, in case that transparent background is needed.
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                this.originalCamera = arg.Camera;
                arg.Camera = this.Camera;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
            arg.Camera = this.originalCamera;
            GL.Instance.ClearColor(colorClearValue[0], colorClearValue[1], colorClearValue[2], colorClearValue[3]);// recover clear color.
            this.polygonFillOffset.Off();
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);// recover viewport.
            this.framebuffer.Unbind();
        }

        #endregion

        private Framebuffer framebuffer;
        private IFramebufferProvider framebufferSource;

        #region ITextureSource 成员

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get { return this.framebufferSource.BindingTexture; } }

        #endregion
    }
}
