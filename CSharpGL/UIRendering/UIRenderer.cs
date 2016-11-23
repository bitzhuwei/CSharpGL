using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Renderer  that supports UI layout.
    /// 支持2D UI布局的渲染器
    /// </summary>
    public partial class UIRenderer : RendererBase, ILayout<UIRenderer>, ILayoutEvent
    {
        private ViewportState viewportState;
        private ScissorTestState scissorTestState;
        private GLStateList stateList = new GLStateList();

        private const string strUIRenderer = "UIRenderer";

        /// <summary>
        ///
        /// </summary>
        [Category(strUIRenderer)]
        [Description("OpenGL switches.")]
        public GLStateList StateList
        {
            get { return stateList; }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strUIRenderer)]
        [Description("Renderer that actrually renders something.")]
        public RendererBase Renderer { get; protected set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIRenderer(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Children = new ChildList<UIRenderer>(this);// new ILayoutList(this);

            this.Anchor = anchor; this.Margin = margin;
            this.Size = size; this.zNear = zNear; this.zFar = zFar;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            this.viewportState = new ViewportState();
            this.scissorTestState = new ScissorTestState();

            RendererBase renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Initialize();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            RendererBase renderer = this.Renderer;
            if (renderer != null)
            {
                if (this.locationUpdated)
                {
                    this.viewportState.X = this.Location.X;
                    this.viewportState.Y = this.Location.Y;
                    this.scissorTestState.X = this.Location.X;
                    this.scissorTestState.Y = this.Location.Y;
                    this.locationUpdated = false;
                }
                if (this.sizeUpdated)
                {
                    this.viewportState.Width = this.Size.Width;
                    this.viewportState.Height = this.Size.Height;
                    this.scissorTestState.Width = this.Size.Width;
                    this.scissorTestState.Height = this.Size.Height;
                    this.sizeUpdated = false;
                }

                this.viewportState.On();
                this.scissorTestState.On();
                int count = this.stateList.Count;
                for (int i = 0; i < count; i++) { this.stateList[i].On(); }

                // 把所有在此之前渲染的内容都推到最远。
                // Push all rendered stuff to farest position.
                OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

                renderer.Render(arg);

                for (int i = count - 1; i >= 0; i--) { this.stateList[i].Off(); }
                this.scissorTestState.Off();
                this.viewportState.Off();
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            RendererBase renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Dispose();
            }
        }
    }
}