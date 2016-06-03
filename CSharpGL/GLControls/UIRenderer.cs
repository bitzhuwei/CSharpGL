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
        private ViewportSwitch viewportSwitch;
        private ScissorTestSwitch scissorTestSwitch;

        public Renderer Renderer { get; protected set; }

        public UIRenderer(Renderer renderer,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Controls = new ILayoutCollection(this);

            this.Renderer = renderer;
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
            this.viewportSwitch = new ViewportSwitch();
            this.scissorTestSwitch = new ScissorTestSwitch();

            Renderer renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Initialize();
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            Renderer renderer = this.Renderer;
            if (renderer != null)
            {
                this.viewportSwitch.X = this.Location.X;
                this.viewportSwitch.Y = this.Location.Y;
                this.viewportSwitch.Width = this.Size.Width;
                this.viewportSwitch.Height = this.Size.Height;
                this.scissorTestSwitch.X = this.Location.X;
                this.scissorTestSwitch.Y = this.Location.Y;
                this.scissorTestSwitch.Width = this.Size.Width;
                this.scissorTestSwitch.Height = this.Size.Height;

                this.scissorTestSwitch.On();
                this.viewportSwitch.On();

                // 把所有在此之前渲染的内容都推到最远。
                OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

                renderer.Render(arg);

                this.viewportSwitch.Off();
                this.scissorTestSwitch.Off();
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            Renderer renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Dispose();
            }
        }
    }
}
