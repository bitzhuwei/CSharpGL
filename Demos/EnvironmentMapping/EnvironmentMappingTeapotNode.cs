using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EnvironmentMapping
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

        private const string vertexCode = @"#version 330 core

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
        private const string refractFragmentCode = @"#version 330 core

uniform vec3 " + cameraPos + @";
uniform samplerCube " + skybox + @";

in vec3 Normal;
in vec3 Position;

out vec4 FragColor;

void main()
{             
    float ratio = 1.00 / 1.52;
    vec3 I = normalize(Position - cameraPos);
    vec3 R = refract(I, normalize(Normal), ratio);
    FragColor = vec4(texture(skybox, R).rgb, 0.1);
}
";

        private Texture skyboxTexture;

        public static EnvironmentMappingTeapotNode Create(Texture skybox)
        {
            var model = new Teapot();
            RenderUnitBuilder reflectBuilder, refractBuilder;
            {
                var vs = new VertexShader(vertexCode, inPosition, inNormal);
                var fs = new FragmentShader(relectFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                map.Add(inNormal, Teapot.strNormal);
                reflectBuilder = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(vertexCode, inPosition, inNormal);
                var fs = new FragmentShader(refractFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                map.Add(inNormal, Teapot.strNormal);
                refractBuilder = new RenderUnitBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }
            var node = new EnvironmentMappingTeapotNode(model, Teapot.strPosition, reflectBuilder, refractBuilder);
            node.ModelSize = model.GetModelSize();
            node.skyboxTexture = skybox;
            node.Initialize();

            return node;
        }

        private EnvironmentMappingTeapotNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        { }

        /// <summary>
        /// 
        /// </summary>
        public enum RenderMethod
        {
            /// <summary>
            /// 
            /// </summary>
            Reflection = 0,
            /// <summary>
            /// 
            /// </summary>
            Refraction = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderMethod Method { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var camera = arg.CameraStack.Peek();
            mat4 p = camera.GetProjectionMatrix();
            mat4 v = camera.GetViewMatrix();
            mat4 m = this.GetModelMatrix();

            var unit = this.RenderUnits[(int)this.Method];
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
