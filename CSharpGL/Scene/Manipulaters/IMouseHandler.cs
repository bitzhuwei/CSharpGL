using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Handle mouse events.
    /// </summary>
    public interface IMouseHandler
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas_MouseDown(object sender, GLMouseEventArgs e);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas_MouseMove(object sender, GLMouseEventArgs e);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas_MouseUp(object sender, GLMouseEventArgs e);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas_MouseWheel(object sender, GLMouseEventArgs e);
    }
}