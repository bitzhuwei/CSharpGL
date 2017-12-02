using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    partial class NormalMappingNode : ModernNode
    {
        public static NormalMappingNode Create()
        {
            var model = new NormalMappingModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("Position", NormalMappingModel.strPosition);
            map.Add("TexCoord", NormalMappingModel.strTexCoord);
            map.Add("Normal", NormalMappingModel.strNormal);
            map.Add("Tangent", NormalMappingModel.strTangent);
            var builder = new RenderMethodBuilder(array, map);
            var node = new NormalMappingNode(model, builder);

            node.Initialize();

            return node;
        }

        private NormalMappingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
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
