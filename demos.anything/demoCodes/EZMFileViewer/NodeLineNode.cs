using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer {
    partial class NodeLineNode : ModernNode, IRenderable {
        private NodeLineModel nodePointModel;
        public static NodeLineNode Create(NodeLineModel model) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", NodeLineModel.strPosition);
            map.Add("inColor", NodeLineModel.strColor);
            var builder = new RenderMethodBuilder(program, map, new LineWidthSwitch(6));
            var node = new NodeLineNode(model, builder);
            node.Initialize();

            return node;
        }

        private NodeLineNode(NodeLineModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.nodePointModel = model; }


    }
}
