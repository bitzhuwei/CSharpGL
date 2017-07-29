using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace CSharpGL
{
    // TODO: how to deal with keyboard/mouse events? Where put events?
    /// <summary>
    /// OpenGL Canvas on Windows platform.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IWinGLCanvas : IGLCanvas
    {

        /// <summary>
        ///
        /// </summary>
        RenderTrigger RenderTrigger { get; set; }

        /// <summary>
        ///
        /// </summary>
        int TimerTriggerInterval { get; set; }

    }
}