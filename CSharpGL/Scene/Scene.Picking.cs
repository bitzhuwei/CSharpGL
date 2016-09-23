using System;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
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
                                 where (item != null && item.Enabled && item.Renderer is IColorCodedPicking && item.Renderer.Enabled)
                                 select item.Renderer as IColorCodedPicking).ToArray();
                result = CSharpGL.ColorCodedPicking.Pick(new RenderEventArgs(
                         RenderModes.ColorCodedPicking, clientRectangle, this.Camera, pickingGeometryType),
                         mousePosition.X, mousePosition.Y, renderers);
            }

            return result;
        }
    }
}