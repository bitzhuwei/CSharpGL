using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //[Editor("System.Windows.Forms.Design.AnchorEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    /// <summary>
    /// 指定控件如何锚定到其容器的边缘。
    /// </summary>
    [Flags]
    public enum GUIAnchorStyles
    {
        /// <summary>
        /// 该控件未锚定到其容器的任何边缘。
        /// </summary>
        None = 0,
        /// <summary>
        /// 该控件锚定到其容器的上边缘。
        /// </summary>
        Top = 1,
        /// <summary>
        /// 该控件锚定到其容器的下边缘。
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// 该控件锚定到其容器的左边缘。
        /// </summary>
        Left = 4,
        /// <summary>
        /// 该控件锚定到其容器的右边缘。
        /// </summary>
        Right = 8,
    }
}
