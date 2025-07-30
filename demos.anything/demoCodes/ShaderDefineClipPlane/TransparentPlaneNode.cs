using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ShaderDefineClipPlane {
    partial class TransparentPlaneNode : PickableNode, IRenderable {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TransparentPlaneNode Create() {
            var model = new TransparentPlaneModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", TransparentPlaneModel.strPosition);
            map.Add("inColor", TransparentPlaneModel.strColor);
            var builder = new RenderMethodBuilder(program, map);
            var node = new TransparentPlaneNode(model, TransparentPlaneModel.strPosition, builder);
            node.Initialize();
            node.ModelSize = model.ModelSize;

            return node;
        }

        private TransparentPlaneNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders) : base(model, positionNameInIBufferSource, builders) { }

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

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
