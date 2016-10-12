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
        public List<Tuple<Point, PickedGeometry>> Pick(Point mousePosition, GeometryType pickingGeometryType)
        {
            Rectangle clientRectangle = this.Canvas.ClientRectangle;
            // if mouse is out of window's area, nothing picked.
            if (mousePosition.X < 0 || clientRectangle.Width <= mousePosition.X || mousePosition.Y < 0 || clientRectangle.Height <= mousePosition.Y) { return null; }

            mousePosition.Y = clientRectangle.Height - mousePosition.Y - 1;// now mousePosition is in OpenGL's window cooridnate system.
            List<Tuple<Point, PickedGeometry>> allPickedGeometrys = null;
            foreach (ViewPort item in this.rootViewPort.DFSEnumerateRecursively())
            {
                if (item.Visiable && item.Enabled && item.Contains(mousePosition))
                {
                    allPickedGeometrys = ColorCodedPicking(item, mousePosition, clientRectangle, pickingGeometryType);

                    break;
                }
            }

            return allPickedGeometrys;
        }

        private List<Tuple<Point, PickedGeometry>> ColorCodedPicking(ViewPort item, Point mousePosition, Rectangle clientRectangle, GeometryType pickingGeometryType)
        {
            var result = new List<Tuple<Point, PickedGeometry>>();

            int height = clientRectangle.Height;

            // rect in OpenGL's window coordinate system.
            Rectangle rect = new Rectangle(mousePosition.X, mousePosition.Y, 1, 1);
            // if depth buffer is valid in specified rect, then maybe something is picked.
            if (DepthBufferValid(rect))
            {
                lock (this.synObj)
                {
                    var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, clientRectangle, item.Camera, pickingGeometryType);
                    // Render all PickableRenderers for color-coded picking.
                    List<IColorCodedPicking> pickableRendererList = Render4Picking(arg);
                    // Read pixels in specified rect and get the VertexIds they represent.
                    List<Tuple<Point, uint>> stageVertexIdList = ReadPixels(rect);
                    // Get all picked geometrys.
                    foreach (Tuple<Point, uint> tuple in stageVertexIdList)
                    {
                        int x = tuple.Item1.X;
                        int y = height - tuple.Item1.Y - 1;// turn back to windows coordinate system.
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
        /// <param name="rect"></param>
        /// <returns></returns>
        private static unsafe bool DepthBufferValid(Rectangle rect)
        {
            if (rect.Width <= 0 || rect.Height <= 0) { return false; }

            bool result = false;
            using (var codedColor = new UnmanagedArray<byte>(rect.Width * rect.Height))
            {
                OpenGL.ReadPixels(rect.X, rect.Y, rect.Width, rect.Height,
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
        private List<IColorCodedPicking> Render4Picking(RenderEventArgs arg)
        {
            // record clear color
            var originalClearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            // white color means nothing picked.
            OpenGL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            OpenGL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            uint renderedVertexCount = 0;
            var pickedRendererList = new List<IColorCodedPicking>();
            RenderPickableObject(this.rootObject, arg, ref renderedVertexCount, pickedRendererList);

            OpenGL.Flush();

            return pickedRendererList;
        }

        private void RenderPickableObject(SceneObject sceneObject, RenderEventArgs arg, ref  uint renderedVertexCount, List<IColorCodedPicking> pickedRendererList)
        {
            if ((sceneObject == null) || (!sceneObject.Enabled)) { return; }

            // global switches on.
            GLSwitch[] switchArray = sceneObject.GroupSwitchList.ToArray();
            for (int i = 0; i < switchArray.Length; i++)
            {
                switchArray[i].On();
            }
            // render self.
            var pickable = sceneObject.Renderer as IColorCodedPicking;
            if ((pickable != null) && (sceneObject.Renderer.Enabled))
            {
                pickable.PickingBaseId = renderedVertexCount;
                sceneObject.Render(arg);
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
            List<IColorCodedPicking> pickableRendererList)
        {
            PickedGeometry pickedGeometry = null;
            foreach (IColorCodedPicking item in pickableRendererList)
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
                        if (pixel.a != byte.MaxValue || pixel.b != byte.MaxValue
                    || pixel.g != byte.MaxValue || pixel.r != byte.MaxValue)
                        {
                            /* // This is how is vertexID coded into color in vertex shader.
                             * 	int objectID = gl_VertexID;
                                codedColor = vec4(
                                    float(objectID & 0xFF),
                                    float((objectID >> 8) & 0xFF),
                                    float((objectID >> 16) & 0xFF),
                                    float((objectID >> 24) & 0xFF));
                             */
                            // get vertexID from coded color.
                            // the vertexID is the last vertex that constructs the primitive.
                            // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                            uint shiftedR = (uint)pixel.r;
                            uint shiftedG = (uint)pixel.g << 8;
                            uint shiftedB = (uint)pixel.b << 16;
                            uint shiftedA = (uint)pixel.a << 24;
                            var vertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                            if (!vertexIdList.Contains(vertexId))
                            {
                                result.Add(new Tuple<Point, uint>(
                                    new Point(target.X + xOffset, target.Y + yOffset), vertexId));
                                vertexIdList.Add(vertexId);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}