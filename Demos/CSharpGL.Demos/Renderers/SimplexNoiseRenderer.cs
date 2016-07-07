using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer : Renderer
    {

        public SimplexNoiseRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }

    }
}
