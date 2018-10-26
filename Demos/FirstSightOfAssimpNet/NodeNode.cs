using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class NodeNode : ModernNode, IRenderable
    {
        private NodeModel boneModel;
        public static NodeNode Create(NodeModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", NodeModel.strPosition);
            var builder = new RenderMethodBuilder(array, map, new PointSizeSwitch(6), new LineWidthSwitch(6));//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new NodeNode(model, builder);
            node.Initialize();

            return node;
        }

        private NodeNode(NodeModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.boneModel = model; }


    }
}
