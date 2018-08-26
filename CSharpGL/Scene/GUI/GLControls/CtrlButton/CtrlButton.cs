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
        /// <summary>
        /// A rectangle control that displays an image.
        /// </summary>
        public CtrlButton()
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Top)
        {
            var model = new CtrlButtonModel();
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlButtonModel.strPosition);
            map.Add(inColor, CtrlButtonModel.strColor);
            var methodBuilder = new RenderMethodBuilder(codes, map, new PolygonModeSwitch(PolygonMode.Fill), new LineWidthSwitch(2));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.Initialize();

            this.MouseDown += CtrlButton_MouseDown;
            this.MouseUp += CtrlButton_MouseUp;
        }

        private GUISize originalSize;
        private GUIPoint originalLocation;
        void CtrlButton_MouseUp(object sender, GLMouseEventArgs e)
        {
            if (e.Button == GLMouseButtons.Left)
            {
                this.Location = this.originalLocation;
                this.Size = this.originalSize;
            }
        }

        void CtrlButton_MouseDown(object sender, GLMouseEventArgs e)
        {
            if (e.Button == GLMouseButtons.Left)
            {
                this.originalLocation = this.Location;
                this.originalSize = this.Size;
                this.Size = new GUISize((int)(this.Width * 0.9f), (int)(this.Height * 0.9f));
                this.Location = new GUIPoint(
                    (int)(this.Location.X + this.Width * 0.05f),
                    (int)(this.Location.Y + this.Height * 0.05f));
            }
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

            var label = new CtrlLabel(100, GUIAnchorStyles.None);
            //label.RenderBackground = true; // for debug purpose.
            label.Initialize();
            label.AcceptPicking = false;
            this.label = label;

            this.Children.Add(label);

            label.TextChanged += label_TextChanged;
            label.Text = "Button";
        }

        void label_TextChanged(object sender, EventArgs e)
        {
            CtrlLabel label = this.label;
            // move label to center.
            {
                int diffX = this.Width - label.Width;
                int diffY = this.Height - label.Height;
                label.Location = new GUIPoint(diffX / 2, diffY / 2);
            }
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
