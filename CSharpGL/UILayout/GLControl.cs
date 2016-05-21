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
    public class GLControl : IUILayout
    {
        public GLContainer Container { get; set; }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public System.Drawing.Size Size { get; set; }

        protected System.Drawing.Size realSize;

        public int zNear { get; set; }

        public int zFar { get; set; }

        public GLControl(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Anchor = anchor; this.Margin = margin;
            this.Size = size; this.zNear = zNear; this.zFar = zFar;
            this.realSize = size;
        }


        public virtual void Layout()
        {
            if (this.Container == null) { return; }

        }
    }
}
