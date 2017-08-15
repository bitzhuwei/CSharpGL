using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode : ModernNode
    {

        public static BasicTessellationNode Create()
        {
            {
                var vs = new VertexShader(renderVert, "Position_VS_in", "TexCoord_VS_in", "Normal_VS_in");
                var tc = new TessControlShader(renderTesc);
                var te = new TessEvaluationShader(renderTese);
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, tc, te, fs);
            }
            throw new NotImplementedException();
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
