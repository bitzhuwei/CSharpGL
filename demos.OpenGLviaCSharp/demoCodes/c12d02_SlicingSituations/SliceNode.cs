﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations {
    partial class SliceNode : ModernNode, IRenderable {
        public static SliceNode Create() {
            // vertex buffer and index buffer.
            var model = new SliceModel();
            // vertex shader and fragment shader.
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            // which vertex buffer maps to which attribute in shader.
            var map = new AttributeMap();
            map.Add("inPosition", SliceModel.strPosition);
            // build a render method.
            var builder = new RenderMethodBuilder(program, map);
            // create node.
            var node = new SliceNode(model, builder);
            // initialize node.
            node.Initialize();

            return node;
        }

        private SliceNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        private VertexBuffer positionBuffer;
        protected override void DoInitialize() {
            base.DoInitialize();
            {
                this.positionBuffer = this.RenderUnit.Methods[0].VertexArrayObjects[0].VertexAttributes[0].buffer;
            }
        }

        public unsafe void SetX(float x) {
            var positions = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            positions[0] = new vec3(x, 0, 0);
            this.positionBuffer.UnmapBuffer();
        }

        public unsafe void SetY(float y) {
            var positions = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            positions[1] = new vec3(0, y, 0);
            this.positionBuffer.UnmapBuffer();
        }

        public unsafe void SetZ(float z) {
            var positions = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            positions[2] = new vec3(0, 0, z);
            this.positionBuffer.UnmapBuffer();
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
            // gets mvpMat.
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();
            mat4 mvpMat = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[0];
            // shader program wraps vertex shader and fragment shader.
            GLProgram program = method.Program;
            //set value for 'uniform mat4 mvpMat'; in shader.
            program.SetUniform("mvpMat", mvpMat);
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
