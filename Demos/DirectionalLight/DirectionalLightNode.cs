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
            var builder = new RenderUnitBuilder(provider, map);

            var node = new DirectionalLightNode(model, position, builder);
            node.Light = light;
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private DirectionalLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
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
            mat3 normal = new mat3(glm.transpose(glm.inverse(view * model)));
            program.SetUniform(MVP, projection * view * model);
            program.SetUniform(normalMatrix, normal);
            vec3 viewDirection = new vec3(view * new vec4(this.Light.Direction, 0.0f));
            program.SetUniform(lightDirection, viewDirection);
            var cameraEyeSpace = new vec3(0, 0, 0);
            program.SetUniform(halfVector, (viewDirection + cameraEyeSpace).normalize());

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
