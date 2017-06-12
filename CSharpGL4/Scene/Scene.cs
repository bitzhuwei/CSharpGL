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
    public class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SceneElementBase RootElement { get; set; }

        private vec3 clearColor = new vec3(0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public Color ClearColor
        {
            get { return clearColor.ToColor(); }
            set { this.clearColor = value.ToVec3(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, 1.0f);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var args = new RenderEventArgs(this);
            this.Render(this.RootElement, args);
        }

        private void Render(SceneElementBase sceneElement, RenderEventArgs args)
        {
            sceneElement.Render(args);
            foreach (var item in sceneElement.Children)
            {
                item.Render(args);
            }
        }

        private Framebuffer pickFramebuffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="pickingGeometry"></param>
        /// <returns></returns>
        public SceneElementBase Pick(Point position, PickingGeometryType pickingGeometry)
        {
            Framebuffer framebuffer = GetPickFramebuffer();
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var args = new PickEventArgs(this, position, pickingGeometry);
                this.RenderForPicking(this.RootElement, args);

                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(position.X, position.Y);

            }
            framebuffer.Unbind();

            throw new NotImplementedException();
        }

        private Framebuffer GetPickFramebuffer()
        {
            Framebuffer framebuffer = this.pickFramebuffer;
            if (framebuffer == null)
            {
                this.pickFramebuffer = CreatePickFramebuffer(this.Canvas.Width, this.Canvas.Height);
            }
            else if (framebuffer.Width != this.Canvas.Width
                || framebuffer.Height != this.Canvas.Height)
            {
                framebuffer.Dispose();
                this.pickFramebuffer = CreatePickFramebuffer(this.Canvas.Width, this.Canvas.Height);
            }

            return this.pickFramebuffer;
        }

        private Framebuffer CreatePickFramebuffer(int width, int height)
        {
            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(width, height, GL.GL_RGBA);
            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(width, height, DepthComponentType.DepthComponent24);
            var framebuffer = new Framebuffer();
            framebuffer.Bind();
            framebuffer.Attach(colorBuffer);
            framebuffer.Attach(depthBuffer);

            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        private void RenderForPicking(SceneElementBase sceneElement, PickEventArgs args)
        {
            sceneElement.RenderForPicking(args);
            foreach (var item in sceneElement.Children)
            {
                item.RenderForPicking(args);
            }
        }


        //public void Write(Stream stream)
        //{

        //}
    }
}