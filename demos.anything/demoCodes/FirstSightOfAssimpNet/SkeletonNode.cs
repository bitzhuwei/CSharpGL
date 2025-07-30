using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet {
    partial class SkeletonNode : ModernNode, IRenderable {
        private SkeletonModel model;
        public static SkeletonNode Create(SkeletonModel model) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", SkeletonModel.strPosition);
            map.Add("inColor", SkeletonModel.strColor);
            map.Add("inBoneIndex", SkeletonModel.strBoneIndex);
            var builder = new RenderMethodBuilder(program, map, new LineWidthSwitch(6));
            var node = new SkeletonNode(model, builder);
            node.Initialize();

            return node;
        }

        private SkeletonNode(SkeletonModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


    }
}
