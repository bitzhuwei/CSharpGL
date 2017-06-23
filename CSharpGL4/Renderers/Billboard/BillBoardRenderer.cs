using System;
using System.Drawing;
using System.IO;

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
    /// 
    /// </summary>
    public class BillboardRenderer : Renderer
    {
        private const string inPosition = "inPosition";
        private const string inColor = "inColor";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string width = "width";
        private const string height = "height";
        private const string screenSize = "screenSize";
        private const string keepFront = "keepFront";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";
uniform float " + width + @";
uniform float " + height + @";
uniform vec2 " + screenSize + @";

out vec2 passUV;

const float value = 0.5;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));

	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
    position = position / position.w;
    vec2 diffPos = vertexes[gl_VertexID];
    position.xy += diffPos * vec2(width, height) / screenSize ;
	gl_Position = position;

	passUV = texCoord[gl_VertexID];
    
}
";
        //if (inColor.x >= 0) { color.x = inColor.x; } else { color.x = -inColor.x / 2.0; }
        //if (inColor.y >= 0) { color.y = inColor.y; } else { color.y = -inColor.y / 2.0; }
        //if (inColor.z >= 0) { color.z = inColor.z; } else { color.z = -inColor.z / 2.0; }
        private const string fragmentCode =
            @"#version 330 core

in vec3 passColor;

uniform sampler2D tex;
uniform bool " + keepFront + @" = false;

out vec2 passUV;

out vec4 out_Color;

void main(void) {
    vec4 color = texture(tex, passUV);
    if (color.a == 0)
    { discard; }
    else 
    {
        if (keepFront)
        {
            gl_FragDepth = 0;
        }

        out_Color = color; 
    }
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static BillboardRenderer Create(int width, int height)
        {
            var vertexShader = new VertexShader(vertexCode);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            var renderer = new BillboardRenderer(width, height, new Billboard(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private float _width;
        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get { return (int)_width; }
            set { _width = (int)value; }
        }

        private float _height;
        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            get { return (int)_height; }
            set { _height = (int)value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool KeepFront { get; set; }

        private BillboardRenderer(int width, int height, IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }


            //base.RenderBeforeChildren(arg);
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            this.DoRender(arg);

            //base.RenderAfterChildren(arg);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
            mat4 view = arg.Scene.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            this.SetUniform(projectionMatrix, projection);
            this.SetUniform(viewMatrix, view);
            this.SetUniform(modelMatrix, model);
            this.SetUniform(width, this._width);
            this.SetUniform(height, this._height);
            this.SetUniform(screenSize, new vec2(viewport[2], viewport[3]));
            this.SetUniform(keepFront, this.KeepFront);

            base.DoRender(arg);
        }
    }

    class Billboard : IBufferable
    {
        private IndexBuffer indexBuffer;

        #region IBufferable 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            return null;
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, 4);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}