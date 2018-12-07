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
    public class DistanceFieldNode : PickableNode, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string tex = "tex";
        //private const string transparentBackground = "transparentBackground";
        private const string vertexCode =
            @"#version 330 core

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
@"#version 330 core
        
in vec2 passUV;

uniform sampler2D tex;
uniform vec4 textColor;
uniform vec4 backgroundColor;

out vec4 outColor;

void main() {
	float val = texture(tex, passUV).x;
	
	outColor = mix(textColor, backgroundColor, smoothstep(0.52, 0.48, val));
}
";


        //        private const string fragmentCode =
        //@"#version 330 core
        //
        //in vec2 passUV;
        //
        //uniform sampler2D tex;
        //
        //out vec4 outColor;
        //
        //void main() {
        //    const vec4 c1 = vec4(0.1, 0.1, 0.2, 1.0);
        //	const vec4 c2 = vec4(0.8, 0.9, 1.0, 1.0);
        //	float val = texture(tex, passUV).x;
        //	
        //	outColor = mix(c1, c2, smoothstep(0.52, 0.48, val));
        //}
        //";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static DistanceFieldNode Create()
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, DistanceFieldModel.strPosition);
            map.Add(inUV, DistanceFieldModel.strUV);
            var builder = new RenderMethodBuilder(provider, map, new BlendSwitch());
            var node = new DistanceFieldNode(new DistanceFieldModel(), DistanceFieldModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        private vec4 textColor = new vec4(1, 1, 1, 1);

        public Color TextColor
        {
            get { return textColor.ToColor(); }
            set { textColor = value.ToVec4(); }
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private DistanceFieldNode(DistanceFieldModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = model.ModelSize;
        }

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
            if (!this.IsInitialized) { this.Initialize(); }

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;

            var source = this.TextureSource;
            if (source != null)
            {
                program.SetUniform(tex, source.BindingTexture);
            }
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);
            program.SetUniform("textColor", this.textColor);
            program.SetUniform("backgroundColor", Color.SkyBlue.ToVec4());

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public ITextureSource TextureSource { get; set; }

    }


    public class DistanceFieldModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public DistanceFieldModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, (xLength + yLength) * 0.02f);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;


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
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                yield return this.uvBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
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
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
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
        /// <summary>
        /// four normals.
        /// </summary>
        private static readonly vec3[] normals = new vec3[]
        {
            new vec3(0, 0, 1),// 0
            new vec3(0, 0, 1),// 1
            new vec3(0, 0, 1),// 2
            new vec3(0, 0, 1),// 3
        };

    }
}
