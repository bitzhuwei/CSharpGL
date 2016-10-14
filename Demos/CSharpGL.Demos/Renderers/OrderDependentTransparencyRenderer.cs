using System.IO;

namespace CSharpGL.Demos
{
    internal class OrderDependentTransparencyRenderer : PickableRenderer
    {
        public static OrderDependentTransparencyRenderer Create(IBufferable model, vec3 lengths, string position, string color)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ODT\Transparent.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ODT\Transparent.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", position);
            map.Add("in_Color", color);
            var renderer = new OrderDependentTransparencyRenderer(model, shaderCodes, map, position, new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            renderer.Size = lengths;

            return renderer;
        }

        private OrderDependentTransparencyRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoRender(RenderEventArgs arg)
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