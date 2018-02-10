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
    public partial class CtrlImage : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">bitmap to be displayed.</param>
        /// <param name="autoDispose">auto dispose <paramref name="bitmap"/> after this object's initialization.</param>
        public CtrlImage(Bitmap bitmap, bool autoDispose = false)
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Top)
        {
            var model = new CtrlImageModel();
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlImageModel.position);
            map.Add(inUV, CtrlImageModel.uv);
            var methodBuilder = new RenderMethodBuilder(codes, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.bitmap = bitmap;
            this.autoDispose = autoDispose;

            this.Initialize();
        }

        private Bitmap bitmap;
        private bool autoDispose;

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

            {
                var bitmap = this.bitmap;
                bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
                var texImageBitmap = new TexImageBitmap(bitmap);
                var texture = new Texture(texImageBitmap);
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                texture.Initialize();

                if (this.autoDispose) { bitmap.Dispose(); }
                this.bitmap = null;

                RenderMethod method = this.RenderUnit.Methods[0];
                method.Program.SetUniform("tex", texture);
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
