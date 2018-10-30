using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Gocator
{
    partial class NodePointNode : ModernNode, IRenderable
    {
        private NodePointModel nodePointModel;
        public static NodePointNode Create(NodePointModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", NodePointModel.strPosition);
            map.Add("inColor", NodePointModel.strColor);
            var builder = new RenderMethodBuilder(array, map);//, new PointSizeSwitch(6));
            var node = new NodePointNode(model, builder);
            node.Initialize();

            return node;
        }

        private NodePointNode(NodePointModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.nodePointModel = model; }


    }
}
