using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace _3DTextureSlicing
{
    partial class SlicesNode : ModernNode
    {
        private VertexBuffer vVertexBuffer;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SlicesNode Create()
        {
            var model = new SlicesModel();
            RenderUnitBuilder textureSlicerBuilder;
            {
                var vs = new VertexShader(textureSlicerVert, "vVertex");
                var fs = new FragmentShader(textureSlicerFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", SlicesModel.position);
                textureSlicerBuilder = new RenderUnitBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }

            var node = new SlicesNode(model, textureSlicerBuilder);
            node.Initialize();

            return node;
        }

        private SlicesNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.vVertexBuffer = this.model.GetVertexAttributeBuffer(SlicesModel.position);

            Texture texture = VolumeDataLoader.LoadData();
            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform("volume", texture);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            mat4 mv = view * model;
            vec3 viewDirection = new vec3(-mv[0][2], -mv[1][2], -mv[2][2]);
            if (this.viewDir != viewDirection)
            {
                this.viewDir = viewDirection;
                SliceVolume();
            }

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform("MVP", projection * mv);
            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
