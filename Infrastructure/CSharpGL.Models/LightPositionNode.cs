using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Displays and updates light's position.
    /// </summary>
    public class LightPositionNode : PickableNode, IRenderable
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
        private CSharpGL.LightBase light;

        public CSharpGL.LightBase Light
        {
            get { return light; }
            set { light = value; }
        }

        /// <summary>
        /// Creates a <see cref="LightPositionNode"/> which displays and updates light's position.
        /// </summary>
        /// <param name="light"></param>
        /// <param name="initAngle"></param>
        /// <returns></returns>
        public static LightPositionNode Create(CSharpGL.LightBase light, float initAngle = 0)
        {
            var model = new Sphere(0.3f, 2, 3);
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new PropertyMap();
            map.Add(inPosition, Sphere.strPosition);
            var builder = new RenderMethodBuilder(provider, map, new PolygonModeSwitch(PolygonMode.Line));
            var node = new LightPositionNode(model, Sphere.strPosition, builder);
            node.Initialize();
            node.light = light;
            node.RotationAngle = initAngle;

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private LightPositionNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
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
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            if (this.AutoRotate)
            {
                float delta = 6;
                this.RotationAngle += delta;
                var position = new vec3(
                    (float)Math.Cos(this.RotationAngle * Math.PI / 180.0),
                    (float)Math.Cos(this.RotationAngle / 5 * Math.PI / 180.0) + 2.2f,
                    (float)Math.Sin(this.RotationAngle * Math.PI / 180.0)) * 8;
                this.light.Position = position;
                if (this.light is DirectionalLight)
                {
                    (this.light as DirectionalLight).Direction = position;
                }
                else if (this.light is SpotLight)
                {
                    //(this.light as SpotLight).Target = position;
                }

                this.WorldPosition = position;
            }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            program.SetUniform(color, this.light.Diffuse);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
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

            private IDrawCommand drawCmd;

            #region IBufferable 成员

            public IEnumerable<VertexBuffer> GetVertexProperty(string bufferName)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBuffer == null)
                    {
                        this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                    }

                    yield return this.positionBuffer;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IEnumerable<IDrawCommand> GetDrawCommand()
            {
                if (this.drawCmd == null)
                {
                    this.drawCmd = new DrawArraysCmd(DrawMode.TriangleStrip, 0, positions.Length);
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
