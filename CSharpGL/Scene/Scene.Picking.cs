using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        /// <summary>
        /// Get geometry at specified <paramref name="mousePosition"/> with specified <paramref name="pickingGeometryType"/>.
        /// <para>Returns null when <paramref name="mousePosition"/> is out of this scene's area or there's no active(visible and enabled) viewport.</para>
        /// </summary>
        /// <param name="mousePosition">mouse position in Windows coordinate system.(Left Up is (0, 0))</param>
        /// <param name="pickingGeometryType">target's geometry type.</param>
        /// <returns></returns>
        public List<Tuple<Point, PickedGeometry>> Pick(Point mousePosition, PickingGeometryType pickingGeometryType)
        {
            Rectangle clientRectangle = this.Canvas.ClientRectangle;
            // if mouse is out of window's area, nothing picked.
            if (mousePosition.X < 0 || clientRectangle.Width <= mousePosition.X || mousePosition.Y < 0 || clientRectangle.Height <= mousePosition.Y) { return null; }
            List<Tuple<Point, PickedGeometry>> allPickedGeometrys = null;
            lock (this.synObj)
            {
                int x = mousePosition.X;
                int y = clientRectangle.Height - mousePosition.Y - 1;
                // now (x, y) is in OpenGL's window cooridnate system.
                Point position = new Point(x, y);
                var pickingRect = new Rectangle(x, y, 1, 1);
                foreach (ViewPort viewPort in this.rootViewPort.Traverse(TraverseOrder.Post))
                {
                    if (viewPort.Visiable && viewPort.Enabled && viewPort.Contains(position))
                    {
                        allPickedGeometrys = ColorCodedPicking(viewPort, pickingRect, clientRectangle, pickingGeometryType);

                        break;
                    }
                }
            }

            return allPickedGeometrys;
        }

        /// <summary>
        /// Pick primitives in specified <paramref name="viewPort"/>.
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="pickingRect">rect in OpenGL's window coordinate system.(Left Down is (0, 0)), size).</param>
        /// <param name="clientRectangle">whole canvas' rectangle.</param>
        /// <param name="pickingGeometryType"></param>
        /// <returns></returns>
        private List<Tuple<Point, PickedGeometry>> ColorCodedPicking(ViewPort viewPort, Rectangle pickingRect, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            var result = new List<Tuple<Point, PickedGeometry>>();

            // if depth buffer is valid in specified rect, then maybe something is picked.
            if (DepthBufferValid(pickingRect))
            {
                {
                    var arg = new RenderEventArgs(clientRectangle, viewPort, pickingGeometryType);
                    // Render all PickableRenderers for color-coded picking.
                    List<IPickable> pickableRendererList = Render4Picking(arg);
                    // Read pixels in specified rect and get the VertexIds they represent.
                    List<Tuple<Point, uint>> stageVertexIdList = ReadPixels(pickingRect);
                    // Get all picked geometrys.
                    foreach (Tuple<Point, uint> tuple in stageVertexIdList)
                    {
                        int x = tuple.Item1.X;
                        int y = tuple.Item1.Y;
                        //if (x < 0 || clientRectangle.Width <= x || y < 0 || clientRectangle.Height <= y) { continue; }

                        uint stageVertexId = tuple.Item2;
                        PickedGeometry pickedGeometry = GetPickGeometry(arg,
                           x, y, stageVertexId, pickableRendererList);
                        if (pickedGeometry != null)
                        {
                            result.Add(new Tuple<Point, PickedGeometry>(new Point(x, y), pickedGeometry));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Maybe something is picked because depth buffer is valid.
        /// </summary>
        /// <param name="pickingRect"></param>
        /// <returns></returns>
        private static unsafe bool DepthBufferValid(Rectangle pickingRect)
        {
            if (pickingRect.Width <= 0 || pickingRect.Height <= 0) { return false; }

            bool result = false;
            using (var codedColor = new UnmanagedArray<byte>(pickingRect.Width * pickingRect.Height))
            {
                OpenGL.ReadPixels(pickingRect.X, pickingRect.Y, pickingRect.Width, pickingRect.Height,
                    OpenGL.GL_DEPTH_COMPONENT, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);

                var array = (byte*)codedColor.Header.ToPointer();
                for (int i = 0; i < codedColor.Length; i++)
                {
                    if (array[i] < byte.MaxValue)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Render all <see cref="PickableRenderer"/>s for color-coded picking.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private List<IPickable> Render4Picking(RenderEventArgs arg)
        {
            arg.UsingViewPort.On();

            // record clear color
            var originalClearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            // white color means nothing picked.
            OpenGL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            OpenGL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            uint renderedVertexCount = 0;
            var pickedRendererList = new List<IPickable>();
            RenderPickableObject(this.rootObject, arg, ref renderedVertexCount, pickedRendererList);

            OpenGL.Flush();

            arg.UsingViewPort.Off();

            return pickedRendererList;
        }

        private void RenderPickableObject(SceneObject sceneObject, RenderEventArgs arg, ref  uint renderedVertexCount, List<IPickable> pickedRendererList)
        {
            if ((sceneObject == null) || (!sceneObject.Enabled)) { return; }

            // global switches on.
            GLSwitch[] switchArray = sceneObject.GroupSwitchList.ToArray();
            for (int i = 0; i < switchArray.Length; i++)
            {
                switchArray[i].On();
            }
            // render self.
            var pickable = sceneObject.Renderer as IPickable;
            if ((pickable != null) && (sceneObject.Renderer.Enabled))
            {
                pickable.PickingBaseId = renderedVertexCount;
                pickable.Render4Picking(arg);
                uint rendered = renderedVertexCount + pickable.GetVertexCount();
                if (renderedVertexCount <= rendered)
                {
                    renderedVertexCount = rendered;
                }
                else
                {
                    throw new Exception(string.Format(
                        "Too many geometries({0} + {1} > {2}) for color coded picking.",
                            renderedVertexCount, pickable.GetVertexCount(), uint.MaxValue));
                }

                pickedRendererList.Add(pickable);
            }
            // render children.
            {
                SceneObject[] array = sceneObject.Children.ToArray();
                foreach (SceneObject child in array)
                {
                    RenderPickableObject(child, arg, ref renderedVertexCount, pickedRendererList);
                }
            }
            // global switches off.
            for (int i = switchArray.Length - 1; i >= 0; i--)
            {
                switchArray[i].Off();
            }
        }

        /// <summary>
        /// get picked geometry.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="stageVertexId"></param>
        /// <param name="pickableRendererList"></param>
        /// <returns></returns>
        private static PickedGeometry GetPickGeometry(RenderEventArgs arg,
            int x, int y,
            uint stageVertexId,
            List<IPickable> pickableRendererList)
        {
            PickedGeometry pickedGeometry = null;
            foreach (IPickable item in pickableRendererList)
            {
                pickedGeometry = item.GetPickedGeometry(arg, stageVertexId, x, y);

                if (pickedGeometry != null) { break; }
            }

            return pickedGeometry;
        }

        /// <summary>
        /// Read pixels in specified rect and get the VertexIds they represent.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private static unsafe List<Tuple<Point, uint>> ReadPixels(Rectangle target)
        {
            var result = new List<Tuple<Point, uint>>();

            // get coded color.
            using (var codedColor = new UnmanagedArray<Pixel>(target.Width * target.Height))
            {
                OpenGL.ReadPixels(target.X, target.Y, target.Width, target.Height,
                    OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);

                var array = (Pixel*)codedColor.Header.ToPointer();
                int index = 0;
                var vertexIdList = new List<uint>();
                for (int yOffset = target.Height - 1; yOffset >= 0; yOffset--)
                {
                    for (int xOffset = 0; xOffset < target.Width; xOffset++)
                    {
                        Pixel pixel = array[index++];
                        // This is when (x, y) is not on background and some primitive is picked.
                        if (!pixel.IsWhite())
                        {
                            uint stageVertexId = pixel.ToStageVertexId();
                            if (!vertexIdList.Contains(stageVertexId))
                            {
                                result.Add(new Tuple<Point, uint>(
                                    new Point(target.X + xOffset, target.Y + yOffset), stageVertexId));
                                vertexIdList.Add(stageVertexId);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}