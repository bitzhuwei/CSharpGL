using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    partial class BoneNode : ModernNode, IRenderable
    {
        private BoneModel boneModel;
        public static BoneNode Create(BoneModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", BoneModel.strPosition);
            var builder = new RenderMethodBuilder(array, map, new LineWidthSwitch(6));//, new PolygonModeSwitch(PolygonMode.Line));
            var node = new BoneNode(model, builder);
            node.Initialize();

            return node;
        }

        private BoneNode(BoneModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.boneModel = model; }


    }
}
