using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace _3DTextureSlicing
{
    partial class SlicesNode : ModernNode
    {
        public enum RenderMode { Default = 0, Classification = 1, };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode CurrentMode { get; set; }

        private VertexBuffer vVertexBuffer;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SlicesNode Create()
        {
            var model = new SlicesModel();
            RenderMethodBuilder defaultBuilder, classificationBuilder;
            {
                var vs = new VertexShader(defaultVert, "vVertex");
                var fs = new FragmentShader(defaultFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", SlicesModel.position);
                defaultBuilder = new RenderMethodBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }
            {
                var vs = new VertexShader(classificationVert, "vVertex");
                var fs = new FragmentShader(classificationFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", SlicesModel.position);
                classificationBuilder = new RenderMethodBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }

            var node = new SlicesNode(model, defaultBuilder, classificationBuilder);
            node.Initialize();

            return node;
        }

        private SlicesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.vVertexBuffer = this.RenderUnit.Model.GetVertexAttributeBuffer(SlicesModel.position);

            Texture volume = Engine256Loader.Load();
            volume.TextureUnitIndex = 0;
            Texture lut = TransferFunctionLoader.Load();
            lut.TextureUnitIndex = 1;

            {
                RenderMethod unit = this.RenderUnit.Methods[(int)RenderMode.Default];
                ShaderProgram program = unit.Program;
                program.SetUniform("volume", volume);
            }
            {
                RenderMethod unit = this.RenderUnit.Methods[(int)RenderMode.Classification];
                ShaderProgram program = unit.Program;
                program.SetUniform("volume", volume);
                program.SetUniform("lut", lut);
            }
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            mat4 mv = view * model;
            this.ViewDirection = new vec3(-mv[0][2], -mv[1][2], -mv[2][2]);

            if (this.reSliceVolume)
            {
                SliceVolume(this.viewDir, this.sliceCount);

                this.reSliceVolume = false;
            }

            RenderMethod unit = this.RenderUnit.Methods[(int)this.CurrentMode];
            ShaderProgram program = unit.Program;
            program.SetUniform("MVP", projection * mv);
            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
