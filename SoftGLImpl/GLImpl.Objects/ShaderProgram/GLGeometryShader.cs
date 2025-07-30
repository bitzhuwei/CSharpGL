using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    class GLGeometryShader : GLPipelineShader {
        public override int PipelineOrder { get { return 3; } }

        public GLGeometryShader(uint id) : base(GLShader.Kind.GeometryShader, id) { }
    }
}
