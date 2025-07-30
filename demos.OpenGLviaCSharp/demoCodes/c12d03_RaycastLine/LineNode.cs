﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace c12d03_RaycastLine {
    // Y
    // ^
    // |
    // |
    // 1--------------------0
    // |      .             |
    // |      |             |
    // |                    |
    // |    .               |
    // |   .                |
    // |  .                 |
    // | .                  |
    // 2--------------------3 --> X
    //
    /// <summary>
    /// Render rectangle with texture in modern opengl.
    /// </summary>
    public class LineNode : ModernNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + modelMat + @";

void main(void) {
	gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform vec4 color = vec4(1, 0, 0, 1);

out vec4 outColor;

void main(void) {
    outColor = color;
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static LineNode Create(vec3 direction) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, LineModel.strPosition);
            var lineWidthSwitch = new LineWidthSwitch(10);
            var builder = new RenderMethodBuilder(program, map, lineWidthSwitch);
            var node = new LineNode(new LineModel(direction), builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private LineNode(IBufferSource model, params RenderMethodBuilder[] builders)
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
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            GLProgram program = method.Program;
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

    }

}
