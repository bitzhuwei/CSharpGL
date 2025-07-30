using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node function_call in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_call : IFullFormat {
        // [21]: function_call : function_call_or_method ;

        private Vnfunction_call_or_method function_call_or_method0;

        public Vnfunction_call(Vnfunction_call_or_method function_call_or_method0) {
            this._tokenRange = new TokenRange(function_call_or_method0);
            this.function_call_or_method0 = function_call_or_method0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_call_or_method0.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.function_call_or_method0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_call_or_method0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
