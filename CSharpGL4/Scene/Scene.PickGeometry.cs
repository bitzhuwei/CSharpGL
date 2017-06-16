using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {
        private Framebuffer pickingFramebuffer;

        /// <summary>
        /// Pick geometry at specified positon.
        /// </summary>
        /// <param name="x">Left Down is (0, 0)</param>
        /// <param name="y">Left Down is (0, 0)</param>
        /// <param name="geometryType"></param>
        /// <returns></returns>
        public PickedGeometry Pick(int x, int y, PickingGeometryType geometryType)
        {
            PickedGeometry pickedGeometry = null;

            Framebuffer framebuffer = GetPickingFramebuffer();
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var arg = new PickEventArgs(this, x, y, geometryType);
                this.RenderForPicking(this.RootElement, arg);

                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(x, y);

                pickedGeometry = Pick(stageVertexId, arg, this.RootElement);
            }
            framebuffer.Unbind();

            return pickedGeometry;
        }

        private PickedGeometry Pick(uint stageVertexId, PickEventArgs arg, RendererBase renderer)
        {
            PickedGeometry pickedGeometry = null;
            if (renderer != null)
            {
                var pickable = renderer as IPickable;
                if (pickable != null)
                {
                    pickedGeometry = pickable.GetPickedGeometry(arg, stageVertexId);
                }

                if (pickedGeometry == null)
                {
                    var node = renderer as ITreeNode;
                    if (node != null)
                    {
                        foreach (var item in node.Children)
                        {
                            pickedGeometry = Pick(stageVertexId, arg, item as RendererBase);
                            if (pickedGeometry != null)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return pickedGeometry;
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

        private void RenderForPicking(RendererBase sceneElement, PickEventArgs arg)
        {
            if (sceneElement != null)
            {
                var pickable = sceneElement as IPickable;
                if (pickable != null)
                {
                    pickable.RenderForPicking(arg);
                }

                var node = sceneElement as ITreeNode;
                if (node != null)
                {
                    foreach (var item in node.Children)
                    {
                        this.RenderForPicking(item as RendererBase, arg);
                    }
                }
            }
        }

    }
}