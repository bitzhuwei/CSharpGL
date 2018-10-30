using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer
{
    partial class AnimationNode : ModernNode, IRenderable
    {
        private AnimationModel model;
        public static AnimationNode Create(AnimationModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", AnimationModel.strPosition);
            map.Add("inNormal", AnimationModel.strNormal);
            map.Add("inTexCoord", AnimationModel.strTexCoord);
            map.Add("inBoneIDs", AnimationModel.strBoneIDs);
            map.Add("inWeights", AnimationModel.strWeights);
            var builder = new RenderMethodBuilder(array, map);
            var node = new AnimationNode(model, builder);
            node.Initialize();

            return node;
        }

        private AnimationNode(AnimationModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


    }
}
