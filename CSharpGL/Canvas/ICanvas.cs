using System;
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
        RenderTrigger RenderTrigger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int TimerTriggerInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        void Repaint();
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
    }
}