using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class ScientificRenderer : RendererBase
    {
        public BoudingBoxRenderer BoundingBoxRenderer { get; set; }

        public Renderer Renderer { get; set; }

        protected override void DoInitialize()
        {
            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Initialize(); }

            Renderer renderer = this.Renderer;
            if (renderer != null) { renderer.Initialize(); }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Render(arg); }

            Renderer renderer = this.Renderer;
            if (renderer != null) { renderer.Render(arg); }
        }

        protected override void DisposeUnmanagedResources()
        {
            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Dispose(); }

            Renderer renderer = this.Renderer;
            if (renderer != null) { renderer.Dispose(); }
        }
    }
}
