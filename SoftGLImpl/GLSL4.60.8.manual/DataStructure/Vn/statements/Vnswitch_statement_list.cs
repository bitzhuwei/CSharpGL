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
    /// Correspond to the Vn node switch_statement_list in the grammar(GLSL).
    /// </summary>
    partial class Vnswitch_statement_list : IFullFormat {
        // [329]: switch_statement_list : empty ;
        // [330]: switch_statement_list : statement_list ;
        private Vnstatement_list? statement_list0;

        public Vnswitch_statement_list(Vnstatement_list? statement_list0) {
            if (statement_list0 != null) { this._tokenRange = new TokenRange(statement_list0); }
            else { this._tokenRange = TokenRange.empty(); }
            this.statement_list0 = statement_list0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.statement_list0 != null) {
                this.statement_list0.FullFormat(preConfig, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.statement_list0 != null) {
        //        this.statement_list0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.statement_list0 != null) {
        //        foreach (var item2 in this.statement_list0.YieldTokens(writer, context)) {
        //            yield return item2;
        //        }
        //    }
        //}
    }
}
