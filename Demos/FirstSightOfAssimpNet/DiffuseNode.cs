using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class DiffuseNode : ModernNode, IRenderable
    {
        public static DiffuseNode Create(DiffuseModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", DiffuseModel.strPosition);
            map.Add("inNormal", DiffuseModel.strNormal);
            var builder = new RenderMethodBuilder(array, map);//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new DiffuseNode(model, builder);
            node.Initialize();

            return node;
        }

        private DiffuseNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }


    }
}
