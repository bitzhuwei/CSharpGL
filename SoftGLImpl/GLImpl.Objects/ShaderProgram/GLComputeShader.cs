using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftGLImpl {
    class GLComputeShader : GLShader {
        public GLComputeShader(uint id) : base(GLShader.Kind.ComputeShader, id) { }

        protected override string AfterCompile() {
            throw new NotImplementedException();
        }

        public override object ApplyCodeInstance() {
            // note: use ObjectPool
            throw new NotImplementedException();
        }
    }
}
