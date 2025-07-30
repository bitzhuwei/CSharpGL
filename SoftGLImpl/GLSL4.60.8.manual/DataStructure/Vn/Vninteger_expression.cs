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
    /// Correspond to the Vn node integer_expression in the grammar(GLSL).
    /// </summary>
    partial class Vninteger_expression : IFullFormat {
        // [20]: integer_expression : expression ;

        private Vnexpression expression0;

        public Vninteger_expression(Vnexpression expression0) {
            this._tokenRange = new TokenRange(expression0);
            this.expression0 = expression0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.expression0.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.expression0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.expression0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
