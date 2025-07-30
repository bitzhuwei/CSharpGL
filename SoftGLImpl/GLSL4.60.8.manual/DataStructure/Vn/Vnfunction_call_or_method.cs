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
    /// Correspond to the Vn node function_call_or_method in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_call_or_method : IFullFormat {
        // [22]: function_call_or_method : function_call_generic ;

        private Vnfunction_call_generic function_call_generic0;

        public Vnfunction_call_or_method(Vnfunction_call_generic function_call_generic0) {
            this._tokenRange = new TokenRange(function_call_generic0);
            this.function_call_generic0 = function_call_generic0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_call_generic0.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.function_call_generic0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_call_generic0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
