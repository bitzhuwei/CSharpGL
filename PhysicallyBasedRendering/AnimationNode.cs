using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace PhysicallyBasedRendering
{
    partial class PBRNode : ModernNode, IRenderable
    {
        private PBRModel model;
        public static PBRNode Create(PBRModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", PBRModel.strPosition);
            map.Add("inNormal", PBRModel.strNormal);
            map.Add("inTexCoord", PBRModel.strTexCoord);
            var builder = new RenderMethodBuilder(array, map);
            var node = new PBRNode(model, builder);
            node.Initialize();

            return node;
        }

        private PBRNode(PBRModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


    }
}
