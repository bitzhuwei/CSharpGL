using CSharpGL.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.UI.SimpleUI
{
    /// <summary>
    /// 实现在OpenGL窗口中的UI布局
    /// </summary>
    public interface IUILayout
    {
        IUILayoutParam Param { get; set; }

    }
}
