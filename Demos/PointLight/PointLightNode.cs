using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PointLight
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PointLightNode : PickableNode
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

        private CSharpGL.PointLight light;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static PointLightNode Create(CSharpGL.PointLight light, IBufferSource model, string position, string normal, vec3 size)
        {
            var vs = new VertexShader(pointLightVert, vPosition, vNormal);
            var fs = new FragmentShader(pointLightFrag);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(vPosition, position);
            map.Add(vNormal, normal);
            var builder = new RenderUnitBuilder(provider, map);

            var node = new PointLightNode(model, position, builder);
            node.light = light;
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private PointLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(MVP, projection * view * model);
            program.SetUniform(MV, projection * view);
            program.SetUniform(N, new mat3(glm.transpose(glm.inverse(view * model))));
            program.SetUniform(lightPosition, new vec3(view * new vec4(light.Position, 1.0f)));

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public vec3 DiffuseColor
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnits != null && this.RenderUnits.Count > 0)
                {
                    RenderUnit unit = this.RenderUnits[0];
                    ShaderProgram program = unit.Program;
                    program.GetUniformValue(diffuseColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnits != null && this.RenderUnits.Count > 0)
                {
                    RenderUnit unit = this.RenderUnits[0];
                    ShaderProgram program = unit.Program;
                    program.SetUniform(diffuseColor, value);
                }
            }
        }
    }
}
