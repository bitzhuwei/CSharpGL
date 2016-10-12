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
        /// <param name="renderMode">render mode.</param>
        /// <param name="canvasRect"></param>
        /// <param name="viewPort">camera used during rendering.</param>
        /// <param name="pickingGeometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking when <paramref name="renderMode"/> is <see cref="RenderModes.ColorCodedPicking"/>; otherwise useless.</param>
        public RenderEventArgs(RenderModes renderMode, Rectangle canvasRect, ViewPort viewPort, GeometryType pickingGeometryType = GeometryType.Point)
        {
            this.RenderMode = renderMode;
            this.CanvasRect = canvasRect;
            this.UsingViewPort = viewPort;
            this.PickingGeometryType = pickingGeometryType;
        }

        /// <summary>
        /// Gets camera used during rendering.
        /// </summary>
        public ICamera Camera { get { return this.UsingViewPort.Camera; } }

        /// <summary>
        /// Gets render mode.
        /// </summary>
        public RenderModes RenderMode { get; private set; }

        /// <summary>
        /// Gets canvas's rectangle.
        /// </summary>
        public Rectangle CanvasRect { get; set; }

        /// <summary>
        /// Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking when render mode is <see cref="RenderModes.ColorCodedPicking"/>; otherwise useless.
        /// </summary>
        public GeometryType PickingGeometryType { get; private set; }

        /// <summary>
        /// Gets view port used during rendering.
        /// </summary>
        public ViewPort UsingViewPort { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public enum RenderModes
    {
        /// <summary>
        ///
        /// </summary>
        Render,

        /// <summary>
        ///
        /// </summary>
        ColorCodedPicking,

        //DesignMode,
    }
}