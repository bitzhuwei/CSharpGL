using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
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
    public class RectangleNode : PickableNode
    {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string tex = "tex";
        private const string transparentBackground = "transparentBackground";
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
uniform bool " + transparentBackground + @" = false;

layout(location = 0) out vec4 out_Color;
//out vec4 out_Color;

void main(void) {
	vec4 color = texture(tex, passUV);
    if (transparentBackground)
    {
        if (color.a == 0) { discard; }
        else { out_Color = color; }
    }
    else 
    {
        out_Color = color;
    }
}
";

        public bool TransparentBackground { get; set; }

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static RectangleNode Create()
        {
            var vertexShader = new VertexShader(vertexCode, inPosition, inUV);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add(inPosition, RectangleModel.strPosition);
            map.Add(inUV, RectangleModel.strUV);
            var builder = new RenderUnitBuilder(provider, map);
            var renderer = new RectangleNode(new RectangleModel(), RectangleModel.strPosition, builder);
            renderer.Initialize();

            return renderer;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private RectangleNode(RectangleModel model, string positionNameInIBufferable, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = model.ModelSize;
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var renderUnit = this.RenderUnits[0]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;

            var source = this.TextureSource;
            if (source != null)
            {
                program.SetUniform(tex, source.BindingTexture);
            }
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            program.SetUniform(transparentBackground, this.TransparentBackground);

            renderUnit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public ITextureSource TextureSource { get; set; }

    }

    class RectangleModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public RectangleModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, (xLength + yLength) * 0.02f);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;

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
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
            }

            return this.indexBuffer;
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

    }
}
