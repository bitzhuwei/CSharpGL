using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 支持UI布局的渲染器
    /// </summary>
    public class UIRenderer : RendererBase, ILayout
    {
        protected Renderer renderer;

        public UIRenderer(Renderer renderer,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Controls = new ILayoutCollection(this);

            this.renderer = renderer;
            this.Anchor = anchor; this.Margin = margin;
            this.Size = size; this.zNear = zNear; this.zFar = zFar;
        }

        public ILayout Container { get; set; }

        public ICollection<ILayout> Controls { get; internal set; }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public System.Drawing.Point Location { get; set; }

        public System.Drawing.Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }

        protected override void DoInitialize()
        {
            Renderer renderer = this.renderer;
            if (renderer != null)
            {
                renderer.Initialize();
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            Renderer renderer = this.renderer;
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            Renderer renderer = this.renderer;
            if (renderer != null)
            {
                renderer.Dispose();
            }
        }


    }
}
