using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SoftGLImpl {
    class GLVertexShader : GLPipelineShader {
        //public PassVariable? gl_PositionVar { get; private set; }

        public override int PipelineOrder { get { return 0; } }

        public GLVertexShader(GLuint name) : base(GLShader.Kind.VertexShader, name) { }

        public int GetAttribLocation(string name) {
            int result = -1;
            if (this.InfoLog.Length > 0) { return result; }
            Dictionary<string, PassVariable> dict = this.name2inVar;
            if (dict == null) { return result; }
            if (dict.TryGetValue(name, out var v)) {
                result = (int)v.location;
            }

            return result;
        }

        //protected override string AfterCompile() {
        //    string result = base.AfterCompile();
        //    if (result != string.Empty) { return result; }
        //    if (this.codeType == null) { return result; }

        //    // find the "out vec4 gl_Position;" variable.
        //    var fieldInfo = this.codeType.GetField("gl_Position");
        //    if (fieldInfo == null) { result = "gl_Position not found!"; return result; }
        //    object[] attribute = fieldInfo.GetCustomAttributes(typeof(OutAttribute), false);
        //    if (attribute != null && attribute.Length > 0) {// this is a 'in ...;' field.
        //        this.gl_PositionVar = new PassVariable(fieldInfo);
        //    }
        //    else {
        //        result = "gl_Position has no [Out] attribute.";
        //    }

        //    return result;
        //}
    }
}
