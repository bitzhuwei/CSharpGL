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
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
