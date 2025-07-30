using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace VolumeRendering.Slicing {
    partial class SlicesNode : ModernNode, IRenderable {
        public enum RenderMode { Default = 0, Classification = 1, };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode CurrentMode { get; set; }

        private VertexBuffer inPositionBuffer;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SlicesNode Create() {
            var model = new SlicesModel();
            RenderMethodBuilder defaultBuilder, classificationBuilder;
            {
                var program = GLProgram.Create(defaultVert, defaultFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", SlicesModel.position);
                defaultBuilder = new RenderMethodBuilder(program, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            }
            {
                var program = GLProgram.Create(classificationVert, classificationFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", SlicesModel.position);
                classificationBuilder = new RenderMethodBuilder(program, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            }

            var node = new SlicesNode(model, defaultBuilder, classificationBuilder);
            node.Initialize();

            return node;
        }

        private SlicesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            // make sure model only returns once.
            this.inPositionBuffer = (from item in this.RenderUnit.Model.GetVertexAttribute(SlicesModel.position) select item).First();

            var bmp = new Bitmap(1, 1);
            var bmpG = Graphics.FromImage(bmp);
            var font = new Font("Arial", 256, GraphicsUnit.Pixel);
            string text = "煮";
            SizeF bigSize = bmpG.MeasureString(text, font);
            var bitmap = new Bitmap((int)Math.Ceiling(bigSize.Width), (int)Math.Ceiling(bigSize.Height));
            using (var g = Graphics.FromImage(bitmap)) { g.DrawString(text, font, Brushes.White, 0, 0); }
            Texture volume = AmberLoader.Load(bitmap);
            volume.textureUnitIndex = 0;
            Texture lut = TransferTextureLoader.Load();
            lut.textureUnitIndex = 1;

            {
                RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Default];
                GLProgram program = method.Program;
                program.SetUniform("volume", volume);
            }
            {
                RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Classification];
                GLProgram program = method.Program;
                program.SetUniform("volume", volume);
                program.SetUniform("lut", lut);
            }
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            mat4 mv = view * model;
            this.ViewDirection = new vec3(-mv[0][2], -mv[1][2], -mv[2][2]);

            if (this.reSliceVolume) {
                SliceVolume(this.ViewDirection, this.sliceCount);

                this.reSliceVolume = false;
            }

            RenderMethod method = this.RenderUnit.Methods[(int)this.CurrentMode];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * mv);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
