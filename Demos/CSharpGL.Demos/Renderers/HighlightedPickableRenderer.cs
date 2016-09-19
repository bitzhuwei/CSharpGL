namespace CSharpGL.Demos
{
    /// <summary>
    /// 高亮显示拾取的图元。
    /// </summary>
    public class HighlightedPickableRenderer : RendererBase
    {
        /// <summary>
        /// 高亮显示拾取的图元。
        /// </summary>
        /// <param name="highlighter"></param>
        /// <param name="pickableRenderer"></param>
        public HighlightedPickableRenderer(HighlightRenderer highlighter,
            PickableRenderer pickableRenderer)
        {
            this.PickableRenderer = pickableRenderer;
            this.Highlighter = highlighter;
        }

        protected override void DoInitialize()
        {
            this.PickableRenderer.Initialize();
            this.Highlighter.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.PickableRenderer.Render(arg);
            this.Highlighter.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.PickableRenderer.Dispose();
            this.Highlighter.Dispose();
        }

        /// <summary>
        /// 高亮。
        /// </summary>
        public HighlightRenderer Highlighter { get; private set; }

        /// <summary>
        /// 拾取。
        /// </summary>
        public PickableRenderer PickableRenderer { get; private set; }
    }
}