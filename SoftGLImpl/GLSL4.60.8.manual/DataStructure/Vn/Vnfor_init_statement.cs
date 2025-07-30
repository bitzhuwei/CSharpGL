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
    /// Correspond to the Vn node for_init_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnfor_init_statement : IFullFormat {
        // [336]: for_init_statement : expression_statement ;
        // [337]: for_init_statement : declaration_statement ;

        // there is only one filed valid.
        //private expression_statement? expression_statement0;
        //private declaration_statement? declaration_statement0;
        private readonly IFullFormat statement;

        public Vnfor_init_statement(Vnexpression_statement expression_statement0) {
            this._tokenRange = new TokenRange(expression_statement0);
            this.statement = expression_statement0;
        }

        public Vnfor_init_statement(Vndeclaration_statement declaration_statement0) {
            this._tokenRange = new TokenRange(declaration_statement0);
            this.statement = declaration_statement0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.statement.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.statement.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.statement.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
