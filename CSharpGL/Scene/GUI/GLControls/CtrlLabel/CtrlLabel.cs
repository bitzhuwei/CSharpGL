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

            var model = new CtrlLabelModel(capacity);
            this.labelModel = model;
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlLabelModel.position);
            map.Add(inUV, CtrlLabelModel.uv);
            map.Add(inTextureIndex, CtrlLabelModel.textureIndex);
            var blend = new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
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

            this.positionBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.position);
            this.uvBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.uv);
            this.textureIndexBuffer = this.labelModel.GetVertexAttributeBuffer(CtrlLabelModel.textureIndex);
            this.indexBuffer = this.labelModel.GetIndexBuffer() as ZeroIndexBuffer;

            GlyphServer server = GlyphServer.defaultServer;
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
            method.Render(IndexBuffer.ControlMode.Random);
        }
    }
}
