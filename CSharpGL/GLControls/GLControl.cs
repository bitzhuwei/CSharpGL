using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// root UI for opengl.
    /// </summary>
    public class GLControl : UIRenderer
    {

        /// <summary>
        /// root UI for OpenGL controls.
        /// </summary>
        /// <param name="canvas">opengl canvas that this GLControl binds to.</param>
        /// <param name="size">opengl canvas' size</param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public GLControl(Control canvas, int zNear, int zFar)
            : base(null,
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right |
            System.Windows.Forms.AnchorStyles.Bottom |
            System.Windows.Forms.AnchorStyles.Top,
            new System.Windows.Forms.Padding(), canvas.Size, zNear, zFar)
        {
            this.Name = "GLControl";
            canvas.Resize += canvas_Resize;
        }

        void canvas_Resize(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                this.Size = control.Size;
            }
        }

        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
        }

    }
}
