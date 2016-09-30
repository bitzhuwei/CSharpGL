using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    ///
    /// </summary>
    [DemoRenderer]
    internal class EmitNormalLineRenderer : PickableRenderer
    {
        public static EmitNormalLineRenderer Create(IBufferable model, string position, string normal, vec3 lengths)
        {
            var shaderCodes = new ShaderCode[3];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLineRenderer\EmitNormalLine.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLineRenderer\EmitNormalLine.geom"), ShaderType.GeometryShader);
            shaderCodes[2] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLineRenderer\EmitNormalLine.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", position);
            map.Add("in_Normal", normal);
            var renderer = new EmitNormalLineRenderer(model, shaderCodes, map, position);
            renderer.SetUniform("normalLength", 0.5f);
            renderer.SetUniform("showModel", true);
            renderer.SetUniform("showNormal", true);
            renderer.Lengths = lengths;

            return renderer;
        }

        private EmitNormalLineRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, positionNameInIBufferable, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

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