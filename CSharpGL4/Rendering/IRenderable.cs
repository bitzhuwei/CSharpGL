using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
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
        // TODO: big bug: when mouse is picking something and move outside of viewport to anothher one, camera will go wrong.
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvasRect"></param>
        /// <param name="pickingGeometryType">Target geometry type(point, line, triangle, quad or polygon) for color-coded-picking; otherwise useless.</param>
        public RenderEventArgs(ICamera camera, Rectangle canvasRect)
        {
            this.Camera = camera;
            this.CanvasRect = canvasRect;
        }

        /// <summary>
        /// Gets camera used during rendering.
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// Gets canvas's rectangle.
        /// </summary>
        public Rectangle CanvasRect { get; set; }

    }
}