namespace CSharpGL
{
    using System.IO;

    /// <summary>
    /// Renderer of PointCloud
    /// </summary>
    public partial class PointCloudRenderer : CSharpGL.Renderer
    {
        // you can replace PointCloudModel with IBufferable in the method's parameter.
        public static PointCloudRenderer Create(PointCloudModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointCloud.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointCloud.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.PropertyNameMap();
            map.Add("in_Position", PointCloudModel.position);
            var renderer = new PointCloudRenderer(model, shaderCodes, map);
            renderer.Lengths = model.Lengths;
            renderer.WorldPosition = model.WorldPosition;
            //renderer.switchList.Add(new PointSizeSwitch(10));
            return renderer;
        }

        private PointCloudRenderer(CSharpGL.IBufferable bufferable, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.PropertyNameMap propertyNameMap, params GLSwitch[] switches) :
            base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoRender(CSharpGL.RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}