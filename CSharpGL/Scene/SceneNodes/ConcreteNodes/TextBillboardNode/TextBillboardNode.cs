using System;
using System.Drawing;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// A billboard that renders text and always faces camera in 3D world. Its size is described by Width\Height(in pixels).
    /// </summary>
    public partial class TextBillboardNode : ModernNode
    {
        /// <summary>
        /// Creates a billboard in 3D world. Its size is described by Width\Height(in pixels).
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="capacity">Maximum characters count.</param>
        /// <param name="glyphServer"></param>
        /// <returns></returns>
        public static TextBillboardNode Create(int width, int height, int capacity, GlyphServer glyphServer = null)
        {
            var vs = new VertexShader(vertexCode);// this vertex shader has no vertex attributes.
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            var blendState = new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new TextBillboardNode(width, height, new GlyphsModel(capacity), builder, glyphServer);
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


        private TextBillboardNode(int width, int height, GlyphsModel model, RenderMethodBuilder renderUnitBuilder, GlyphServer glyphServer = null)
            : base(model, renderUnitBuilder)
        {
            this.Width = width;
            this.Height = height;
            this.textModel = model;

            if (glyphServer == null) { this.glyphServer = GlyphServer.defaultServer; }
            else { this.glyphServer = glyphServer; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.positionBuffer = this.textModel.GetVertexAttributeBuffer(GlyphsModel.position);
            this.strBuffer = this.textModel.GetVertexAttributeBuffer(GlyphsModel.str);
            this.indexBuffer = this.textModel.GetIndexBuffer() as ZeroIndexBuffer;

            GlyphServer server = this.glyphServer;
            Texture texture = server.GlyphTexture;
            RenderMethod method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(glyphTexture, texture);
            program.SetUniform(width, _width);
            program.SetUniform(height, _height);
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
            program.SetUniform(screenSize, new vec2(viewport[2], viewport[3]));

            method.Render(IndexBuffer.ControlMode.Random);
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