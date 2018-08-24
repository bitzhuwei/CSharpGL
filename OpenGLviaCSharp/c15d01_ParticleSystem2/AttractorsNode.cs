using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d01_ParticleSystem2
{
    partial class AttractorsNode : ModernNode, IRenderable
    {
        public static AttractorsNode Create(ParticlesNode attractorsSource)
        {
            var model = new Sphere(0.1f, 10, 40);
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", Sphere.strPosition);
            map.Add("inColor", Sphere.strColor);
            var builder = new RenderMethodBuilder(array, map);
            var node = new AttractorsNode(model, builder);
            node.attractorsSource = attractorsSource;
            node.Initialize();

            return node;
        }

        private ParticlesNode attractorsSource;

        private AttractorsNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            foreach (var item in this.attractorsSource.Attractors)
            {
                mat4 model = glm.translate(mat4.identity(), new vec3(item));
                program.SetUniform("mvp", projection * view * model);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
