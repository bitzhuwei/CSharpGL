namespace CSharpGL
{
    using System.Drawing;

    /// <summary>
    /// Rendering points.
    /// </summary>
    public partial class PointsRenderer : PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PointsRenderer Create(Points model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.AttributeMap();
            map.Add("in_Position", Points.strposition);
            var renderer = new PointsRenderer(model, shaderCodes, map, Points.strposition);
            renderer.ModelSize = model.Lengths;
            renderer.WorldPosition = model.WorldPosition;
            renderer.switchList.Add(new PointSizeSwitch(10));

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
        public PointsRenderer(Points model, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches) :
            base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(CSharpGL.RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            mat4 model;
            if (this.GeUpdatedModelMatrix(out model))
            {
                this.SetUniform("modelMatrix", model);
            }
            if (this.pointColorRecord.IsMarked())
            {
                this.SetUniform("PointColor", this.pointColor);
                this.pointColorRecord.CancelMark();
            }

            base.DoRender(arg);
        }

        private UpdatingRecord pointColorRecord = new UpdatingRecord();
        private vec3 pointColor = new vec3(1, 0, 1);

        /// <summary>
        ///
        /// </summary>
        public Color PointColor
        {
            get { return pointColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                if (color != pointColor)
                {
                    this.pointColor = color;
                    pointColorRecord.Mark();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}.", base.ToString(), this.pointColor.ToColor());
        }
    }
}