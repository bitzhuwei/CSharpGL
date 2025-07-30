using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader {
    partial class ZeroAttributeNode : ModernNode, IRenderable {
        public static ZeroAttributeNode Create() {
            // not attribute in vertex shader.
            var program = GLProgram.Create(vertexShader, fragmentShader); Debug.Assert(program != null);
            var map = new AttributeMap();// no items in this map.
            var builder = new RenderMethodBuilder(program, map, new PointSpriteSwitch());
            var model = new ZeroAttributeModel(CSharpGL.DrawMode.TriangleStrip, 4);
            var node = new ZeroAttributeNode(model, builder);
            node.ModelSize = new vec3(2.05f, 2.05f, 0.01f);
            node.Initialize();

            return node;
        }

        private ZeroAttributeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
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
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvp", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
