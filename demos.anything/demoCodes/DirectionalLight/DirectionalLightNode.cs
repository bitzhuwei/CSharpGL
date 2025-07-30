using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace DirectionalLight {
    /// <summary>
    /// 
    /// </summary>
    public partial class DirectionalLightNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inNormal = "inNormal";
        private const string mvpMat = "mvpMat";
        private const string normalMatrix = "normalMatrix";
        private const string halfVector = "halfVector";
        private const string shiness = "shiness";
        private const string strength = "strength";
        private const string lightDirection = "lightDirection";
        private const string lightColor = "lightColor";
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
        public static DirectionalLightNode Create(CSharpGL.DirectionalLight light, IBufferSource model, string position, string normal, vec3 size) {
            var program = GLProgram.Create(directionalLightVert, directionalLightFrag); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, position);
            map.Add(inNormal, normal);
            var builder = new RenderMethodBuilder(program, map);

            var node = new DirectionalLightNode(model, position, builder);
            node.Light = light;
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private DirectionalLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat3 normal = new mat3(glm.transpose(glm.inverse(view * model)));
            program.SetUniform(mvpMat, projection * view * model);
            program.SetUniform(normalMatrix, normal);
            vec3 lightDir = new vec3(view * new vec4(this.Light.Direction, 0.0f));
            program.SetUniform(lightDirection, lightDir);
            program.SetUniform(lightColor, this.Light.Diffuse);
            var cameraDrection = new vec3(0, 0, 1); // camera direction in eye/view/camera space.
            program.SetUniform(halfVector, (lightDir + cameraDrection).normalize());

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        public vec3 DiffuseColor {
            get {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.GetUniformValue(diffuseColor, out value);
                }

                return value;
            }
            set {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.SetUniform(diffuseColor, value);
                }
            }
        }
    }
}
