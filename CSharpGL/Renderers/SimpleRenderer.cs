namespace CSharpGL
{
    /// <summary>
    /// Renders a model provided by CSharpGL.
    /// </summary>
    public partial class SimpleRenderer : PickableRenderer
    {
        /// <summary>
        /// create an BigDipper's renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Chain model)
        {
            return Create(model, model.Lengths, Chain.position);
        }

        /// <summary>
        /// create an BigDipper's renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(BigDipper model)
        {
            return Create(model, model.Lengths, BigDipper.position);
        }

        /// <summary>
        /// create an Axis' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Axis model)
        {
            return Create(model, model.Lengths, Axis.strPosition);
        }

        /// <summary>
        /// create an Cube' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Cube model)
        {
            return Create(model, model.Lengths, Cube.strPosition);
        }

        /// <summary>
        /// create an Tetrahedron' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Tetrahedron model)
        {
            return Create(model, model.Lengths, Tetrahedron.strPosition);
        }

        /// <summary>
        /// create an Sphere' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Sphere model)
        {
            return Create(model, model.Lengths, Sphere.strPosition);
        }

        /// <summary>
        /// create an Teapot' renderer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SimpleRenderer Create(Teapot model)
        {
            return Create(model, model.Lengths, Teapot.strPosition);
        }

        internal static SimpleRenderer Create(IBufferable model, vec3 lengths, string positionNameInIBufferable)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            var tetrahedron = new SimpleRenderer(model, shaderCodes, map, positionNameInIBufferable);
            tetrahedron.Lengths = lengths;
            return tetrahedron;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        private SimpleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
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