using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ShaderDefineClipPlane {
    partial class ClippedCubeNode : ModernNode, IRenderable {
        private Texture texture;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ClippedCubeNode Create(Texture texture) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", TexturedCubeModel.strPosition);
            map.Add("inUV", TexturedCubeModel.strUV);
            var builder = new RenderMethodBuilder(program, map);
            var model = new TexturedCubeModel();
            var node = new ClippedCubeNode(model, builder);
            node.texture = texture;
            node.Initialize();
            node.ModelSize = model.ModelSize;

            return node;
        }

        private ClippedCubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        private vec4 clipPlane = new vec4(1, 1, 1, 0);

        public vec4 ClipPlane {
            get { return clipPlane; }
            set {
                clipPlane = value;
                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                GLProgram program = method.Program;
                program.SetUniform("clipPlane", value);
            }
        }
        private bool keepGreater = true;

        public bool KeepGreater {
            get { return keepGreater; }
            set {
                keepGreater = value;
                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                GLProgram program = method.Program;
                program.SetUniform("keepGreater", value);
            }
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
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            GLProgram program = method.Program;
            program.SetUniform("projectionMat", projection);
            program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("tex", this.texture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
