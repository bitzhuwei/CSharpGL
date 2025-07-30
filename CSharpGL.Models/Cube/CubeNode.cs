﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Render a Cube with single color in modern opengl.
    /// </summary>
    public unsafe class CubeNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        //private const string inColor = "inColor";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string color = "color";
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

uniform vec4 " + color + @";

layout(location = 0) out vec4 outColor;
//out vec4 outColor;

void main(void) {
    outColor = color;
}
";
        /// <summary>
        /// 
        /// </summary>
        public vec4 Color { get; set; }

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static CubeNode Create() {
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, CubeModel.strPosition);
            var builder = new RenderMethodBuilder(program, map);
            var node = new CubeNode(new CubeModel(), CubeModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private CubeNode(CubeModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders) {
            this.ModelSize = model.ModelSize;
            this.Color = new vec4(1, 1, 1, 1);
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
            program.SetUniform(color, this.Color);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }

}
