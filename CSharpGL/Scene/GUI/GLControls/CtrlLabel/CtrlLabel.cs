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
        private string text = string.Empty;
        private CtrlLabelModel labelModel;
        private VertexBuffer positionBuffer;
        private VertexBuffer uvBuffer;
        private IndexBuffer indexBuffer;

        /// <summary>
        /// 
        /// </summary>
        public unsafe string Text
        {
            get { return text; }
            set
            {
                string v = value == null ? string.Empty : value;
                if (v != text)
                {
                    text = v;

                    var server = GlyphServer.defaultServer;
                    const float height = 1.0f; // let's say height is 1.0f.
                    float totalWidth = 0;
                    var positionArray = (QuadStruct*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var uvArray = (QuadStruct*)this.uvBuffer.MapBuffer(MapBufferAccess.WriteOnly);
                    int index = 0;
                    foreach (var c in v)
                    {
                        GlyphInfo glyphInfo;
                        float wByH = 0;
                        if (server.GetGlyphInfo(c, out glyphInfo))
                        {
                            float w = glyphInfo.rightBottom.x - glyphInfo.leftBottom.x;
                            float h = glyphInfo.rightBottom.y - glyphInfo.rightTop.y;
                            wByH = height * w / h;
                        }
                        else
                        {
                            // put an empty glyph(square) here.
                            wByH = height * 1.0f / 1.0f;
                        }

                        var leftTop = new vec2(totalWidth, 0.5f);
                        var leftBottom = new vec2(totalWidth, -0.5f);
                        var rightBottom = new vec2(totalWidth + wByH, -0.5f);
                        var rightTop = new vec2(totalWidth + wByH, 0.5f);
                        positionArray[index] = new QuadStruct(leftTop, leftBottom, rightBottom, rightTop);
                        uvArray[index] = new QuadStruct(glyphInfo.leftTop, glyphInfo.leftBottom, glyphInfo.rightBottom, glyphInfo.rightTop);
                        totalWidth += wByH; // let's say height is 1.0f.
                        index++;
                        // todo: setup texture.
                    }

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CtrlLabel(int capacity, GUIAnchorStyles anchor, GUIPadding margin)
            : base(anchor, margin)
        {
            if (capacity < 0) { throw new ArgumentException("capacity"); }
            var model = new CtrlLabelModel(capacity);
            this.labelModel = model;
            var vs = new VertexShader(vert, inPosition, inUV);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlLabelModel.position);
            map.Add(inUV, CtrlLabelModel.uv);
            var methodBuilder = new RenderMethodBuilder(codes, map);
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
            this.indexBuffer = this.labelModel.GetIndexBuffer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            this.Scissor();
            this.Viewport();

            this.RenderUnit.Methods[0].Render(IndexBuffer.ControlMode.Random);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIAfterChildren(GUIRenderEventArgs arg)
        {
        }
    }
}
