using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlButton : GLControl
    {
        private CtrlLabel label;

        /// <summary>
        /// 
        /// </summary>
        public CtrlButton()
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Top)
        {
            var model = new CtrlButtonModel();
            var vs = new VertexShader(vert, inPosition, inColor);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlButtonModel.position);
            map.Add(inColor, CtrlButtonModel.color);
            var methodBuilder = new RenderMethodBuilder(codes, map, new PolygonModeState(PolygonMode.Fill), new LineWidthState(2));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.Initialize();

            this.MouseDown += CtrlButton_MouseDown;
            this.MouseUp += CtrlButton_MouseUp;
        }

        void CtrlButton_MouseUp(object sender, GUIMouseEventArgs e)
        {
            if (e.Button == GUIMouseButtons.Left)
            {
                this.PressDown = false;
            }
        }

        void CtrlButton_MouseDown(object sender, GUIMouseEventArgs e)
        {
            if (e.Button == GUIMouseButtons.Left)
            {
                this.PressDown = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PressDown { get; set; }

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

            var label = new CtrlLabel(100, GUIAnchorStyles.None);
            label.Text = "Button";
            // move label to center.
            {
                int diffX = this.Width - label.Width;
                int diffY = this.Height - label.Height;
                label.Location = new GUIPoint(diffX / 2, diffY / 2);
            }
            //label.RenderBackground = true;
            label.BackgroundColor = new vec4(1, 0, 0, 1);
            label.Initialize();

            this.label = label;
            this.Children.Add(label);
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
            VertexArrayObject vao = method.VertexArrayObject;
            IndexBuffer indexBuffer = vao.IndexBuffer;
            indexBuffer.CurrentFrame = this.PressDown ? 1 : 0;
            method.Render(IndexBuffer.ControlMode.ByFrame);
        }
    }
}
