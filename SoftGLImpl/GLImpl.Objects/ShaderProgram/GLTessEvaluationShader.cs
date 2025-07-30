using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    class GLTessEvaluationShader : GLPipelineShader {
        public override int PipelineOrder { get { return 2; } }

        public GLTessEvaluationShader(uint id) : base(GLShader.Kind.TessEvaluationShader, id) { }
    }
}
