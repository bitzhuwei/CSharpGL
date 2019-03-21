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
            RenderMethodBuilder point, line;
            {
                var vs = new VertexShader(vsPoint);
                var fs = new FragmentShader(fsPoint);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", Sphere.strPosition);
                point = new RenderMethodBuilder(provider, map, new PolygonModeSwitch(PolygonMode.Point), new PointSizeSwitch(7));
            }
            {
                var vs = new VertexShader(vsLine);
                var fs = new FragmentShader(fsLine);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", Sphere.strPosition);
                line = new RenderMethodBuilder(provider, map, new PolygonModeSwitch(PolygonMode.Line), new LineWidthSwitch(2));
            }
            var node = new SphereNode(model, Sphere.strPosition, point, line);
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
            {
                var method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("projectionMatrix", projection);
                program.SetUniform("viewMatrix", view);
                program.SetUniform("modelMatrix", model);

                method.Render();
            }
            {
                var method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.SetUniform("projectionMatrix", projection);
                program.SetUniform("viewMatrix", view);
                program.SetUniform("modelMatrix", model);
                program.SetUniform("color", new vec3(1, 0, 0));

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

    }
}

