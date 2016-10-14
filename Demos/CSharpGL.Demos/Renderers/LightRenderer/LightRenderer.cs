namespace CSharpGL
{
    /// <summary>
    /// Renders a model provided by CSharpGL.
    /// </summary>
    public partial class LightRenderer : PickableRenderer
    {
        public vec3 LightDirection { get; set; }

        /// <summary>
        /// create an Teapot' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static LightRenderer Create(Teapot model)
        {
            return Create(model, model.Lengths, Teapot.strPosition);
        }

        internal static LightRenderer Create(Teapot model, vec3 lengths, string positionNameInIBufferable)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(System.IO.File.ReadAllText(@"shaders\LightRenderer\Light.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(System.IO.File.ReadAllText(@"shaders\LightRenderer\Light.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", Teapot.strPosition);
            map.Add("in_Normal", Teapot.strNormal);
            //map.Add("in_Color", Teapot.strColor);
            var renderer = new LightRenderer(model, shaderCodes, map, positionNameInIBufferable);
            renderer.Lengths = lengths;
            return renderer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="attributeMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        private LightRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.LightDirection = new vec3(1, 1, 1);
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
            this.SetUniform("light", this.LightDirection);

            base.DoRender(arg);
        }
    }
}