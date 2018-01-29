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
    public class LightEquipment
    {
        private readonly IFramebufferProvider framebufferProvider = new DepthFramebufferProvider();
        private readonly PolygonOffsetFillState state = new PolygonOffsetFillState(false);// TODO: other offsets also needed?
        private readonly int[] viewport = new int[4];

        /// <summary>
        /// bind framebuffer, setup viewport, polygon-offset and so on.
        /// </summary>
        public void Begin()
        {
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];
            var framebuffer = this.framebufferProvider.GetFramebuffer(width, height);

            framebuffer.Bind();
            GL.Instance.Viewport(0, 0, width, height);
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
            int width = viewport[2], height = viewport[3];
            var framebuffer = this.framebufferProvider.GetFramebuffer(width, height);

            this.state.Off();
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);// recover viewport.
            framebuffer.Unbind();
        }

        /// <summary>
        /// The texture that records shadow caused by some light.
        /// </summary>
        public Texture ShadowMap { get { return this.framebufferProvider.BindingTexture; } }
    }
}
