using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class PositionNode : ModernNode, IRenderable
    {
        public static PositionNode Create(PositionModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", PositionModel.strPosition);
            map.Add("inNormal", PositionModel.strNormal);
            var builder = new RenderMethodBuilder(array, map);//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new PositionNode(model, builder);
            node.Initialize();

            return node;
        }

        private PositionNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }


    }
}
