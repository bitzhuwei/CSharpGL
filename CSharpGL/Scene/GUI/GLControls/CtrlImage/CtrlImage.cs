using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlImage : GLControl {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">bitmap to be displayed.</param>
        /// <param name="autoDispose">auto dispose <paramref name="bitmap"/> after this object's initialization.</param>
        public CtrlImage(IGLBitmap bitmap, bool autoDispose = false)
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Top) {
            var model = new CtrlImageModel();
            var vs = Shader.Create(Shader.Kind.vert, vert, out var _);
            var fs = Shader.Create(Shader.Kind.frag, frag, out var _);
            var program = GLProgram.Create(vert, frag); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlImageModel.position);
            map.Add(inUV, CtrlImageModel.uv);
            var methodBuilder = new RenderMethodBuilder(program, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            this.RenderUnit = new ModernRenderUnit(model, methodBuilder);

            this.bitmap = bitmap;
            this.autoDispose = autoDispose;

            this.Initialize();
        }

        private IGLBitmap? bitmap;
        private bool autoDispose;

        /// <summary>
        /// 
        /// </summary>
        public ModernRenderUnit RenderUnit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize() {
            this.RenderUnit.Initialize();

            {
                var bitmap = this.bitmap;
                if (bitmap != null) {
                    //bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
                    var texImageBitmap = new TexImageBitmap(bitmap);
                    var texture = new Texture(texImageBitmap);
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                    texture.Initialize();

                    if (this.autoDispose) {
                        if (bitmap is IDisposable disposable) { disposable.Dispose(); }
                    }
                    this.bitmap = null;

                    RenderMethod method = this.RenderUnit.Methods[0];
                    method.Program.SetUniform("tex", texture);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg) {
            base.RenderGUIBeforeChildren(arg);

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            method.Render();
        }
    }
}
