using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class BoundedRenderer : RendererBase
    {
        public BoudingBoxRenderer BoundingBoxRenderer { get; private set; }

        public ScientificRenderer Renderer { get; set; }

        public void SetWorldPosition(vec3 worldPosition)
        {
            BoudingBoxRenderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Translate = worldPosition; }

            ScientificRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Translate = worldPosition; }
        }

        public BoundedRenderer()
        {
            this.BoundingBoxRenderer = new BoudingBoxRenderer();
        }

        protected override void DoInitialize()
        {
            BoudingBoxRenderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Initialize(); }

            ScientificRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Initialize(); }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            BoudingBoxRenderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Render(arg); }

            ScientificRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Render(arg); }
        }

        protected override void DisposeUnmanagedResources()
        {
            BoudingBoxRenderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Dispose(); }

            ScientificRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Dispose(); }
        }
    }
}
