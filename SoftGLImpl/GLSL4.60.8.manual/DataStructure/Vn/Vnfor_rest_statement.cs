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
    /// Correspond to the Vn node for_rest_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnfor_rest_statement : IFullFormat {
        // [340]: for_rest_statement : conditionopt ';' ;
        // [341]: for_rest_statement : conditionopt ';' expression ;

        private Vnconditionopt conditionopt2;
        private readonly Token tkSemicolon;
        private Vnexpression? expression;

        public Vnfor_rest_statement(Vnconditionopt conditionopt2, Token tkSemicolon, Vnexpression? expression) {
            if (expression != null) { this._tokenRange = new TokenRange(conditionopt2, expression); }
            else { this._tokenRange = new TokenRange(conditionopt2, tkSemicolon); }
            this.conditionopt2 = conditionopt2;
            this.tkSemicolon = tkSemicolon;
            this.expression = expression;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.conditionopt2.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.conditionopt2, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            if (this.expression != null) {
                var lastComment = context.PrintCommentsBetween(this.tkSemicolon, this.expression, config, writer);
                config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                this.expression.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.conditionopt2.Format(writer, context);
        //    writer.Write(this.tkSemicolon.value);
        //    if (this.expression != null) {
        //        writer.Write(" "); this.expression.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.conditionopt2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //    if (this.expression != null) {
        //        writer.Write(" ");
        //        foreach (var item in this.expression.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
