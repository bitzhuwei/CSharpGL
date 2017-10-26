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

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                string v = value == null ? string.Empty : value;
                if (v != text)
                {
                    text = v;
                    foreach (var c in v)
                    {
                        GlyphInfo glyphInfo;

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
