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
        /// 
        /// </summary>
        public CtrlButton()
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            this.Scissor();
            this.Viewport();

            this.RenderUnit.Methods[0].VertexArrayObject.IndexBuffer.CurrentFrame = this.PressDown ? 1 : 0;
            this.RenderUnit.Methods[0].Render(IndexBuffer.ControlMode.ByFrame);
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
