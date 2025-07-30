using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer {
    partial class NodePointNode : ModernNode, IRenderable {
        private NodePointModel nodePointModel;
        public static NodePointNode Create(NodePointModel model) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", NodePointModel.strPosition);
            var builder = new RenderMethodBuilder(program, map);
            var node = new NodePointNode(model, builder);
            node.Initialize();

            return node;
        }

        private NodePointNode(NodePointModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.nodePointModel = model; }


    }
}
