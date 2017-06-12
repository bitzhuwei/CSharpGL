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
        public RendererBase RootElement { get; set; }

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

            var arg = new RenderEventArgs(this);
            this.Render(this.RootElement as IRenderable, arg);
        }

        private void Render(IRenderable sceneElement, RenderEventArgs arg)
        {
            if (sceneElement != null)
            {
                sceneElement.Render(arg);

                var node = sceneElement as ITreeNode<RendererBase>;
                if (node != null)
                {
                    foreach (var item in node.Children)
                    {
                        this.Render(item as IRenderable, arg);
                    }
                }
            }
        }

        private Framebuffer pickingFramebuffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="geometryType"></param>
        /// <returns></returns>
        public RendererBase Pick(Point position, PickingGeometryType geometryType)
        {
            Framebuffer framebuffer = GetPickingFramebuffer();
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var arg = new PickEventArgs(this, position, geometryType);
                this.RenderForPicking(this.RootElement as IPickable, arg);

                //uint stageVertexId = ColorCodedPicking.ReadStageVertexId(position.X, position.Y);

            }
            framebuffer.Unbind();

            throw new NotImplementedException();
        }

        private Framebuffer GetPickingFramebuffer()
        {
            Framebuffer framebuffer = this.pickingFramebuffer;

            if (framebuffer == null)
            {
                this.pickingFramebuffer = CreatePickFramebuffer(this.Canvas.Width, this.Canvas.Height);
            }
            else if (framebuffer.Width != this.Canvas.Width
                || framebuffer.Height != this.Canvas.Height)
            {
                framebuffer.Dispose();
                this.pickingFramebuffer = CreatePickFramebuffer(this.Canvas.Width, this.Canvas.Height);
            }

            return this.pickingFramebuffer;
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

        private void RenderForPicking(IPickable sceneElement, PickEventArgs arg)
        {
            if (sceneElement != null)
            {
                sceneElement.RenderForPicking(arg);
                var node = sceneElement as ITreeNode<RendererBase>;
                if (node != null)
                {
                    foreach (var item in node.Children)
                    {
                        this.RenderForPicking(item as IPickable, arg);
                    }
                }
            }
        }

    }
}