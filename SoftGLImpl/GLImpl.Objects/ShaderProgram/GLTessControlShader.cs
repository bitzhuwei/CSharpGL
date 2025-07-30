using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    class GLTessControlShader : GLPipelineShader {
        public override int PipelineOrder { get { return 1; } }

        public GLTessControlShader(uint id) : base(GLShader.Kind.TessControlShader, id) { }
    }
}
