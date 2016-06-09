using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer : Renderer
    {
        public SimplexNoiseRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }

    }
}
