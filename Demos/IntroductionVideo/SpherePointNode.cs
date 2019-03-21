using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroductionVideo {
    /// <summary>
    /// </summary>
    public partial class SpherePointNode : PickableNode, IRenderable {

        /// <summary>
        /// Creates a <see cref="LightPositionNode"/> which displays and updates light's position.
        /// </summary>
        /// <param name="light"></param>
        /// <param name="initAngle"></param>
        /// <returns></returns>
        public static SpherePointNode Create(Sphere model) {
            var vs = new VertexShader(vsCode);
            var fs = new FragmentShader(fsCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", Sphere.strPosition);
            var builder = new RenderMethodBuilder(provider, map, new PolygonModeSwitch(PolygonMode.Point), new PointSizeSwitch(7));
            var node = new SpherePointNode(model, Sphere.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private SpherePointNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders) {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

    }
}

