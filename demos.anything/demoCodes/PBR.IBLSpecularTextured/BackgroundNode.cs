using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace PBR.IBLSpecularTextured {
    partial class BackgroundNode : ModernNode, IRenderable {
        public static BackgroundNode Create(Texture texEnvCubemap) {
            var model = new CubeModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("aPos", CubeModel.strPosition);
            var builder = new RenderMethodBuilder(program, map);
            var node = new BackgroundNode(model, builder);
            node.ModelSize = new vec3(2, 2, 2);
            node.texEnvCubemap = texEnvCubemap;
            node.Initialize();

            return node;
        }

        private BackgroundNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        private Texture texEnvCubemap;

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
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("projection", projection);
            program.SetUniform("view", view * model);
            program.SetUniform("environmentMap", this.texEnvCubemap);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }
    }
}
