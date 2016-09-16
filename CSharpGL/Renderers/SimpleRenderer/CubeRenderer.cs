namespace CSharpGL
{
    /// <summary>
    /// Renders a cube.
    /// </summary>
    public partial class CubeRenderer : Renderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static CubeRenderer Create(Cube model)
        {
            ShaderCode[] shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Cube.strPosition);
            map.Add("in_Color", Cube.strColor);
            var cubeRenderer = new CubeRenderer(model, shaderCodes, map);
            cubeRenderer.Lengths = model.Lengths;

            return cubeRenderer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="switches"></param>
        public CubeRenderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.GetModelMatrix());
                this.modelMatrixRecord.CancelMark();
            }
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);

            base.DoRender(arg);
        }
    }
}