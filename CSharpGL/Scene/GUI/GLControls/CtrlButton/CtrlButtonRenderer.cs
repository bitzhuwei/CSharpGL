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
            var model = new CtrlImageModel();
            var vs = new VertexShader(vert, inPosition, inUV);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlImageModel.position);
            var methodBuilder = new RenderMethodBuilder(codes, map);
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
            var ctrl = control as CtrlImage;
            if (ctrl != null)
            {
                GL.Instance.Scissor(ctrl.Left, ctrl.Bottom, ctrl.Width, ctrl.Height);
                GL.Instance.Viewport(ctrl.Left, ctrl.Bottom, ctrl.Width, ctrl.Height);
                this.RenderUnit.Methods[0].Render();
            }
        }

        #endregion
    }
}
