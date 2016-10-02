using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Klein bottle.
    /// </summary>
    [DemoRenderer]
    internal class KleinBottleRenderer : PickableRenderer
    {
        public static KleinBottleRenderer Create(KleinBottleModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\KleinBottleRenderer\KleinBottle.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\KleinBottleRenderer\KleinBottle.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", KleinBottleModel.strPosition);
            var renderer = new KleinBottleRenderer(model, shaderCodes, map, KleinBottleModel.strPosition);
            renderer.Lengths = model.Lengths;

            return renderer;
        }

        private KleinBottleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, positionNameInIBufferable, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        private vec3 uniformColor = new vec3(1, 1, 1);

        public Color UniformColor
        {
            get { return uniformColor.ToColor(); }
            set { uniformColor = value.ToVec3(); }
        }
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            this.SetUniform("uniformColor", this.uniformColor);

            base.DoRender(arg);
        }
    }
}