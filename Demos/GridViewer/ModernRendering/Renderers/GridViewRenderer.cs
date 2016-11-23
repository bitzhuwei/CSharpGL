using CSharpGL;

namespace GridViewer
{
    /// <summary>
    /// base renderer for gridview.
    /// </summary>
    public abstract class GridViewRenderer : Renderer
    {
        /// <summary>
        /// gridview's model.
        /// </summary>
        public GridViewModel Grid { get; private set; }

        protected GridViewRenderer(vec3 originalWorldPosition, GridViewModel model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.WorldPosition = originalWorldPosition;
            this.Grid = model;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.RenderGrid)
            {
                this.SetUniform("renderingWireframe", false);
                this.polygonModeState.Mode = PolygonMode.Fill;
                this.polygonModeState.On();
                base.DoRender(arg);
                this.polygonModeState.Off();
            }

            if (this.renderWireframe)
            {
                this.SetUniform("renderingWireframe", true);
                this.polygonModeState.Mode = PolygonMode.Line;
                this.polygonModeState.On();
                this.polygonOffsetState.On();
                base.DoRender(arg);
                this.polygonOffsetState.Off();
                this.polygonModeState.Off();
            }
        }

        private PolygonModeState polygonModeState = new PolygonModeState();
        private PolygonOffsetState polygonOffsetState = new PolygonOffsetLineState();
        private bool renderGrid = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderGrid
        {
            get { return renderGrid; }
            set { renderGrid = value; }
        }

        private bool renderWireframe = false;

        public bool RenderWireframe
        {
            get { return renderWireframe; }
            set { renderWireframe = value; }
        }
    }
}