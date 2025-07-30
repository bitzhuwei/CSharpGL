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
    /// Correspond to the Vn node declaration_statement in the grammar(GLSL).
    /// </summary>
    partial class Vndeclaration_statement : Vnsimple_statement {
        // [307] declaration_statement : declaration ;

        private Vndeclaration declaration0;

        public Vndeclaration_statement(Vndeclaration declaration0) {
            this._tokenRange = new TokenRange(declaration0);
            this.declaration0 = declaration0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.declaration0.FullFormat(preConfig, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.declaration0.Format(writer, context);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.declaration0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
