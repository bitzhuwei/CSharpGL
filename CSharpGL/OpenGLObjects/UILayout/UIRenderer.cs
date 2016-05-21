
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 支持UI布局的渲染器
    /// </summary>
    public partial class UIRenderer : RendererBase, IUILayout
    {
        protected Renderer renderer;

        public Renderer Renderer
        {
            get { return renderer; }
        }

        /// <summary>
        /// 支持UI布局的渲染器
        /// </summary>
        /// <param name="modernRenderer">要渲染的对象，确保其顶点范围在(-1, -1, -1)和(1, 1, 1)之间。</param>
        /// <param name="Anchor">绑定到窗口的哪些边？</param>
        /// <param name="Margin">到绑定边的距离</param>
        /// <param name="Size">UI大小</param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIRenderer(
            Renderer modernRenderer,
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000
            )
        {
            this.renderer = modernRenderer;
            this.Anchor = Anchor;
            this.Margin = Margin;
            this.Size = Size;
            this.zNear = zNear;
            this.zFar = zFar;
        }


        protected override void DoInitialize()
        {
            this.renderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.renderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.renderer.Dispose();
        }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public System.Drawing.Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}
