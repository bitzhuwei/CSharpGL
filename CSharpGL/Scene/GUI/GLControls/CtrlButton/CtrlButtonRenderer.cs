using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public partial class CtrlButtonRenderer : GLControlRendererBase
    {
        #region IGLControlRenderer 成员

        /// <summary>
        /// 
        /// </summary>
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public CtrlButtonRenderer()
        {
            var model = new CtrlButtonModel();
            var vs = new VertexShader(vert, inPosition, inColor);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlButtonModel.position);
            map.Add(inColor, CtrlButtonModel.color);
            var methodBuilder = new RenderMethodBuilder(codes, map, new PolygonModeState(PolygonMode.Line), new LineWidthState(2));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.RenderUnit.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public override void Render(GLControl control)
        {
            if (control != null)
            {
                control.Scissor();
                control.Viewport();

                this.RenderUnit.Methods[0].Render(IndexBuffer.ControlMode.ByFrame);
            }
        }

        #endregion
    }
}
