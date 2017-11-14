using System;
using System.Drawing;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// A billboard that renders text and always faces camera in 3D world. Its size is described by Width\Height(in pixels).
    /// </summary>
    public class TextBillboardNode : ModernNode
    {
        #region shaders

        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string width = "width";
        private const string height = "height";
        private const string screenSize = "screenSize";
        private const string glyphTexture = "tex";
        private const string textColor = "textColor";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";
uniform float " + width + @";
uniform float " + height + @";
uniform vec2 " + screenSize + @";

in vec2 inPosition;// character's quad's position(in pixels) relative to left bottom(0, 0).
in vec3 inSTR;// character's quad's texture coordinate.

out vec3 passSTR;

void main(void) {
	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
    position = position / position.w;
    position.xy += (inPosition - vec2(width / 2, height / 2)) / screenSize;
	gl_Position = position;

	passSTR = inSTR;
}
";
        private const string fragmentCode =
            @"#version 330 core

in vec3 passSTR;

uniform sampler2DArray " + glyphTexture + @";
uniform vec3 " + textColor + @";

out vec4 out_Color;

void main(void) {
    float a = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z))).a;
    out_Color = vec4(textColor, a);
}
";

        #endregion shaders

        /// <summary>
        /// Creates a billboard in 3D world. Its size is described by Width\Height(in pixels).
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static TextBillboardNode Create(int width, int height, GlyphServer glyphServer = null)
        {
            var vs = new VertexShader(vertexCode);// this vertex shader has no vertex attributes.
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            var blendState = new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
            var builder = new RenderMethodBuilder(provider, map, blendState);
            var node = new TextBillboardNode(width, height, new TextBillboard(), builder, glyphServer);
            node.Initialize();

            return node;
        }

        private GlyphServer glyphServer;

        /// <summary>
        /// Provides glyph information.
        /// </summary>
        public GlyphServer GlyphServer
        {
            get { return glyphServer; }
            set { glyphServer = value; }
        }

        private float _width;// TODO: make this an int type!
        /// <summary>
        /// Billboard's width(in pixels).
        /// </summary>
        public int Width
        {
            get { return (int)_width; }
            set { _width = (int)value; }
        }

        private float _height;
        /// <summary>
        /// Billboard's height(in pixels).
        /// </summary>
        public int Height
        {
            get { return (int)_height; }
            set { _height = (int)value; }
        }

        public vec3 _textColor = new vec3(0, 0, 0);
        /// <summary>
        /// 
        /// </summary>
        public Color TextColor
        {
            get { return this._textColor.ToColor(); }
            set { this._textColor = value.ToVec3(); }
        }

        private TextBillboardNode(int width, int height, IBufferSource model, RenderMethodBuilder renderUnitBuilder, GlyphServer glyphServer = null)
            : base(model, renderUnitBuilder)
        {
            this.Width = width;
            this.Height = height;

            if (glyphServer == null) { this.glyphServer = GlyphServer.defaultServer; }
            else { this.glyphServer = glyphServer; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            program.SetUniform(width, this._width);
            program.SetUniform(height, this._height);
            program.SetUniform(screenSize, new vec2(viewport[2], viewport[3]));
            program.SetUniform(glyphTexture, this.glyphServer.GlyphTexture);
            program.SetUniform(textColor, this._textColor);

            method.Render();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }

}