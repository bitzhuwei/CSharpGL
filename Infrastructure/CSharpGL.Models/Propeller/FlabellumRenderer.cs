using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
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
    public class FlabellumRenderer : Renderer, ILegacyPickable
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
        /// Render flabellum in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static FlabellumRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, "inPositoin", "inColor");
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Flabellum.strPosition);
            map.Add("inColor", Flabellum.strColor);
            var renderer = new FlabellumRenderer(new Flabellum(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private FlabellumRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        { }

        #region IRenderable 成员

        protected override void DoRender(RenderEventArgs arg)
        {
            //var viewport = new int[4];
            ////	Get the viewport, then convert the mouse point to an opengl point.
            //GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            //////	Push matrix, set up projection, then load matrix.
            //mat4 pickMatrix = glm.pickMatrix(new vec2(viewport[2] / 2, viewport[3] / 2), new vec2(viewport[2], viewport[3]), new ivec4(viewport[0], viewport[1], viewport[2], viewport[3]));
            mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
            mat4 view = arg.Scene.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }

        #endregion

        #region ILegacyPickable 成员

        private bool legacyPickingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool LegacyPickingEnabled
        {
            get { return legacyPickingEnabled; }
            set { legacyPickingEnabled = value; }
        }

        public void RenderForLegacyPicking(LegacyPickEventArgs arg)
        {
            mat4 projection = arg.pickMatrix * arg.scene.Camera.GetProjectionMatrix();
            mat4 view = arg.scene.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            this.SetUniform("renderWireframe", false);

            base.DoRender(new RenderEventArgs(arg.scene));
        }

        #endregion

    }

    class Flabellum : IBufferable
    {
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

        private OneIndexBuffer indexBuffer;

        #region IBufferable 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
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
