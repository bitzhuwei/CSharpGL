using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DistanceFieldFont
{
    public partial class SingleLineNode : ModernNode, IRenderable
    {
        public static SingleLineNode Create(int capacity, GlyphServer glyphServer)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", SingleLineModel.strPosition);
            map.Add("inTexCoord", SingleLineModel.strTexCoord);
            var builder = new RenderMethodBuilder(provider, map, new BlendSwitch());
            var node = new SingleLineNode(new SingleLineModel(capacity, glyphServer), builder);
            node.Initialize();

            return node;
        }

        private vec4 textColor = new vec4(1, 1, 1, 1);

        public Color TextColor
        {
            get { return textColor.ToColor(); }
            set { textColor = value.ToVec4(); }
        }

        public string Text
        {
            get { return this.singleLineModel.Text; }
            set { this.singleLineModel.Text = value; }
        }

        private SingleLineModel singleLineModel;

        private SingleLineNode(SingleLineModel model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.singleLineModel = model;
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

            SingleLineModel lineModel = this.singleLineModel;
            GlyphServer glyphServer = lineModel.GetGlyphServer();
            Texture texture = glyphServer.GlyphsTexture;
            if (texture != null)
            {
                program.SetUniform("glyphTexture", texture);
            }
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("screenSize", new ivec2(viewport[2], viewport[3]));
            program.SetUniform("lineSize", new vec2(lineModel.LineWidth, lineModel.LineHeight));
            program.SetUniform("textColor", this.textColor);
            program.SetUniform("backgroundColor", Color.SkyBlue.ToVec4());

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
