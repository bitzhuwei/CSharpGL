using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        private object synObj = new object();

        /// <summary>
        /// Pick
        /// </summary>
        /// <param name="clientRectangle">viewport.</param>
        /// <param name="mousePosition">mouse position.</param>
        /// <param name="pickingGeometryType">target's geometry type.</param>
        /// <returns></returns>
        public PickedGeometry ColorCodedPicking(Rectangle clientRectangle, Point mousePosition, GeometryType pickingGeometryType)
        {
            PickedGeometry result = null;
            lock (this.synObj)
            {
                var renderers = (from item in this.RootObject
                                 where item.Renderer is IColorCodedPicking
                                 select item.Renderer as IColorCodedPicking).ToArray();
                result = CSharpGL.ColorCodedPicking.Pick(new RenderEventArgs(
                         RenderModes.ColorCodedPicking, clientRectangle, this.Camera, pickingGeometryType),
                         mousePosition.X, mousePosition.Y, renderers);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="renderMode"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="mousePosition">mouse position in window coordinate system.</param>
        /// <param name="pickingGeometryType"></param>
        public void Render(RenderModes renderMode, Rectangle clientRectangle, Point mousePosition, GeometryType pickingGeometryType = GeometryType.Point)
        {
            var arg = new RenderEventArgs(renderMode, clientRectangle, this.Camera, pickingGeometryType);

            lock (this.synObj)
            {
                // render objects.
                {
                    SceneObject obj = this.RootObject;
                    this.RenderObject(obj, arg);
                }

                // render regular UI.
                this.UIRoot.Render(arg);

                // render cursor.
                UICursor cursor = this.Cursor;
                if (cursor != null && cursor.Enabled)
                {
                    cursor.UpdatePosition(mousePosition);
                    this.cursorRoot.Render(arg);
                }
            }
        }

        private void RenderObject(SceneObject sceneObject, RenderEventArgs arg)
        {
            sceneObject.Render(arg);
            SceneObject[] array = sceneObject.Children.ToArray();
            foreach (SceneObject child in array)
            {
                RenderObject(child, arg);
            }
        }
    }
}