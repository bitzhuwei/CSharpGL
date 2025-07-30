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
    /// Correspond to the Vn node expression_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnexpression_statement : Vnsimple_statement {
        // [321]: expression_statement : ';' ;
        // [322]: expression_statement : expression ';' ;

        private Vnexpression? expression1;
        private readonly Token tkSemicolon;

        public Vnexpression_statement(Vnexpression? expression1, Token tkSemicolon) {
            if (expression1 != null) { this._tokenRange = new TokenRange(expression1, tkSemicolon); }
            else { this._tokenRange = new TokenRange(tkSemicolon); }
            this.expression1 = expression1;
            this.tkSemicolon = tkSemicolon;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.expression1 != null) {
                this.expression1.FullFormat(preConfig, writer, context);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.expression1, this.tkSemicolon, config, writer);
                context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            }
            else {
                context.PrintBlanksAnd(this.tkSemicolon, preConfig, writer);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    if (this.expression1 != null) { this.expression1.Format(writer, context); }
        //    writer.Write(this.tkSemicolon.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.expression1 != null) {
        //        foreach (var item in this.expression1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }
}
