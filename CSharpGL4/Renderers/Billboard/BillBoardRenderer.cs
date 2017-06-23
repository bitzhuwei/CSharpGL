using System;
using System.Drawing;
using System.IO;

namespace CSharpGL
{
    // NOTE: The BillboardRenderer of this version keeps its size with the same ratio.
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
        private const string billboardSize = "billboardSize";
        private const string screenSize = "screenSize";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";
uniform vec2 " + billboardSize + @";
uniform vec2 " + screenSize + @";

out vec2 passUV;

const float value = 0.5;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));

	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
    position = position / position.w;
    vec2 diffPos = vertexes[gl_VertexID];
    position.xy += diffPos * billboardSize / screenSize ;
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

out vec2 passUV;

out vec4 out_Color;

void main(void) {
    vec4 color = texture(tex, passUV);
    //if (color.a == 0)
    //{ discard; }
    //else 
    { out_Color = color; }
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static BillboardRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            var renderer = new BillboardRenderer(new Billboard(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        /// <summary>
        ///
        /// </summary>
        public ivec2 PixelSize { get; set; }

        private BillboardRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
            this.PixelSize = new ivec2(100, 10);
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
            this.SetUniform(billboardSize, new vec2(viewport[2], viewport[3]));//this.PixelSize);
            this.SetUniform(screenSize, new vec2(viewport[2], viewport[3]));

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