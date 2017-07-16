using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render a Cube with single color in modern opengl.
    /// </summary>
    public class TexturedCubeRenderer : PickableRenderer
    {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string tex = "tex";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec2 " + inUV + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

out vec2 passUV;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
    passUV = inUV;
}
";
        private const string fragmentCode =
            @"#version 330 core
in vec2 passUV;

uniform sampler2D " + tex + @";

layout(location = 0) out vec4 out_Color;
//out vec4 out_Color;

void main(void) {
    out_Color = texture(tex, passUV);
}
";
        private Texture texture;
        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static TexturedCubeRenderer Create(Texture texture)
        {
            var vertexShader = new VertexShader(vertexCode, inPosition, inUV);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add(inPosition, TexturedCubeModel.strPosition);
            map.Add(inPosition, TexturedCubeModel.strUV);
            var renderer = new TexturedCubeRenderer(new TexturedCubeModel(), provider, map, inPosition);
            renderer.texture = texture;
            renderer.Initialize();

            return renderer;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private TexturedCubeRenderer(TexturedCubeModel model, IShaderProgramProvider renderProgramProvider,
            AttributeMap attributeMap, string positionNameInVertexShader,
            params GLState[] switches)
            : base(model, renderProgramProvider, attributeMap, positionNameInVertexShader, switches)
        {
            this.ModelSize = model.ModelSize;
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
            this.SetUniform(tex, this.texture);

            base.DoRender(arg);
        }

    }

    class TexturedCubeModel : IBufferable
    {
        public vec3 ModelSize { get; private set; }

        public TexturedCubeModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, (xLength + yLength) * 0.02f);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;

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
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.uvBuffer;
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
        /// six quads' vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, -yLength, +zLength),//  0
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
