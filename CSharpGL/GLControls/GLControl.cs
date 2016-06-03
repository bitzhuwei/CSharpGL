using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// root UI for opengl.
    /// </summary>
    public class GLControl : UIRenderer
    {

        /// <summary>
        /// root UI for opengl
        /// </summary>
        /// <param name="size">opengl canvas' size</param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public GLControl(
            System.Drawing.Size size, int zNear, int zFar)
            : base(null,
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right |
            System.Windows.Forms.AnchorStyles.Bottom |
            System.Windows.Forms.AnchorStyles.Top,
            new System.Windows.Forms.Padding(), size, zNear, zFar)
        {
            this.Name = "GLRoot";
        }

        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
        }

    }
}
