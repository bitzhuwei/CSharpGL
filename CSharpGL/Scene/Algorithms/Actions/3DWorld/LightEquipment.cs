using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LightEquipment : ITextureSource
    {
        private readonly IFramebufferProvider framebufferProvider = new DepthFramebufferProvider();
        private readonly PolygonOffsetFillState state = new PolygonOffsetFillState(false);// TODO: other offsets also needed?
        //private readonly int[] viewport = new int[4];
        private int width;
        private int height;

        /// <summary>
        /// bind framebuffer, setup viewport, polygon-offset and so on.
        /// </summary>
        public void Begin(Viewport viewport)
        {
            this.width = viewport.width; this.height = viewport.height;
            var framebuffer = this.framebufferProvider.GetFramebuffer(this.width, this.height);

            framebuffer.Bind();
            GL.Instance.Viewport(0, 0, this.width, this.height);
            this.state.On();
            {
                GL.Instance.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);// white color means farest position.
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                //{
                //    var args = new RenderEventArgs(this.Camera);
                //    foreach (var item in this.Children)
                //    {
                //        RenderAction.Render(item, args, true, true);
                //    }
                //}
            }
        }

        /// <summary>
        /// unbind framebuffer, reset viewport, polygon-offset and so on.
        /// </summary>
        public void End()
        {
            int width = this.width, height = this.height;
            var framebuffer = this.framebufferProvider.GetFramebuffer(width, height);

            this.state.Off();
            GL.Instance.Viewport(0, 0, width, height);// recover viewport.
            framebuffer.Unbind();
        }

        #region ITextureSource 成员

        /// <summary>
        /// The texture that records shadow caused by some light.
        /// </summary>
        public Texture BindingTexture
        {
            get { return this.framebufferProvider.BindingTexture; }
        }

        #endregion
    }
}
