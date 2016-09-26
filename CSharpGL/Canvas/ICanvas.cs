using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// OpenGL Canvas.
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        ///
        /// </summary>
        event KeyEventHandler KeyDown;

        /// <summary>
        ///
        /// </summary>
        event KeyPressEventHandler KeyPress;

        /// <summary>
        ///
        /// </summary>
        event KeyEventHandler KeyUp;

        /// <summary>
        ///
        /// </summary>
        event MouseEventHandler MouseDown;

        /// <summary>
        ///
        /// </summary>
        event MouseEventHandler MouseMove;

        /// <summary>
        ///
        /// </summary>
        event MouseEventHandler MouseUp;

        /// <summary>
        ///
        /// </summary>
        event MouseEventHandler MouseWheel;

        /// <summary>
        ///
        /// </summary>
        event EventHandler Resize;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        bool IsDisposed { get; }

        /// <summary>
        ///
        /// </summary>
        RenderTrigger RenderTrigger { get; set; }

        /// <summary>
        ///
        /// </summary>
        int TimerTriggerInterval { get; set; }

        // ivec2(width, height)
        /// <summary>
        ///
        /// </summary>
        Size Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        Rectangle ClientRectangle { get; }

        /// <summary>
        ///
        /// </summary>
        void Repaint();
    }
}