using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpotLight
{
    /// <summary>
    /// Render a Cube with single color in modern opengl.
    /// </summary>
    public class LightPostionNode : PickableNode
    {
        private const string inPosition = "inPosition";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string color = "color";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform vec3 " + color + @" = vec3(1, 1, 1);

layout(location = 0) out vec4 out_Color;
//out vec4 out_Color;

void main(void) {
    out_Color = vec4(color, 1);
}
";
        private CSharpGL.SpotLight light;

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static LightPostionNode Create()
        {
            var vs = new VertexShader(vertexCode, inPosition);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CubeModel.strPosition);
            var builder = new RenderMethodBuilder(provider, map, new PolygonModeState(PolygonMode.Line), new LineWidthState(3));
            var node = new LightPostionNode(new CubeModel(), CubeModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private LightPostionNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = new vec3(1, 1, 1) * 0.3f;
            this.AutoRotate = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoRotate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            if (this.AutoRotate)
            {
                float delta = 1;
                this.RotationAngle += delta * 31;
                var position = new vec3(
                    (float)Math.Cos(this.RotationAngle / 5 * Math.PI / 180.0),
                    (float)Math.Cos(this.RotationAngle / 50 * Math.PI / 180.0),
                    (float)Math.Sin(this.RotationAngle / 5 * Math.PI / 180.0)) * 9;
                this.light.Position = position;
                this.WorldPosition = position;
            }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);

            renderUnit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public void SetLight(CSharpGL.SpotLight light)
        {
            this.light = light;
        }

        class CubeModel : IBufferSource
        {
            public vec3 ModelSize { get; private set; }

            public CubeModel()
            {
                this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
            }

            public const string strPosition = "position";
            private VertexBuffer positionBuffer;

            private IndexBuffer indexBuffer;

            #region IBufferable 成员

            public VertexBuffer GetVertexAttributeBuffer(string bufferName)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBuffer == null)
                    {
                        this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                    }

                    return this.positionBuffer;
                }

                throw new NotImplementedException();
            }

            public IndexBuffer GetIndexBuffer()
            {
                if (this.indexBuffer == null)
                {
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.TriangleStrip, 0, positions.Length);
                }

                return this.indexBuffer;
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
