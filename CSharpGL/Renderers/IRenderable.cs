using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    public interface IRenderable
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
        /// <param name="renderMode">渲染模式</param>
        /// <param name="camera">渲染时所用的camera</param>
        /// <param name="pickingGeometryType">如果<paramref name="renderMode"/>是<see cref="RenderModes.ColorCodedPicking"/>，那么此值表示想要拾取到的几何图形类型（点、线、三角形、四边形、多边形）。否则此值无意义。</param>
        public RenderEventArgs(RenderModes renderMode, Rectangle viewport, ICamera camera, GeometryType pickingGeometryType = GeometryType.Point)
        {
            this.RenderMode = renderMode;
            this.CanvasRect = viewport;
            this.Camera = camera;
            this.PickingGeometryType = pickingGeometryType;
        }

        /// <summary>
        /// 获取Camera
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        /// 获取渲染模式
        /// </summary>
        public RenderModes RenderMode { get; private set; }

        public Rectangle CanvasRect { get; set; }

        public GeometryType PickingGeometryType { get; private set; }

    }

    public enum RenderModes
    {
        Render,
        ColorCodedPicking,
        //DesignMode,
    }
}
