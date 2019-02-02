using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace PhysicallyBasedRendering
{
    class CubemapViewerNode : ModernNode, IRenderable
    {
        private const string vertexCode = @"#version 330 core

in vec3 inPosition;

uniform mat4 mvpMat;

out vec3 passPosition;

void main()
{
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    passPosition = inPosition;
}
";
        private const string reflectFragmentCode = @"#version 330 core

in vec3 passPosition;

uniform samplerCube skybox;

out vec4 outColor;

void main()
{             
    outColor = texture(skybox, passPosition);
}
";

        private Texture skyboxTexture;

        public static CubemapViewerNode Create(Texture skybox)
        {
            var model = new CubemapViewerModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(reflectFragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", CubemapViewerModel.strPosition);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new CubemapViewerNode(model, builder);
            node.skyboxTexture = skybox;

            node.Initialize();

            return node;
        }

        private CubemapViewerNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var camera = arg.Camera;
            mat4 p = camera.GetProjectionMatrix();
            mat4 v = camera.GetViewMatrix();
            mat4 m = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            program.SetUniform("mvpMat", p * v * m);
            program.SetUniform("skybox", this.skyboxTexture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
