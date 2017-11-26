//using System;
//using System.Drawing;
//using System.IO;

//namespace CSharpGL
//{
//    // Y
//    // ^
//    // |
//    // |
//    // 1--------------------0
//    // |      .             |
//    // |      |             |
//    // |                    |
//    // |    .               |
//    // |   .                |
//    // |  .                 |
//    // | .                  |
//    // 2--------------------3 --> X
//    //
//    /// <summary>
//    /// A billboard that always faces camera in 3D world. Its size is described by Width\Height(in pixels).
//    /// </summary>
//    public class TextureBillboardNode : ModernNode
//    {
//        #region shaders

//        private const string projectionMatrix = "projectionMatrix";
//        private const string viewMatrix = "viewMatrix";
//        private const string modelMatrix = "modelMatrix";
//        private const string width = "width";
//        private const string height = "height";
//        private const string screenSize = "screenSize";
//        private const string tex = "tex";
//        private const string transparentBackground = "transparentBackground";
//        private const string delta = "delta";

//        private const string vertexCode =
//            @"#version 330 core
//
//uniform mat4 " + projectionMatrix + @";
//uniform mat4 " + viewMatrix + @";
//uniform mat4 " + modelMatrix + @";
//uniform float " + width + @";
//uniform float " + height + @";
//uniform vec2 " + screenSize + @";
//
//out vec2 passUV;
//
//const float value = 0.5;
//
//void main(void) {
//	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
//	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));
//
//	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
//    position = position / position.w;
//    vec2 diffPos = vertexes[gl_VertexID];
//    position.xy += diffPos * vec2(width, height) / screenSize ;
//	gl_Position = position;
//
//	passUV = texCoord[gl_VertexID];
//}
//";
//        private const string fragmentCode =
//            @"#version 330 core
//
//uniform sampler2D " + tex + @";
//uniform bool " + transparentBackground + @" = false;
//uniform float " + delta + @" = 0.01;
//
//in vec2 passUV;
//
//out vec4 out_Color;
//
//void main(void) {
//    vec4 color = texture(tex, passUV);
//    if (transparentBackground)
//    {
//        if (color.a == 0)
//        {
//            vec4 color0 = texture(tex, vec2(passUV.x -  delta, passUV.y - delta));
//            vec4 color1 = texture(tex, vec2(passUV.x -  delta, passUV.y - 0));
//            vec4 color2 = texture(tex, vec2(passUV.x -  delta, passUV.y + delta));
//            vec4 color3 = texture(tex, vec2(passUV.x -  0, passUV.y - delta));
//            vec4 color4 = texture(tex, vec2(passUV.x -  0, passUV.y + delta));
//            vec4 color5 = texture(tex, vec2(passUV.x +  delta, passUV.y - delta));
//            vec4 color6 = texture(tex, vec2(passUV.x +  delta, passUV.y - 0));
//            vec4 color7 = texture(tex, vec2(passUV.x +  delta, passUV.y + delta));
//            if (color0.a != 0 || color1.a != 0 || color2.a != 0 || color3.a != 0
//                || color4.a != 0 || color5.a != 0 || color6.a != 0 || color7.a != 0)
//            {
//                out_Color = (color0 + color1 + color2 + color3 + color + color4 + color5 + color6 + color7) / 9;
//            }
//            else
//            {
//                discard;
//            }
//        }
//        else 
//        {
//            out_Color = color; 
//        }
//    }
//    else
//    {
//        out_Color = color; 
//    }
//
//}
//";

//        #endregion shaders

//        /// <summary>
//        /// Creates a billboard in 3D world. Its size is described by Width\Height(in pixels).
//        /// </summary>
//        /// <param name="textureSource"></param>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        /// <returns></returns>
//        public static TextureBillboardNode Create(ITextureSource textureSource, int width, int height)
//        {
//            var vs = new VertexShader(vertexCode);// this vertex shader has no vertex attributes.
//            var fs = new FragmentShader(fragmentCode);
//            var provider = new ShaderArray(vs, fs);
//            var map = new AttributeMap();
//            var builder = new RenderMethodBuilder(provider, map);
//            var node = new TextureBillboardNode(textureSource, width, height, new Billboard(), builder);
//            node.Initialize();

//            return node;
//        }

//        private ITextureSource textureSource;
//        /// <summary>
//        /// Source of texture object.
//        /// </summary>
//        public ITextureSource TextureSource
//        {
//            get { return textureSource; }
//            set { textureSource = value; }
//        }

//        private float _width;
//        /// <summary>
//        /// Billboard's width(in pixels).
//        /// </summary>
//        public int Width
//        {
//            get { return (int)_width; }
//            set { _width = (int)value; }
//        }

//        private float _height;
//        /// <summary>
//        /// Billboard's height(in pixels).
//        /// </summary>
//        public int Height
//        {
//            get { return (int)_height; }
//            set { _height = (int)value; }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public bool TransparentBackground { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public float Delta { get; set; }

//        private TextureBillboardNode(ITextureSource textureSource, int width, int height, IBufferSource model, RenderMethodBuilder builder)
//            : base(model, builder)
//        {
//            this.TextureSource = textureSource;
//            this.Width = width;
//            this.Height = height;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arg"></param>
//        public override void RenderBeforeChildren(RenderEventArgs arg)
//        {
//            if (!this.IsInitialized) { Initialize(); }

//            ICamera camera = arg.CameraStack.Peek();
//            mat4 projection = camera.GetProjectionMatrix();
//            mat4 view = camera.GetViewMatrix();
//            mat4 model = this.GetModelMatrix();
//            var viewport = new int[4];
//            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

//            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
//            ShaderProgram program = method.Program;
//            program.SetUniform(projectionMatrix, projection);
//            program.SetUniform(viewMatrix, view);
//            program.SetUniform(modelMatrix, model);
//            program.SetUniform(width, this._width);
//            program.SetUniform(height, this._height);
//            program.SetUniform(screenSize, new vec2(viewport[2], viewport[3]));
//            program.SetUniform(tex, this.textureSource.BindingTexture);
//            program.SetUniform(transparentBackground, this.TransparentBackground);
//            program.SetUniform(delta, this.Delta);

//            method.Render();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arg"></param>
//        public override void RenderAfterChildren(RenderEventArgs arg)
//        {
//        }
//    }

//    class Billboard : IBufferSource
//    {
//        private IndexBuffer indexBuffer;

//        #region IBufferSource 成员

//        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
//        {
//            return null;// not need any vertex buffer.
//        }

//        public IndexBuffer GetIndexBuffer()
//        {
//            if (this.indexBuffer == null)
//            {
//                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, 4);
//            }

//            return this.indexBuffer;
//        }

//        #endregion
//    }
//}