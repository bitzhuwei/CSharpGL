using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PickingAction : ActionBase
    {
        private Framebuffer pickingFramebuffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        public PickingAction(Scene scene) : base(scene) { }

        /// <summary>
        /// Pick geometry at specified positon.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pickTriangle"></param>
        /// <param name="pickQuad"></param>
        /// <param name="pickPolygon"></param>
        /// <returns></returns>
        public PickedGeometry Pick(int x, int y, bool pickTriangle, bool pickQuad, bool pickPolygon)
        {
            PickingGeometryTypes geometryTypes = 0;
            if (pickTriangle) { geometryTypes |= PickingGeometryTypes.Triangle; }
            if (pickQuad) { geometryTypes |= PickingGeometryTypes.Quad; }
            if (pickPolygon) { geometryTypes |= PickingGeometryTypes.Polygon; }
            if (geometryTypes == 0) { return null; }

            PickedGeometry pickedGeometry = null;

            Framebuffer framebuffer = GetPickingFramebuffer();
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var arg = new PickingEventArgs(this.Scene, x, y, geometryTypes);
                this.RenderForPicking(this.Scene.RootElement, arg);

                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(x, y);

                pickedGeometry = Pick(stageVertexId, arg, this.Scene.RootElement);

                if (pickedGeometry != null)
                {
                    var depth = new float[1];
                    GCHandle pinned = GCHandle.Alloc(depth, GCHandleType.Pinned);
                    IntPtr header = pinned.AddrOfPinnedObject();
                    // same with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
                    GL.Instance.ReadPixels(x, y, 1, 1, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT, header);
                    pinned.Free();

                    pickedGeometry.PickedPosition = new vec3(x, y, depth[0]);
                }
            }
            framebuffer.Unbind();

            return pickedGeometry;
        }

        /// <summary>
        /// Pick geometry at specified positon.
        /// </summary>
        /// <param name="x">Left Down is (0, 0)</param>
        /// <param name="y">Left Down is (0, 0)</param>
        /// <param name="geometryType"></param>
        /// <returns></returns>
        public PickedGeometry Pick(int x, int y, GeometryType geometryType)
        {
            PickedGeometry pickedGeometry = null;

            Framebuffer framebuffer = GetPickingFramebuffer();
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var arg = new PickingEventArgs(this.Scene, x, y, geometryType.ToFlags());
                this.RenderForPicking(this.Scene.RootElement, arg);

                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(x, y);

                pickedGeometry = Pick(stageVertexId, arg, this.Scene.RootElement);
            }
            framebuffer.Unbind();

            return pickedGeometry;
        }

        private PickedGeometry Pick(uint stageVertexId, PickingEventArgs arg, SceneNodeBase node)
        {
            PickedGeometry pickedGeometry = null;
            if (node != null)
            {
                var pickable = node as IPickable;
                if (pickable != null)
                {
                    pickedGeometry = pickable.GetPickedGeometry(arg, stageVertexId);
                }

                if (pickedGeometry == null)
                {
                    foreach (var item in node.Children)
                    {
                        pickedGeometry = Pick(stageVertexId, arg, item);
                        if (pickedGeometry != null)
                        {
                            break;
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
                this.pickingFramebuffer = CreatePickFramebuffer(this.Scene.Canvas.Width, this.Scene.Canvas.Height);
            }
            else if (framebuffer.Width != this.Scene.Canvas.Width
                || framebuffer.Height != this.Scene.Canvas.Height)
            {
                framebuffer.Dispose();
                this.pickingFramebuffer = CreatePickFramebuffer(this.Scene.Canvas.Width, this.Scene.Canvas.Height);
            }

            return this.pickingFramebuffer;
        }

        private Framebuffer CreatePickFramebuffer(int width, int height)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_RGBA, RenderbufferType.ColorBuffer);
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, 0u);// 0
            }
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24, RenderbufferType.DepthBuffer);
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, AttachmentLocation.Depth);// special
            }
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        private void RenderForPicking(SceneNodeBase sceneElement, PickingEventArgs arg)
        {
            if (sceneElement != null)
            {
                var pickable = sceneElement as IPickable;
                TwoFlags flags = (pickable != null) ? pickable.EnablePicking : TwoFlags.None;
                bool before = (pickable != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (pickable == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    pickable.PickingBaseId += arg.RenderedVertexCount;
                    pickable.RenderForPicking(arg);
                    arg.RenderedVertexCount += pickable.GetVertexCount();
                }

                if (children)
                {
                    foreach (var item in sceneElement.Children)
                    {
                        this.RenderForPicking(item, arg);
                    }
                }
            }
        }

    }
}