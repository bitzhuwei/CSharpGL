﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
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
    public unsafe class RectangleNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string tex = "tex";
        private const string transparentBackground = "transparentBackground";
        private const string vertexCode =
            @"#version 330 core

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
            @"#version 330 core

in vec2 passUV;

uniform sampler2D " + tex + @";
uniform bool " + transparentBackground + @" = false;

layout(location = 0) out vec4 outColor;
//out vec4 outColor;

void main(void) {
    //if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;

	vec4 color = texture(tex, passUV);
    if (transparentBackground)
    {
        if (color.a == 0) { discard; }
        else { outColor = color; }
    }
    else 
    {
        outColor = color;
    }
}
";

        public bool TransparentBackground { get; set; }

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static RectangleNode Create() {
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, RectangleModel.strPosition);
            map.Add(inUV, RectangleModel.strUV);
            var builder = new RenderMethodBuilder(program, map);
            var node = new RectangleNode(new RectangleModel(), RectangleModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private RectangleNode(RectangleModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders) {
            this.ModelSize = model.ModelSize;
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

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            GLProgram program = method.Program;

            var source = this.TextureSource;
            if (source != null) {
                program.SetUniform(tex, source.BindingTexture);
            }
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);
            program.SetUniform(transparentBackground, this.TransparentBackground);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        public ITextureSource TextureSource { get; set; }

    }


    public unsafe class RectangleModel : IBufferSource {
        public vec3 ModelSize { get; private set; }

        public RectangleModel() {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, (xLength + yLength) * 0.02f);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;


        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strUV) {
                if (this.uvBuffer == null) {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.uvBuffer;
            }
            else if (bufferName == strNormal) {
                if (this.normalBuffer == null) {
                    this.normalBuffer = normals.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, 0),// 0
            new vec3(-xLength, +yLength, 0),// 1
            new vec3(-xLength, -yLength, 0),// 2
            new vec3(+xLength, -yLength, 0),// 3
        };
        /// <summary>
        /// four uvs.
        /// </summary>
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(1, 1),// 0
            new vec2(0, 1),// 1
            new vec2(0, 0),// 2
            new vec2(1, 0),// 3
        };
        /// <summary>
        /// four normals.
        /// </summary>
        private static readonly vec3[] normals = new vec3[]
        {
            new vec3(0, 0, 1),// 0
            new vec3(0, 0, 1),// 1
            new vec3(0, 0, 1),// 2
            new vec3(0, 0, 1),// 3
        };

    }
}
