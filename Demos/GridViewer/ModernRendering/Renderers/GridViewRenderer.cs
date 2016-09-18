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
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
            this.WorldPosition = originalWorldPosition;
            this.Grid = model;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.RenderGrid)
            {
                this.SetUniform("renderingWireframe", false);
                this.polygonModeSwitch.Mode = PolygonMode.Fill;
                this.polygonModeSwitch.On();
                base.DoRender(arg);
                this.polygonModeSwitch.Off();
            }

            if (this.renderWireframe)
            {
                this.SetUniform("renderingWireframe", true);
                this.polygonModeSwitch.Mode = PolygonMode.Line;
                this.polygonModeSwitch.On();
                this.polygonOffsetSwitch.On();
                base.DoRender(arg);
                this.polygonOffsetSwitch.Off();
                this.polygonModeSwitch.Off();
            }
        }

        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch();
        private PolygonOffsetSwitch polygonOffsetSwitch = new PolygonOffsetLineSwitch();
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