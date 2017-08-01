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
        private const string N = "N";
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
            this.DiffuseColor = Color.Gold.ToVec3();
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat3 n = new mat3(glm.transpose(glm.inverse(view * model)));
            program.SetUniform(MVP, projection * view * model);
            program.SetUniform(N, n);
            program.SetUniform(lightDirection, n * this.Light.Direction);
            program.SetUniform(diffuseColor, this.DiffuseColor);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
