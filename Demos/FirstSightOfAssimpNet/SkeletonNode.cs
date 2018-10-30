using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class SkeletonNode : ModernNode, IRenderable
    {
        private SkeletonModel model;
        public static SkeletonNode Create(SkeletonModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", SkeletonModel.strPosition);
            map.Add("inColor", SkeletonModel.strColor);
            map.Add("inBoneIndex", SkeletonModel.strBoneIndex);
            var builder = new RenderMethodBuilder(array, map, new LineWidthSwitch(6));
            var node = new SkeletonNode(model, builder);
            node.Initialize();

            return node;
        }

        private SkeletonNode(SkeletonModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


    }
}
