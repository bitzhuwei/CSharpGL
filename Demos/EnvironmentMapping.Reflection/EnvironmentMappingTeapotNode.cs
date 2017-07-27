using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EnvironmentMapping.Reflection
{
    class EnvironmentMappingTeapotNode : PickableNode
    {
        private const string inPosition = "aPos";
        private const string inNormal = "aNormal";
        private const string projection = "projection";
        private const string view = "view";
        private const string model = "model";
        private const string cameraPos = "cameraPos";
        private const string skybox = "skybox";

        private const string reflectVertexCode = @"#version 330 core

layout (location = 0) in vec3 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

uniform mat4 " + projection + @";
uniform mat4 " + view + @";
uniform mat4 " + model + @";

out vec3 Normal;
out vec3 Position;

void main()
{
    Normal = mat3(transpose(inverse(model))) * aNormal;
    Position = vec3(model * vec4(aPos, 1.0));
    gl_Position = projection * view * model * vec4(aPos, 1.0);
}
";
        private const string relectFragmentCode = @"#version 330 core

uniform vec3 " + cameraPos + @";
uniform samplerCube " + skybox + @";

in vec3 Normal;
in vec3 Position;

out vec4 FragColor;

void main()
{             
    vec3 I = normalize(Position - cameraPos);
    vec3 R = reflect(I, normalize(Normal));
    FragColor = vec4(texture(skybox, R).rgb, 1.0);
}
";
        private Texture skyboxTexture;

        public static EnvironmentMappingTeapotNode Create(Texture skybox)
        {
            var model = new Teapot();
            RenderUnitBuilder reflectBuilder;
            {
                var vs = new VertexShader(reflectVertexCode, inPosition, inNormal);
                var fs = new FragmentShader(relectFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                map.Add(inNormal, Teapot.strNormal);
                reflectBuilder = new RenderUnitBuilder(provider, map);
            }
            var node = new EnvironmentMappingTeapotNode(model, Teapot.strPosition, reflectBuilder);
            node.ModelSize = model.GetModelSize();
            node.skyboxTexture = skybox;
            node.Initialize();

            return node;
        }

        private EnvironmentMappingTeapotNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        { }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var camera = arg.CameraStack.Peek();
            mat4 p = camera.GetProjectionMatrix();
            mat4 v = camera.GetViewMatrix();
            mat4 m = this.GetModelMatrix();

            var unit = this.RenderUnits[0];
            var program = unit.Program;
            program.SetUniform(projection, p);
            program.SetUniform(view, v);
            program.SetUniform(model, m);
            program.SetUniform(cameraPos, camera.Position);
            program.SetUniform(skybox, this.skyboxTexture);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
