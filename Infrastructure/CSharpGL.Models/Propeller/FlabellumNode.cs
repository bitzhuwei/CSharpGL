using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //
    //        2-------------------3
    //      / .                  /|
    //     /  .                 / |
    //    /   .                /  |
    //   /    .               /   |
    //  /     .              /    |
    // 6--------------------7     |
    // |      .             |     |
    // |      0 . . . . . . |. . .1
    // |     .              |    /
    // |    .               |   /
    // |   .                |  /
    // |  .                 | /
    // | .                  |/
    // 4 -------------------5
    //
    /// <summary>
    /// Render flabellum in modern opengl.
    /// </summary>
    public class FlabellumNode : ModernNode, IRenderable
    {
        private const string vertexCode =
            @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMat;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

out vec3 passColor;

void main(void) {
	gl_Position = projectionMat * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
	passColor = inColor;
}
";
        private const string fragmentCode =
            @"#version 150 core

in vec3 passColor;

out vec4 outColor;

void main(void) {
	outColor = vec4(passColor, 1.0);
}
";

        /// <summary>
        /// Render flabellum in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static FlabellumNode Create()
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", Flabellum.strPosition);
            map.Add("inColor", Flabellum.strColor);
            var model = new Flabellum();
            var builder = new RenderMethodBuilder(provider, map);
            var node = new FlabellumNode(model, builder);
            node.Initialize();

            return node;
        }

        private FlabellumNode(Flabellum model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

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

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            //var viewport = new int[4];
            ////	Get the viewport, then convert the mouse point to an opengl point.
            //GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            //////	Push matrix, set up projection, then load matrix.
            //mat4 pickMatrix = glm.pickMatrix(new vec2(viewport[2] / 2, viewport[3] / 2), new vec2(viewport[2], viewport[3]), new ivec4(viewport[0], viewport[1], viewport[2], viewport[3]));
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMat", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }

    class Flabellum : IBufferSource
    {
        public vec3 GetModelSize()
        {
            return new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        private const float xLength = 1.6f;
        private const float yLength = 0.05f;
        private const float zLength = 0.2f;
        /// <summary>
        /// eight vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-xLength, -yLength, -zLength),// 0
            new vec3(-xLength, -yLength, +zLength),// 1
            new vec3(-xLength, +yLength, -zLength),// 2
            new vec3(-xLength, +yLength, +zLength),// 3
            new vec3(+xLength, -yLength, -zLength),// 4
            new vec3(+xLength, -yLength, +zLength),// 5
            new vec3(+xLength, +yLength, -zLength),// 6
            new vec3(+xLength, +yLength, +zLength),// 7
        };

        private static readonly vec3 red = new vec3(1, 0, 0);
        private static readonly vec3 green = new vec3(0, 1, 0);
        private static readonly vec3 blue = new vec3(0, 0, 1);

        private const float darkFactor = 4.0f;
        private static readonly vec3[] colors = new vec3[]
        {
            (red / darkFactor + green / darkFactor + blue / darkFactor),
            (red / darkFactor + green / darkFactor + blue),
            (red / darkFactor + green + blue / darkFactor),
            (red / darkFactor + green + blue),
            (red + green / darkFactor + blue / darkFactor),
            (red + green / darkFactor + blue),
            (red + green + blue / darkFactor),
            (red + green + blue),
        };

        /// <summary>
        /// render in GL_QUADS.
        /// </summary>
        private static readonly byte[] indexes = new byte[24]
        {
            1, 3, 7, 5, 0, 4, 6, 2,
            2, 6, 7, 3, 0, 1, 5, 4,
            4, 5, 7, 6, 0, 2, 3, 1,
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
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
                IndexBuffer buffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.Quads);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
