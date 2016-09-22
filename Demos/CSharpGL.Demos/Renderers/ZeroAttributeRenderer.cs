using System;
using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal class ZeroAttributeRenderer : Renderer
    {
        public static ZeroAttributeRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ZeroAttributeRenderer\ZeroAttribute.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ZeroAttributeRenderer\ZeroAttribute.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();// no items in this map.
            var model = new ZeroAttributeModel(DrawMode.TriangleStrip, 0, 4);
            var renderer = new ZeroAttributeRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = new vec3(2.05f, 2.05f, 0.01f);

            return renderer;
        }

        private ZeroAttributeRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, attributeNameMap, switches)
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
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }
    }
}