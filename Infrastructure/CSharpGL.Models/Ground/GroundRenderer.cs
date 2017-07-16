using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render a Ground(two triangles) with single color in modern opengl.
    /// </summary>
    public class GroundRenderer : PickableRenderer
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

uniform vec4 " + color + @";

layout(location = 0) out vec4 out_Color;
//out vec4 out_Color;

void main(void) {
    out_Color = color;
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
        public static GroundRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, inPosition);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add(inPosition, GroundModel.strPosition);
            var renderer = new GroundRenderer(new GroundModel(), provider, map, inPosition);
            renderer.Initialize();

            return renderer;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private GroundRenderer(GroundModel model, IShaderProgramProvider renderProgramProvider,
            AttributeMap attributeMap, string positionNameInVertexShader,
            params GLState[] switches)
            : base(model, renderProgramProvider, attributeMap, positionNameInVertexShader, switches)
        {
            this.ModelSize = model.ModelSize;
            this.Color = new vec4(1, 1, 1, 1);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform(projectionMatrix, projection);
            this.SetUniform(viewMatrix, view);
            this.SetUniform(modelMatrix, model);
            this.SetUniform(color, this.Color);

            base.DoRender(arg);
        }

    }

    class GroundModel : IBufferable
    {
        public vec3 ModelSize { get; private set; }

        public GroundModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IndexBuffer indexBuffer;

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

            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
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
            new vec3(+xLength, 0, +zLength),//  0
            new vec3(+xLength, 0, -zLength),//  1
            new vec3(-xLength, 0, -zLength),//  2
            new vec3(-xLength, 0, +zLength),//  3
        };
    }
}
