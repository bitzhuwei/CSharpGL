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

        ///// <summary>
        ///// 
        ///// </summary>
        //Rectangle ClientRectangle { get; }

        /// <summary>
        /// 
        /// </summary>
        void Repaint();

        /// <summary>
        /// 
        /// </summary>
        GLRenderContext RenderContext { get; }

        // TODO: use GLKeyPressEventHandler instead.
        /// <summary>
        /// 
        /// </summary>
        event KeyPressEventHandler KeyPress;

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
