using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    class GLFragmentShader : GLPipelineShader {
        public override int PipelineOrder { get { return 4; } }

        public GLFragmentShader(uint id) : base(GLShader.Kind.FragmentShader, id) { }

    }
}
