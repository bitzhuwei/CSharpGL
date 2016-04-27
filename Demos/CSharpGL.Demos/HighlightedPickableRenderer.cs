using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class HighlightedPickableRenderer : RendererBase
    {

        public HighlightedPickableRenderer(HighlightModernRenderer highlighter, 
            PickableModernRenderer pickableRenderer)
        {
            this.Highlighter = highlighter;
            this.PickableRenderer = pickableRenderer;
        }

        protected override void DoInitialize()
        {
            this.Highlighter.Initialize();
            this.PickableRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.Highlighter.Render(e);
            this.PickableRenderer.Render(e);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.Highlighter.Dispose();
            this.PickableRenderer.Dispose();
        }

        public HighlightModernRenderer Highlighter { get; private set; }

        public PickableModernRenderer PickableRenderer { get; private set; }

    }
}
