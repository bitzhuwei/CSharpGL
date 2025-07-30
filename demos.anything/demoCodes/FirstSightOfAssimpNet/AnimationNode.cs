using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet {
    partial class AnimationNode : ModernNode, IRenderable {
        private AnimationModel model;
        public static AnimationNode Create(AnimationModel model) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", AnimationModel.strPosition);
            map.Add("inNormal", AnimationModel.strNormal);
            map.Add("inTexCoord", AnimationModel.strTexCoord);
            map.Add("inBoneIDs", AnimationModel.strBoneIDs);
            map.Add("inWeights", AnimationModel.strWeights);
            var builder = new RenderMethodBuilder(program, map);
            var node = new AnimationNode(model, builder);
            node.Initialize();

            return node;
        }

        private AnimationNode(AnimationModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


    }
}
