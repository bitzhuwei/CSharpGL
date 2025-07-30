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
    /// Correspond to the Vn node constant_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnconstant_expression : IFullFormat {
        // [87] constant_expression : conditional_expression ;

        private Vnconditional_expression conditional_expression0;

        public Vnconstant_expression(Vnconditional_expression conditional_expression0) {
            this._tokenRange = new TokenRange(conditional_expression0);
            this.conditional_expression0 = conditional_expression0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.conditional_expression0.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.conditional_expression0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.conditional_expression0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
