using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Handle keyboard events.
    /// </summary>
    public interface IKeyboardHandler
    {
        void canvas_KeyPress(object sender, KeyPressEventArgs e);
    }
}
