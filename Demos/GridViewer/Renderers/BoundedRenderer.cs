using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class BoundedRenderer : RendererBase
    {
        /// <summary>
        /// Gets bounding box's renderer.
        /// </summary>
        public Renderer BoundingBoxRenderer { get; private set; }

        /// <summary>
        /// Gets scientific model's renderer.
        /// </summary>
        public Renderer ScientificRenderer { get; private set; }

        public BoundedRenderer(Renderer scientificRenderer, vec3 lengths)
        {
            if (scientificRenderer == null)
            { throw new ArgumentNullException(); }

            this.BoundingBoxRenderer = BoudingBoxRendererFactory.GetBoundingBoxRenderer(lengths);
            this.ScientificRenderer = scientificRenderer;
        }

        protected override void DoInitialize()
        {
            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Initialize(); }

            Renderer scientific = this.ScientificRenderer;
            if (scientific != null) { scientific.Initialize(); }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();

            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Render(arg); }

            Renderer renderer = this.ScientificRenderer;
            if (renderer != null) { renderer.Render(arg); }
        }

        protected override void DisposeUnmanagedResources()
        {
            Renderer boundingBox = this.BoundingBoxRenderer;
            if (boundingBox != null) { boundingBox.Dispose(); }

            Renderer scientific = this.ScientificRenderer;
            if (scientific != null) { scientific.Dispose(); }
        }
    }
}
