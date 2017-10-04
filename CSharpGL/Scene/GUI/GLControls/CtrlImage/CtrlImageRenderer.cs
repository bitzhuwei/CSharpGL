using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public partial class CtrlImageRenderer : GLControlRendererBase
    {
        private Bitmap bitmap;
        private bool autoDispose;
        #region IGLControlRenderer 成员

        /// <summary>
        /// 
        /// </summary>
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">bitmap to be displayed.</param>
        /// <param name="autoDispose">auto dispose <paramref name="bitmap"/> after this object's initialization.</param>
        public CtrlImageRenderer(Bitmap bitmap, bool autoDispose = false)
        {
            var model = new CtrlImageModel();
            var vs = new VertexShader(vert, inPosition, inUV);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlImageModel.position);
            map.Add(inUV, CtrlImageModel.uv);
            var methodBuilder = new RenderMethodBuilder(codes, map);
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.bitmap = bitmap;
            this.autoDispose = autoDispose;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.RenderUnit.Initialize();

            {
                var bitmap = this.bitmap;
                bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
                var texture = new Texture(TextureTarget.Texture2D,
                    new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap)));
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
        /// <param name="control"></param>
        public override void Render(GLControl control)
        {
            var ctrl = control as CtrlImage;
            if (ctrl != null)
            {
                GL.Instance.Scissor(ctrl.Left, ctrl.Bottom, ctrl.Width, ctrl.Height);
                GL.Instance.Viewport(ctrl.Left, ctrl.Bottom, ctrl.Width, ctrl.Height);

                RenderMethod method = this.RenderUnit.Methods[0];

                method.Render();
            }
        }

        #endregion
    }
}
