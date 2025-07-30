using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.ComponentModel;
using System.Diagnostics;

namespace StencilTest {
    partial class OutlineCubeNode : PickableNode, IRenderable {
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
uniform vec4 color;

out vec4 outColor;

void main(void) {
    if (alpha >= 0)
    {
        outColor = vec4(texture(tex, passUV).xyz, alpha);
    }
    else 
    {
        outColor = color;
    }
}
";

        private Texture texture;
        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static OutlineCubeNode Create(Texture texture) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, TexturedCubeModel.strPosition);
            map.Add(inUV, TexturedCubeModel.strUV);
            var builder = new RenderMethodBuilder(program, map);
            var node = new OutlineCubeNode(new TexturedCubeModel(), TexturedCubeModel.strPosition, builder);
            node.texture = texture;
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private OutlineCubeNode(TexturedCubeModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
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

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
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
            if (!this.IsInitialized) { this.Initialize(); }

            if (DisplayOutline) {
                var gl = GL.Current; Debug.Assert(gl != null);
                // render object and prepare stencil buffer.
                gl.glEnable(GL.GL_STENCIL_TEST);
                gl.glClearStencil(0);
                gl.glClear(GL.GL_STENCIL_BUFFER_BIT);
                gl.glStencilFunc(GL.GL_ALWAYS, 1, 0xFF);
                gl.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
                gl.glStencilMask(0xFF);

                method.Render();

                // render outline.
                gl.glStencilFunc(GL.GL_NOTEQUAL, 1, 0xFF);
                gl.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
                gl.glStencilMask(0x00);
                gl.glDepthMask(false);

                mat4 parentMat = mat4.identity();
                var parent = this.Parent;
                if (parent != null) { parentMat = parent.GetModelMatrix(); }
                //mat4 matrix = glm.translate(mat4.identity(), this.WorldPosition);
                //matrix = glm.scale(matrix, this.Scale * 1.1f);
                //matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);
                var matrix = glm.translate(this.WorldPosition)
                    * glm.scale(this.Scale * 1.1f)
                    * glm.rotate(this.RotationAngle, this.RotationAxis);
                program.SetUniform(modelMat, parentMat * matrix);
                program.SetUniform(alpha, -1.0f);
                program.SetUniform("color", new vec4(0.04f, 0.28f, 0.26f, 1.0f));
                method.Render();
                gl.glDepthMask(true);

                gl.glDisable(GL.GL_STENCIL_TEST);
            }
            else {
                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }


        [Browsable(false)]
        public bool DisplayOutline { get; set; }
    }

    class TexturedCubeModel : IBufferSource {
        public vec3 ModelSize { get; private set; }

        public TexturedCubeModel() {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;

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
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
        /// <summary>
        /// six quads' vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-xLength, -yLength, +zLength),//  0
            new vec3(+xLength, -yLength, +zLength),//  1
            new vec3(+xLength, +yLength, +zLength),//  2
            new vec3(-xLength, +yLength, +zLength),//  3

            new vec3(+xLength, -yLength, +zLength),//  4
            new vec3(+xLength, -yLength, -zLength),//  5
            new vec3(+xLength, +yLength, -zLength),//  6
            new vec3(+xLength, +yLength, +zLength),//  7
            
            new vec3(-xLength, +yLength, +zLength),//  8
            new vec3(+xLength, +yLength, +zLength),//  9
            new vec3(+xLength, +yLength, -zLength),// 10
            new vec3(-xLength, +yLength, -zLength),// 11
            
            new vec3(+xLength, -yLength, -zLength),// 12
            new vec3(-xLength, -yLength, -zLength),// 13
            new vec3(-xLength, +yLength, -zLength),// 14
            new vec3(+xLength, +yLength, -zLength),// 15
            
            new vec3(-xLength, -yLength, -zLength),// 16
            new vec3(-xLength, -yLength, +zLength),// 17
            new vec3(-xLength, +yLength, +zLength),// 18
            new vec3(-xLength, +yLength, -zLength),// 19
            
            new vec3(+xLength, -yLength, -zLength),// 20
            new vec3(+xLength, -yLength, +zLength),// 21
            new vec3(-xLength, -yLength, +zLength),// 22
            new vec3(-xLength, -yLength, -zLength),// 23
        };

        /// <summary>
        /// six quads' uvs.
        /// </summary>
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(0, 0),//  0
            new vec2(1, 0),//  1
            new vec2(1, 1),//  2
            new vec2(0, 1),//  3

            new vec2(0, 0),//  4
            new vec2(1, 0),//  5
            new vec2(1, 1),//  6
            new vec2(0, 1),//  7
            
            new vec2(0, 0),//  8
            new vec2(1, 0),//  9
            new vec2(1, 1),// 10
            new vec2(0, 1),// 11
            
            new vec2(0, 0),// 12
            new vec2(1, 0),// 13
            new vec2(1, 1),// 14
            new vec2(0, 1),// 15
            
            new vec2(0, 0),// 16
            new vec2(1, 0),// 17
            new vec2(1, 1),// 18
            new vec2(0, 1),// 19
            
            new vec2(0, 0),// 20
            new vec2(1, 0),// 21
            new vec2(1, 1),// 22
            new vec2(0, 1),// 23
        };
    }
}
