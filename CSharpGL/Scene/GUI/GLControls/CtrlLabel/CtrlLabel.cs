using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a label(string) as GUI.
    /// </summary>
    public partial class CtrlLabel : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public CtrlLabel(int capacity)
            : this(capacity, GUIAnchorStyles.Left | GUIAnchorStyles.Top)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="anchor"></param>
        public CtrlLabel(int capacity, GUIAnchorStyles anchor)
            : base(anchor)
        {
            if (capacity < 0) { throw new ArgumentException("capacity"); }

            this.Size = new GUISize(20, 20);

            var model = new GlyphsModel(capacity);
            this.labelModel = model;
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, GlyphsModel.position);
            map.Add(inSTR, GlyphsModel.STR);
            var blend = new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
            var methodBuilder = new RenderMethodBuilder(codes, map, blend);
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            this.RenderUnit.Initialize();

            // make sure labelModel only returns once.
            this.positionBuffer = (from item in this.labelModel.GetVertexAttribute(GlyphsModel.position) select item).First();
            this.stringBuffer = (from item in this.labelModel.GetVertexAttribute(GlyphsModel.STR) select item).First();
            this.drawCmd = (from item in this.labelModel.GetDrawCommand() select item).First() as DrawArraysCmd;

            GlyphServer server = GlyphServer.DefaultServer;
            Texture texture = server.GlyphTexture;
            string name = glyphTexture;
            this.RenderUnit.Methods[0].Program.SetUniform(name, texture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            base.RenderGUIBeforeChildren(arg);

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            method.Render();
        }
    }
}
