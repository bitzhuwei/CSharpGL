﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d02_MultipleTextures {
    partial class CubeNode : ModernNode, IRenderable {
        public static CubeNode Create(Texture texture0, Texture texture1, Texture texture2) {
            // vertex buffer and index buffer.
            var model = new CubeModel();
            // vertex shader and fragment shader.
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            // which vertex buffer maps to which attribute in shader.
            var map = new AttributeMap();
            map.Add("inPosition", CubeModel.strPosition);
            map.Add("inTexCoord", CubeModel.strTexCoord);
            // build a render method.
            var builder = new RenderMethodBuilder(program, map);
            // create node.
            var node = new CubeNode(model, builder);
            node.SetTextures(texture0, texture1, texture2);
            // initialize node.
            node.Initialize();

            return node;
        }

        private Texture texture0;
        private Texture texture1;
        private Texture texture2;
        private void SetTextures(Texture texture0, Texture texture1, Texture texture2) {
            this.texture0 = texture0;
            this.texture1 = texture1;
            this.texture2 = texture2;
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            // gets mvpMatrix.
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();
            mat4 mvpMatrix = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[0];
            // shader program wraps vertex shader and fragment shader.
            GLProgram program = method.Program;
            //set value for 'uniform mat4 mvpMatrix'; in shader.
            program.SetUniform("mvpMatrix", mvpMatrix);
            program.SetUniform("texture0", this.texture0);
            program.SetUniform("texture1", this.texture1);
            program.SetUniform("texture2", this.texture2);
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
