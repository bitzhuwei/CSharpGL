﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EZMFileViewer {
    partial class NodeLineNode {
        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projectionMat * viewMat * modelMat);
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glClear(GL.GL_DEPTH_BUFFER_BIT); // push this node to top front.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
