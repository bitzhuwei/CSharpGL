using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMDummyNode : ModernNode, IRenderable
    {
        public static EZMDummyNode Create(EZMDummyModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", EZMDummyModel.strPosition);
            var builder = new RenderMethodBuilder(array, map, new PolygonModeSwitch(PolygonMode.Line));
            var node = new EZMDummyNode(model, builder);
            node.Initialize();

            return node;
        }

        private EZMDummyNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

    }
}
