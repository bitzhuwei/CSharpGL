using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroductionVideo {
    /// <summary>
    /// </summary>
    public partial class SphereNode : PickableNode, IRenderable {

        /// <summary>
        /// Creates a <see cref="LightPositionNode"/> which displays and updates light's position.
        /// </summary>
        /// <param name="light"></param>
        /// <param name="initAngle"></param>
        /// <returns></returns>
        public static SphereNode Create() {
            var model = new Sphere(1f, 10, 15);
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", Sphere.strPosition);
            var builder = new RenderMethodBuilder(provider, map, new PolygonModeSwitch(PolygonMode.Line));
            var node = new SphereNode(model, Sphere.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private SphereNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
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

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
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

