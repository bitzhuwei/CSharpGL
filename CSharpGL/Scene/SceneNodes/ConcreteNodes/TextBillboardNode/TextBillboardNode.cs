using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

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
            map.Add(inPosition, GlyphsModel.position);
            map.Add(inSTR, GlyphsModel.STR);
            var blendState = new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
            var builder = new RenderMethodBuilder(provider, map, blendState);
            var node = new TextBillboardNode(width, height, new GlyphsModel(capacity), builder, glyphServer);
            node.Initialize();
            node.blend = blendState;

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
            if (width <= 0) { width = 1; }
            if (height <= 0) { height = 1; }

            this._width = width;
            this._height = height;
            this.widthByHeight = (float)width / (float)height;
            this.heightByWidth = (float)height / (float)width;

            this.textModel = model;

            if (glyphServer == null) { this.glyphServer = GlyphServer.DefaultServer; }
            else { this.glyphServer = glyphServer; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            // make sure textModel only returns once.
            this.positionBuffer = (from item in this.textModel.GetVertexAttribute(GlyphsModel.position) select item).First();
            this.strBuffer = (from item in this.textModel.GetVertexAttribute(GlyphsModel.STR) select item).First();
            this.drawCmd = (from item in this.textModel.GetDrawCommand() select item).First() as DrawArraysCmd;

            GlyphServer server = this.glyphServer;
            Texture texture = server.GlyphTexture;
            RenderMethod method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(glyphTexture, texture);
            program.SetUniform(width, this._width);
            program.SetUniform(height, this._height);
            program.SetUniform(textColor, this._color);
        }


        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        private BlendFuncSwitch blend;

        /// <summary>
        /// 
        /// </summary>
        public BlendFuncSwitch Blend
        {
            get { return blend; }
        }

        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        [Browsable(false)]
        [Category("IRenderable")]
        [Description("Render before/after children? Render children?")]
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);
            program.SetUniform(screenSize, new ivec2(viewport[2], viewport[3]));

            method.Render();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Text);
        }
    }

}