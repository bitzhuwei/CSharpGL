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
    public class UIRoot : UIRenderer
    {

        /// <summary>
        /// root UI for opengl.
        /// </summary>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIRoot(int zNear = -100, int zFar = 100)
            : base(
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right |
            System.Windows.Forms.AnchorStyles.Bottom |
            System.Windows.Forms.AnchorStyles.Top,
            new System.Windows.Forms.Padding(), new System.Drawing.Size(), zNear, zFar)
        {
            this.Name = typeof(UIRoot).Name;

            int[] viewport = OpenGL.GetViewport();
            this.Location = new System.Drawing.Point(viewport[0], viewport[1]);
            this.Size = new System.Drawing.Size(viewport[2], viewport[3]);
        }

        private void Layout()
        {
            int[] viewport = OpenGL.GetViewport();
            this.Location = new System.Drawing.Point(viewport[0], viewport[1]);
            this.Size = new System.Drawing.Size(viewport[2], viewport[3]);

            ILayoutHelper.Layout(this);
        }

        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.Layout();
            foreach (var item in this.Children)
            {
                RenderUIRenderer(item, arg);
            }
        }

#if DEBUG
        private int stackLevel = 0;
#endif

        private void RenderUIRenderer(UIRenderer renderer, RenderEventArgs arg)
        {
#if DEBUG
            stackLevel++;
            if (stackLevel > ushort.MaxValue)
            { throw new Exception(string.Format("Circular reference in UI tree!")); }
#endif
            renderer.Render(arg);
            foreach (var item in renderer.Children)
            {
                RenderUIRenderer(item, arg);
            }
#if DEBUG
            stackLevel--;
#endif
        }

    }
}
