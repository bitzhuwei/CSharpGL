﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d00_2DTexture {
    partial class SphereNode : ModernNode, IRenderable {
        public static SphereNode Create(Texture texture) {
            // vertex buffer and index buffer.
            var model = new Sphere(1, 20, 40);
            // vertex shader and fragment shader.
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            // which vertex buffer maps to which attribute in shader.
            var map = new AttributeMap();
            map.Add("inPosition", Sphere.strPosition);
            map.Add("inTexCoord", Sphere.strUV);
            // build a render method.
            var builder = new RenderMethodBuilder(program, map);
            // create node.
            var node = new SphereNode(model, builder);
            node.SetTexture(texture);
            // initialize node.
            node.Initialize();

            return node;
        }

        private Texture texture;
        private void SetTexture(Texture texture) {
            this.texture = texture;
        }

        private SphereNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        private PolygonModeSwitch polygonMode = new PolygonModeSwitch(PolygonMode.Line);
        private PolygonOffsetSwitch offset = new PolygonOffsetFillSwitch(false);

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public bool RenderWireframe { get; set; }

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
            program.SetUniform("tex", this.texture);
            // render the sphere model via OpenGL.

            bool renderWireframe = this.RenderWireframe;
            {
                if (renderWireframe) { this.offset.On(); }
                program.SetUniform("wireframe", false);
                method.Render();
                if (renderWireframe) { this.offset.Off(); }
            }

            if (renderWireframe) {
                this.polygonMode.On();
                program.SetUniform("wireframe", true);
                method.Render();
                this.polygonMode.Off();

            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
