﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Render a Cube with single color in modern opengl.
    /// </summary>
    public unsafe class TexturedCubeNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string tex = "tex";
        private const string alpha = "alpha";
        private const string vertexCode =
            @"#version 150 core

in vec3 " + inPosition + @";
in vec2 " + inUV + @";

uniform mat4 " + projectionMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + modelMat + @";

out vec2 passUV;

void main(void) {
	gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);
    passUV = inUV;
}
";
        private const string fragmentCode =
            @"#version 150 core
in vec2 passUV;

uniform sampler2D " + tex + @";
uniform float " + alpha + @";

out vec4 outColor;

void main(void) {
    outColor = vec4(texture(tex, passUV).xyz, alpha);
}
";

        private Texture texture;
        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static TexturedCubeNode Create(Texture texture) {
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, TexturedCubeModel.strPosition);
            map.Add(inUV, TexturedCubeModel.strUV);
            var builder = new RenderMethodBuilder(program, map);
            var node = new TexturedCubeNode(new TexturedCubeModel(), TexturedCubeModel.strPosition, builder);
            node.texture = texture;
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private TexturedCubeNode(TexturedCubeModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders) {
            this.ModelSize = model.ModelSize;
            this.Alpha = 1.0f;
        }

        /// <summary>
        /// transparent component.
        /// </summary>
        public float Alpha { get; set; }

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
            program.SetUniform(tex, this.texture);
            program.SetUniform(alpha, this.Alpha);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }

}
