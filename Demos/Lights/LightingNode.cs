using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lights
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LightingNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string MVP = "MVP";
        private const string MV = "MV";
        private const string V = "V";
        private const string N = "N";
        private const string lightPosition = "lightPosition"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string lightDirection = "lightDirection"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string spotDirection = "spotDirection"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string spotCutoff = "spotCutoff";
        private const string spotExponent = "spotExponent";
        private const string diffuseColor = "diffuseColor";
        private const string constantAttenuation = "constantAttenuation";
        private const string linearAttenuation = "linearAttenuation";
        private const string quadraticAttenuation = "quadraticAttenuation";
        private const string ambientColor = "ambientColor";

        const int pointLightIndex = 0;
        const int directionalLightIndex = 1;
        const int spotLightIndex = 2;
        public enum LightingMode
        {
            PointLight = pointLightIndex,
            DirectionalLight = directionalLightIndex,
            SpotLight = spotLightIndex,
        }

        /// <summary>
        /// 
        /// </summary>
        public LightingMode LightMode { get; set; }

        /// <summary>
        /// light's position in world space.
        /// </summary>
        public vec3 LightPostion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 DiffuseColor { get; set; }

        class Tuple { public readonly string vs, fs; public Tuple(string vs, string fs) { this.vs = vs; this.fs = fs; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static LightingNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            var builders = new List<RenderUnitBuilder>();
            var shaders = new List<Tuple>();
            shaders.Add(new Tuple(pointLightVert, pointLightFrag));
            shaders.Add(new Tuple(directionalLightVert, directionalLightFrag));
            shaders.Add(new Tuple(spotLightVert, spotLightFrag));
            foreach (var item in shaders)
            {
                var vs = new VertexShader(item.vs, vPosition, vNormal);
                var fs = new FragmentShader(item.fs);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders.Add(new RenderUnitBuilder(provider, map));
            }

            var node = new LightingNode(model, position, builders.ToArray());
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private LightingNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        { }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            switch (this.LightMode)
            {
                case LightingMode.PointLight:
                    RenderPointLight(arg);
                    break;
                case LightingMode.DirectionalLight:
                    RenderDirectionalLight(arg);
                    break;
                case LightingMode.SpotLight:
                    RenderSpotLight(arg);
                    break;
                default:
                    break;
            }
        }

        private void RenderSpotLight(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private void RenderDirectionalLight(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private void RenderPointLight(RenderEventArgs arg)
        {
            /*
            uniform mat4 MVP; // combined model view projection matrix
uniform mat4 MV; // model view matrix
uniform mat3 N; // normal matrix
             uniform mat4 V; // model view matrix
uniform vec3 lightPosition; // light position in model space
uniform vec3 diffuseColor; // diffuse color of surface
uniform float constantAttenuation = 1.0;
uniform float linearAttenuation = 0;
uniform float quadraticAttenuation = 0;
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);
             */
            RenderUnit unit = this.RenderUnits[pointLightIndex];
            ShaderProgram program = unit.Program;
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(MVP, projection * view * model);
            program.SetUniform(MV, projection * view);
            program.SetUniform(N, new mat3(glm.transpose(glm.inverse(view * model))));
            program.SetUniform(V, view);
            program.SetUniform(lightPosition, this.LightPostion);
            program.SetUniform(diffuseColor, this.DiffuseColor);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
