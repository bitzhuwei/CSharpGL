using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Demo of how to use uniform block and uniform buffer object.
    /// </summary>
    [DemoRenderer]
    internal class UniformBlockRenderer : Renderer
    {
        public static UniformBlockRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\UniformBlockRenderer\UniformBlock.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\UniformBlockRenderer\UniformBlock.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("vPos", Teapot.strPosition);
            map.Add("vColor", Teapot.strColor);
            var renderer = new UniformBlockRenderer(model, shaderCodes, map);
            return renderer;
        }

        private GroundRenderer groundRenderer;

        private UniformBlockRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
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
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniformBlock("Uniforms", new Uniforms(this.WorldPosition, this.Scale.x));

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }

        struct Uniforms : IEquatable<Uniforms>
        {
            public vec3 translation;
            public float scale;

            public Uniforms(vec3 translation, float scale)
            {
                this.translation = translation;
                this.scale = scale;
            }

            public bool Equals(Uniforms other)
            {
                return this.translation == other.translation && this.scale == other.scale;
            }
        }
    }
}