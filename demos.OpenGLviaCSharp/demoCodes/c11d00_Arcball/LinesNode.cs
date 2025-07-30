﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball {
    partial class LinesNode : ModernNode, IRenderable {
        private float radius;

        public static LinesNode Create(float radius) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            //map.Add("inPosition", LinesModel.strPosition);
            map.Add("inColor", LinesModel.strColor);
            //var depthTestSwitch = new DepthTestSwitch(false);
            var lineWidthSwith = new LineWidthSwitch(5);
            var builder = new RenderMethodBuilder(program, map, lineWidthSwith);

            var model = new LinesModel(radius);
            var node = new LinesNode(model, builder);
            node.radius = radius;
            node.Initialize();

            return node;
        }

        private LinesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
            float length = radius / (float)Math.Sqrt(2);
            this.outMouseDownPosition = new vec3(-length, length, 0);
            this.inMouseDownPosition = new vec3(-length, length, 0);
            this.inMouseMovePosition = new vec3(length, length, 0);
            this.outMouseMovePosition = new vec3(length, length, 0);
            //this.mouseDown = false;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        private LineStippleSwitch stippleSwitch = new LineStippleSwitch(1, 0x0F0F);
        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("outMouseDownPosition", this.outMouseDownPosition);
            program.SetUniform("inMouseDownPosition", this.inMouseDownPosition);
            program.SetUniform("inMouseMovePosition", this.inMouseMovePosition);
            program.SetUniform("outMouseMovePosition", this.outMouseMovePosition);
            bool mouseDown = this.mouseDown;
            if (!mouseDown) {
                this.stippleSwitch.On();
            }
            method.Render();
            if (!mouseDown) {
                this.stippleSwitch.Off();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion

        //private vec3 mouseDownPosition;
        private vec3 outMouseDownPosition;
        private vec3 inMouseDownPosition;
        //private vec3 mouseMovePosition;
        private vec3 inMouseMovePosition;
        private vec3 outMouseMovePosition;
        private bool mouseDown = false;

        /// <summary>
        /// Indicates wheter the mouse is down or not.
        /// </summary>
        public bool IsMouseDown { get { return this.mouseDown; } }
    }
}
