using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms
{
    /// <summary>
    /// Delegate for a Render Event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
    public delegate void RenderEventHandler(object sender, RenderEventArgs args);
}
