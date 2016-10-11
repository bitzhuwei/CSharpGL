using System.Linq;

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
            int[] viewport = OpenGL.GetViewport();
            this.Location = new System.Drawing.Point(viewport[0], viewport[1]);
            this.Size = new System.Drawing.Size(viewport[2], viewport[3]);
        }

        private void Layout()
        {
            int[] viewport = OpenGL.GetViewport();
            this.Location = new System.Drawing.Point(viewport[0], viewport[1]);
            this.Size = new System.Drawing.Size(viewport[2], viewport[3]);

            ILayoutHelper.Layout(this.LayoutManager);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.Layout();
            foreach (var item in this.LayoutManager.Children)
            {
                RenderUIRenderer(item.Owner, arg);
            }
        }

        //#if DEBUG
        //        private int stackLevel = 0;
        //#endif

        private void RenderUIRenderer(UIRenderer renderer, RenderEventArgs arg)
        {
            //#if DEBUG
            //            stackLevel++;
            //            if (stackLevel > ushort.MaxValue)
            //            { throw new Exception(string.Format("Maybe circular reference in UI tree!")); }
            //#endif
            renderer.Render(arg);
            LayoutManager<UIRenderer>[] array = renderer.LayoutManager.Children.ToArray();
            foreach (var item in array)
            {
                RenderUIRenderer(item.Owner, arg);
            }
            //#if DEBUG
            //            stackLevel--;
            //#endif
        }
    }
}