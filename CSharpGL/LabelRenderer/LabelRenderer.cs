using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class LabelRenderer : Renderer
    {

        public vec3 WorldPosition { get; set; }

        public LabelRenderer()
            : base(new LabelModel(), LabelRenderer.staticShaderCodes, LabelRenderer.staticMap)
        { }

    }
}
