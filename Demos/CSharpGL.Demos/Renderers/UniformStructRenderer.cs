using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Demo of how to use uniform block and uniform buffer object.
    /// </summary>
    [DemoRenderer]
    internal class UniformStructRenderer : Renderer
    {
        public static UniformStructRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\UniformStructRenderer\UniformStruct.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\UniformStructRenderer\UniformStruct.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("vPos", Teapot.strPosition);
            map.Add("vColor", Teapot.strColor);
            var renderer = new UniformStructRenderer(model, shaderCodes, map);
            renderer.Size = model.Lengths;

            return renderer;
        }

        private GroundRenderer groundRenderer;

        private UniformStructRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            var groundRenderer = GroundRenderer.Create(new GroundModel(20));
            groundRenderer.Scale = new vec3(10, 10, 10);
            this.groundRenderer = groundRenderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.groundRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("transformMatrix.projection", projection);
            this.SetUniform("transformMatrix.view", view);
            this.SetUniform("transformMatrix.model", model);

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }

    }
}