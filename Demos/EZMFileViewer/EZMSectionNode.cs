using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMSectionNode : ModernNode, IRenderable
    {
        public static EZMSectionNode Create(EZMSectionModel model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", EZMSectionModel.strPosition);
            var builder = new RenderMethodBuilder(array, map, new PolygonModeSwitch(PolygonMode.Line));
            var node = new EZMSectionNode(model, builder);
            node.Initialize();

            return node;
        }

        private EZMSectionNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

    }
}
