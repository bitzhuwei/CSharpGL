using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 表示将处理窗体、控件或其他组件的 MouseDown、MouseUp 或 MouseMove 事件的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的 GUIMouseEventArgs。</param>
    public delegate void GUIMouseEventHandler(object sender, GUIMouseEventArgs e);
}
