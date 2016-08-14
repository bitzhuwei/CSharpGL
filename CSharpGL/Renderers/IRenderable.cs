using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Render something somewhere.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Transform about this model's position, rotation or scale.
        /// </summary>
        IModelTransform Transform { get; }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void Render(RenderEventArg arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class RenderEventArg
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArg"/> class.
        /// </summary>
        /// <param name="renderMode">render mode.</param>
        /// <param name="viewport"></param>
        /// <param name="camera">camera used during rendering.</param>
        /// <param name="pickingGeometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking when <paramref name="renderMode"/> is <see cref="RenderModes.ColorCodedPicking"/>; otherwise useless.</param>
        public RenderEventArg(RenderModes renderMode, Rectangle viewport, ICamera camera, GeometryType pickingGeometryType = GeometryType.Point)
        {
            this.RenderMode = renderMode;
            this.CanvasRect = viewport;
            this.Camera = camera;
            this.PickingGeometryType = pickingGeometryType;
        }

        /// <summary>
        /// Gets camera used during rendering.
        /// </summary>
        public ICamera Camera { get; private set; }

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
