using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace DirectionalLight
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DirectionalLightNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string MVP = "MVP";
        private const string normalMatrix = "normalMatrix";
        private const string halfVector = "halfVector";
        private const string shiness = "shiness";
        private const string strength = "strength";
        private const string lightDirection = "lightDirection"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string diffuseColor = "diffuseColor";
        private const string ambientColor = "ambientColor";

        /// <summary>
        /// directional light's direction.
        /// </summary>
        public CSharpGL.DirectionalLight Light { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DirectionalLightNode Create(CSharpGL.DirectionalLight light, IBufferSource model, string position, string normal, vec3 size)
        {
            var vs = new VertexShader(directionalLightVert, vPosition, vNormal);
            var fs = new FragmentShader(directionalLightFrag);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(vPosition, position);
            map.Add(vNormal, normal);
            var builder = new RenderMethodBuilder(provider, map);

            var node = new DirectionalLightNode(model, position, builder);
            node.Light = light;
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private DirectionalLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            RenderMethod unit = this.RenderUnit.Methods[0];
            ShaderProgram program = unit.Program;
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat3 normal = new mat3(glm.transpose(glm.inverse(view * model)));
            program.SetUniform(MVP, projection * view * model);
            program.SetUniform(normalMatrix, normal);
            vec3 lightDir = new vec3(view * new vec4(this.Light.Direction, 0.0f));
            program.SetUniform(lightDirection, lightDir);
            var cameraDrection = new vec3(0, 0, 1); // camera direction in eye/view/camera space.
            program.SetUniform(halfVector, (lightDir + cameraDrection).normalize());

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
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[0];
                    ShaderProgram program = unit.Program;
                    program.GetUniformValue(diffuseColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[0];
                    ShaderProgram program = unit.Program;
                    program.SetUniform(diffuseColor, value);
                }
            }
        }
    }
}
