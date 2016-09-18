using System.IO;

namespace CSharpGL.Demos
{
    internal class OrderDependentTransparencyRenderer : PickableRenderer
    {
        public static OrderDependentTransparencyRenderer Create(IBufferable model, string position, string color)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Transparent.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Transparent.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", position);
            map.Add("in_Color", color);
            var renderer = new OrderDependentTransparencyRenderer(model, shaderCodes, map, position, new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            renderer.Name = "Order-Dependent Transparent Renderer";

            return renderer;
        }

        private OrderDependentTransparencyRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.SetUniform("modelMatrix", model);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("projectionMatrix", projection);

            base.DoRender(arg);
        }
    }
}