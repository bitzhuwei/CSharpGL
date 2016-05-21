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
    public abstract class GLContainer : GLControl
    {
        public List<GLControl> Controls { get; private set; }

        public GLContainer(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.Controls = new List<GLControl>();
        }
    }
}
