using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public interface IGLCanvas {
        /// <summary>
        /// 
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Height { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //void Repaint();

        /// <summary>
        /// 
        /// </summary>
        GLRenderContext? RenderContext { get; }

        /// <summary>
        /// Gets or sets the render trigger.
        /// </summary>
        RenderTrigger RenderTrigger { get; set; }

        /// <summary>
        /// Interval between two rendering passes. Must be greater than 0.(in milliseconds)
        /// </summary>
        int TimerTriggerInterval { get; set; }

        event GLEventHandler<GLKeyPressEventArgs>? GLKeyPress;
        event GLEventHandler<GLMouseEventArgs>? GLMouseDown;
        event GLEventHandler<GLMouseEventArgs>? GLMouseMove;
        event GLEventHandler<GLMouseEventArgs>? GLMouseUp;
        event GLEventHandler<GLMouseEventArgs>? GLMouseWheel;
        event GLEventHandler<GLKeyEventArgs>? GLKeyDown;
        event GLEventHandler<GLKeyEventArgs>? GLKeyUp;
        event EventHandler? Resize;
        bool IsDisposed { get; }

    }
}
