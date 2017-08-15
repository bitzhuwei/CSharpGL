using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode : ModernNode
    {

        public static BasicTessellationNode Create(ObjVNF model)
        {
            var vs = new VertexShader(renderVert, "Position_VS_in", "TexCoord_VS_in", "Normal_VS_in");
            var tc = new TessControlShader(renderTesc);
            var te = new TessEvaluationShader(renderTese);
            var fs = new FragmentShader(renderFrag);
            var provider = new ShaderArray(vs, tc, te, fs);
            var map = new AttributeMap();
            map.Add("Position_VS_in", ObjVNF.strPosition);
            map.Add("TexCoord_VS_in", ObjVNF.strTexCoord);
            map.Add("Normal_VS_in", ObjVNF.strNormal);
            var builder = new RenderUnitBuilder(provider, map);

            var node = new BasicTessellationNode(model, builder);
            node.Initialize();

            return node;
        }

        private BasicTessellationNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
