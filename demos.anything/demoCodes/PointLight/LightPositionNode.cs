using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PointLight {
    /// <summary>
    /// Render a Cube with single color in modern opengl.
    /// </summary>
    public class LightPositionNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
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

uniform vec3 " + color + @" = vec3(1, 1, 1);

layout(location = 0) out vec4 outColor;
//out vec4 outColor;

void main(void) {
    outColor = vec4(color, 1);
}
";
        private CSharpGL.PointLight light;

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static LightPositionNode Create() {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, CubeModel.strPosition);
            var builder = new RenderMethodBuilder(program, map, new PolygonModeSwitch(PolygonMode.Line), new LineWidthSwitch(3));
            var node = new LightPositionNode(new CubeModel(), CubeModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private LightPositionNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders) {
            this.ModelSize = new vec3(1, 1, 1) * 0.3f;
            this.AutoRotate = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoRotate { get; set; }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg) {
            if (!this.IsInitialized) { this.Initialize(); }

            if (this.AutoRotate) {
                float delta = 1;
                this.RotationAngle += delta * 31;
                var position = new vec3(
                    (float)Math.Cos(this.RotationAngle / 5 * Math.PI / 180.0),
                    (float)Math.Cos(this.RotationAngle / 50 * Math.PI / 180.0),
                    (float)Math.Sin(this.RotationAngle / 5 * Math.PI / 180.0)) * 9;
                this.light.Position = position;
                this.WorldPosition = position;
            }

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

        public void SetLight(CSharpGL.PointLight light) {
            this.light = light;
        }

        class CubeModel : IBufferSource {
            public vec3 ModelSize { get; private set; }

            public CubeModel() {
                this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
            }

            public const string strPosition = "position";
            private VertexBuffer positionBuffer;

            private IDrawCommand drawCmd;

            #region IBufferable 成员

            public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
                if (bufferName == strPosition) {
                    if (this.positionBuffer == null) {
                        this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                    }

                    yield return this.positionBuffer;
                }
                else {
                    throw new ArgumentException();
                }
            }

            public IEnumerable<IDrawCommand> GetDrawCommand() {
                if (this.drawCmd == null) {
                    this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.TriangleStrip, positions.Length);
                }

                yield return this.drawCmd;
            }

            #endregion

            private const float xLength = 0.5f;
            private const float yLength = 0.5f;
            private const float zLength = 0.5f;
            /// <summary>
            /// four vertexes.
            /// </summary>
            private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, +zLength),//  0
            new vec3(+xLength, -yLength, +zLength),//  1
            new vec3(+xLength, +yLength, -zLength),//  2
            new vec3(+xLength, -yLength, -zLength),//  3
            new vec3(-xLength, -yLength, -zLength),//  4
            new vec3(+xLength, -yLength, +zLength),//  5
            new vec3(-xLength, -yLength, +zLength),//  6
            new vec3(+xLength, +yLength, +zLength),//  7
            new vec3(-xLength, +yLength, +zLength),//  8
            new vec3(+xLength, +yLength, -zLength),//  9
            new vec3(-xLength, +yLength, -zLength),// 10
            new vec3(-xLength, -yLength, -zLength),// 11
            new vec3(-xLength, +yLength, +zLength),// 12
            new vec3(-xLength, -yLength, +zLength),// 13
        };
        }
    }
}
