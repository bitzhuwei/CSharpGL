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
            renderer.Lengths = model.Lengths;

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
            mat4 model = this.GetModelMatrix();
            this.SetUniformBlock("Uniforms", new Uniforms(projection, view, model));

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }

        struct Uniforms : IEquatable<Uniforms>
        {
            public mat4 projection;
            public mat4 view;
            public mat4 model;

            public Uniforms(mat4 projection, mat4 view, mat4 model)
            {
                this.projection = projection;
                this.view = view;
                this.model = model;
            }

            public bool Equals(Uniforms other)
            {
                return this.projection == other.projection
                    && this.view == other.view
                    && this.model == other.model;
            }
        }
    }
}