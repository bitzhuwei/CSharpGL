namespace CSharpGL
{
    /// <summary>
    /// OpenGL Canvas.
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        /// repaint this canvas' content.
        /// </summary>
        void Repaint();

        ///// <summary>
        ///// canvas' rectangle.
        ///// </summary>
        //Rectangle CanvasRectangle { get; }
        ///// <summary>
        ///// Cursor(mouse) position to canvas' left-top corner.
        ///// </summary>
        //Point CursorPosition { get; }
    }
}