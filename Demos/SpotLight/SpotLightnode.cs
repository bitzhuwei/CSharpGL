using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace SpotLight
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpotLightNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";

        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string normalMatrix = "normalMatrix";
        private const string lightPosition = "lightPosition"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string spotDirection = "spotDirection";
        private const string diffuseColor = "diffuseColor";
        private const string ambientColor = "ambientColor";
        //private const string constantAttenuation = "constantAttenuation";
        //private const string linearAttenuation = "linearAttenuation";
        //private const string quadraticAttenuation = "quadraticAttenuation";

        private CSharpGL.SpotLight light;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static SpotLightNode Create(CSharpGL.SpotLight light, IBufferSource model, string position, string normal, vec3 size)
        {
            var vs = new VertexShader(spotLightVert, vPosition, vNormal);
            var fs = new FragmentShader(spotLightFrag);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(vPosition, position);
            map.Add(vNormal, normal);
            var builder = new RenderMethodBuilder(provider, map);

            var node = new SpotLightNode(model, position, builder);
            node.light = light;
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private SpotLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            program.SetUniform(normalMatrix, normal);
            program.SetUniform(lightPosition, new vec3(view * new vec4(light.Position, 1.0f)));
            program.SetUniform(spotDirection, new vec3(view * new vec4(-light.Position, 0.0f)));

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public vec3 DiffuseColor
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    ShaderProgram program = method.Program;
                    program.GetUniformValue(diffuseColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    ShaderProgram program = method.Program;
                    program.SetUniform(diffuseColor, value);
                }
            }
        }
    }
}
