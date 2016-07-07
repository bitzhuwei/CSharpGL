using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    partial class ShaderToyRenderer : Renderer
    {

        public ShaderToyRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }

    }
}
