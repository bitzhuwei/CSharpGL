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
    public class Picking
    {
        private Framebuffer pickingFramebuffer;

        /// <summary>
        /// 
        /// </summary>
        public Scene Scene { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        public Picking(Scene scene) { this.Scene = scene; }


        /// <summary>
        /// Pick geometry at specified positon.
        /// </summary>
        /// <param name="x">Left Down is (0, 0)</param>
        /// <param name="y">Left Down is (0, 0)</param>
        /// <param name="geometryType"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public PickedGeometry Pick(int x, int y, GeometryType geometryType, int width, int height)
        {
            return Pick(x, y, geometryType.ToFlags(), width, height);
        }

        /// <summary>
        /// Pick geometry at specified positon.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="geometryTypes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public PickedGeometry Pick(int x, int y, PickingGeometryTypes geometryTypes, int width, int height)
        {
            if (x < 0 || width <= x) { return null; }
            if (y < 0 || height <= y) { return null; }
            if (geometryTypes == 0) { return null; }

            PickedGeometry pickedGeometry = null;

            Framebuffer framebuffer = GetPickingFramebuffer(width, height);
            framebuffer.Bind();
            {
                const float one = 1.0f;
                GL.Instance.ClearColor(one, one, one, one);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var arg = new PickingEventArgs(this.Scene, x, y, geometryTypes);
                this.RenderForPicking(this.Scene.RootNode, arg);

                bool dump = false;
                if (dump)
                {
                    var final = new Bitmap(width, height);
                    var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //glGetTexImage((uint)texture.Target, 0, GL_BGRA, GL_UNSIGNED_BYTE, data.Scan0);
                    GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
                    final.UnlockBits(data);
                    final.RotateFlip(RotateFlipType.Rotate180FlipX);
                    final.Save(string.Format("picking.dump.png"));
                }

                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(x, y);

                pickedGeometry = SearchGeometry(stageVertexId, arg, this.Scene.RootNode);

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

        private PickedGeometry SearchGeometry(uint stageVertexId, PickingEventArgs arg, SceneNodeBase node)
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
                        pickedGeometry = SearchGeometry(stageVertexId, arg, item);
                        if (pickedGeometry != null)
                        {
                            break;
                        }
                    }
                }
            }

            return pickedGeometry;
        }

        private Framebuffer GetPickingFramebuffer(int width, int height)
        {
            Framebuffer framebuffer = this.pickingFramebuffer;

            if (framebuffer == null)
            {
                this.pickingFramebuffer = CreatePickFramebuffer(width, height);
            }
            else if (framebuffer.Width != width
                || framebuffer.Height != height)
            {
                framebuffer.Dispose();
                this.pickingFramebuffer = CreatePickFramebuffer(width, height);
            }

            return this.pickingFramebuffer;
        }

        private Framebuffer CreatePickFramebuffer(int width, int height)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_RGBA);
                // attach the renderbufer as first color buffer attachment.
                const uint colorAttachmentLocation = 0;
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, colorAttachmentLocation);
            }
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
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
                bool before = ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
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