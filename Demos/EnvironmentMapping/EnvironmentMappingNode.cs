using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EnvironmentMapping
{
    class EnvironmentMappingNode : PickableNode, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string inNormal = "inNormal";
        private const string projection = "projection";
        private const string view = "view";
        private const string model = "model";
        private const string cameraPos = "cameraPos";
        private const string skybox = "skybox";
        private const string ratio = "ratio";

        private const string vertexCode = @"#version 330 core

layout (location = 0) in vec3 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

uniform mat4 " + projection + @";
uniform mat4 " + view + @";
uniform mat4 " + model + @";

out vec3 passNormal;
out vec3 passPosition;

void main()
{
    gl_Position = projection * view * model * vec4(inPosition, 1.0);

    passNormal = mat3(transpose(inverse(model))) * inNormal;
    passPosition = vec3(model * vec4(inPosition, 1.0));
}
";
        private const string reflectFragmentCode = @"#version 330 core

uniform vec3 " + cameraPos + @";
uniform samplerCube " + skybox + @";

in vec3 passNormal;
in vec3 passPosition;

out vec4 outColor;

void main()
{             
    vec3 I = normalize(passPosition - cameraPos);
    vec3 R = reflect(I, normalize(passNormal));
    outColor = vec4(texture(skybox, R).rgb, 1.0);
}
";
        private const string refractFragmentCode = @"#version 330 core

uniform vec3 " + cameraPos + @";
uniform samplerCube " + skybox + @";
uniform float " + ratio + @";

in vec3 passNormal;
in vec3 passPosition;

out vec4 outColor;

void main()
{             
    vec3 I = normalize(passPosition - cameraPos);
    vec3 R = refract(I, normalize(passNormal), ratio);
    outColor = vec4(texture(skybox, R).rgb, 1);
}
";

        private Texture skyboxTexture;

        public static EnvironmentMappingNode Create(Texture skybox,
            IBufferSource model, string position, string normal)
        {
            RenderMethodBuilder reflectBuilder, refractBuilder;
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(reflectFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                map.Add(inNormal, normal);
                reflectBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(refractFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                map.Add(inNormal, normal);
                refractBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new EnvironmentMappingNode(model, Teapot.strPosition, reflectBuilder, refractBuilder);
            node.skyboxTexture = skybox;

            node.Initialize();

            return node;
        }

        private EnvironmentMappingNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.Method = RenderMethod.Reflection;
            this.RefractRatio = Ratio.Diamond;
        }

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
        public enum Ratio
        {
            /// <summary>
            /// 
            /// </summary>
            Ice = 1309,
            /// <summary>
            /// 
            /// </summary>
            Water = 1330,
            /// <summary>
            /// 
            /// </summary>
            Glass = 1520,
            /// <summary>
            /// 
            /// </summary>
            Diamond = 2420,
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderMethod Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Ratio RefractRatio { get; set; }

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

            var method = this.RenderUnit.Methods[(int)this.Method];
            var program = method.Program;
            program.SetUniform(projection, p);
            program.SetUniform(view, v);
            program.SetUniform(model, m);
            program.SetUniform(cameraPos, camera.Position);
            program.SetUniform(skybox, this.skyboxTexture);
            program.SetUniform(ratio, 1000.0f / (float)(this.RefractRatio));

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
