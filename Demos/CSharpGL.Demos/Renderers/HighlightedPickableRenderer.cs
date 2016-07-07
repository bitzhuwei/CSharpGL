using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            this.Highlighter = highlighter;
            this.PickableRenderer = pickableRenderer;
        }

        protected override void DoInitialize()
        {
            this.Highlighter.Initialize();
            this.PickableRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArg arg)
        {
            this.Highlighter.Render(arg);
            this.PickableRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.Highlighter.Dispose();
            this.PickableRenderer.Dispose();
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
