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
    /// Render propeller in modern opengl.
    /// </summary>
    public class PropellerRenderer : ModernNode
    {

        private const string vertexCode =
            @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

out vec3 passColor;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
	passColor = inColor;
}
";
        private const string fragmentCode =
            @"#version 150 core

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static PropellerRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, "inPositoin", "inColor");
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Propeller.strPosition);
            map.Add("inColor", Propeller.strColor);
            var model = new Propeller();
            var builder = new RenderUnitBuilder(provider, map);
            var renderer = new PropellerRenderer(model, builder);
            renderer.Initialize();

            return renderer;
        }

        private PropellerRenderer(Propeller model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

        /// <summary>
        /// 
        /// </summary>
        public float RotateSpeed { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            //var viewport = new int[4];
            ////	Get the viewport, then convert the mouse point to an opengl point.
            //GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            //////	Push matrix, set up projection, then load matrix.
            //mat4 pickMatrix = glm.pickMatrix(new vec2(viewport[2] / 2, viewport[3] / 2), new vec2(viewport[2], viewport[3]), new ivec4(viewport[0], viewport[1], viewport[2], viewport[3]));
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);

            renderUnit.Render();
        }

        #endregion

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }

    class Propeller : IBufferable
    {
        public vec3 GetModelSize()
        {
            return new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        private const float xLength = 0.3f;
        private const float yLength = 0.2f;
        private const float zLength = 0.3f;
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

        private OneIndexBuffer indexBuffer;

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
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.colorBuffer;
            }

            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = indexes.GenIndexBuffer(DrawMode.Quads, BufferUsage.StaticDraw);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
