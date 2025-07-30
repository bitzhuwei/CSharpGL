using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet {
    partial class JointNode : ModernNode, IRenderable {
        private JointModel nodePointModel;
        public static JointNode Create(JointModel model) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", JointModel.strPosition);
            map.Add("inBoneIndex", JointModel.strBoneIndex);
            var builder = new RenderMethodBuilder(program, map);
            var node = new JointNode(model, builder);
            node.Initialize();

            return node;
        }

        private JointNode(JointModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.nodePointModel = model; }


    }
}
