using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IRenderable : IModelSpace
    {
        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void Render(RenderEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class RenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        /// <param name="canvasRect"></param>
        /// <param name="viewPort">camera used during rendering.</param>
        /// <param name="pickingGeometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking; otherwise useless.</param>
        public RenderEventArgs(Rectangle canvasRect, ViewPort viewPort, PickingGeometryType pickingGeometryType)
        {
            this.CanvasRect = canvasRect;
            this.UsingViewPort = viewPort;
            this.PickingGeometryType = pickingGeometryType;
        }

        /// <summary>
        /// Gets camera used during rendering.
        /// </summary>
        public ICamera Camera { get { return this.UsingViewPort.Camera; } }

        /// <summary>
        /// Gets canvas's rectangle.
        /// </summary>
        public Rectangle CanvasRect { get; set; }

        /// <summary>
        /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking or none(nothing to pick).
        /// </summary>
        public PickingGeometryType PickingGeometryType { get; private set; }

        /// <summary>
        /// Gets view port used during rendering.
        /// </summary>
        public ViewPort UsingViewPort { get; set; }
    }
}