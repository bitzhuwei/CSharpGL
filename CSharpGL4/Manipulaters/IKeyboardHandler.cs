using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Handle keyboard events.
    /// </summary>
    public interface IKeyboardHandler
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas_KeyPress(object sender, KeyPressEventArgs e);
    }
}