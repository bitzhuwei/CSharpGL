using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 像Winform窗口里的控件一样的控件。
    /// </summary>
    public abstract class GLControl : IUILayout
    {
        public GLContainer Container { get; set; }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public System.Drawing.Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}
