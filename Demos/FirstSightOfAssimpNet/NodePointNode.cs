using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class NodePointNode : ModernNode, IRenderable
    {
        private NodePointModel boneModel;
        public static NodePointNode Create(NodePointModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", NodePointModel.strPosition);
            var builder = new RenderMethodBuilder(array, map);
            var node = new NodePointNode(model, builder);
            node.Initialize();

            return node;
        }

        private NodePointNode(NodePointModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.boneModel = model; }


    }
}
