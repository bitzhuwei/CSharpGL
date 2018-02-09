using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlTexture : GLControl
    {
        private ITextureSource textureSource;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textureSource">source of texture.</param>
        public CtrlTexture(ITextureSource textureSource)
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Top)
        {
            var model = new CtrlTextureModel();
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlTextureModel.position);
            map.Add(inUV, CtrlTextureModel.uv);
            var methodBuilder = new RenderMethodBuilder(codes, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);
            this.textureSource = textureSource;

            this.Initialize();
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
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            base.RenderGUIBeforeChildren(arg);

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            Texture texture = this.textureSource.BindingTexture;
            if (texture != null)
            {
                method.Program.SetUniform("tex", texture);
            }
            method.Render();
        }
    }
}
