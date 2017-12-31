using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLCanvas
    {
        /// <summary>
        /// 
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Repaint();

        /// <summary>
        /// 
        /// </summary>
        GLRenderContext RenderContext { get; }

        /// <summary>
        /// Gets or sets the render trigger.
        /// </summary>
        RenderTrigger RenderTrigger { get; set; }

        /// <summary>
        /// Interval between two rendering passes. Must be greater than 0.(in milliseconds)
        /// </summary>
        int TimerTriggerInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        event GLEventHandler<GLKeyPressEventArgs> KeyPress;

        /// <summary>
        /// 
        /// </summary>
        event GLEventHandler<GLMouseEventArgs> MouseDown;

        /// <summary>
        /// 
        /// </summary>
        event GLEventHandler<GLMouseEventArgs> MouseMove;

        /// <summary>
        /// 
        /// </summary>
        event GLEventHandler<GLMouseEventArgs> MouseUp;

        /// <summary>
        /// 
        /// </summary>
        event GLEventHandler<GLMouseEventArgs> MouseWheel;

        /// <summary>
        ///
        /// </summary>
        event GLEventHandler<GLKeyEventArgs> KeyDown;

        /// <summary>
        ///
        /// </summary>
        event GLEventHandler<GLKeyEventArgs> KeyUp;

        /// <summary>
        ///
        /// </summary>
        event EventHandler Resize;

        /// <summary>
        /// 
        /// </summary>
        bool IsDisposed { get; }

    }
}
