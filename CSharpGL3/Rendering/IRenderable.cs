using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
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
        /// <param name="canvasRect"></param>
        public RenderEventArgs(Rectangle canvasRect)
        {
            this.CanvasRect = canvasRect;
        }

        /// <summary>
        /// Gets canvas's rectangle.
        /// </summary>
        public Rectangle CanvasRect { get; set; }

    }
}