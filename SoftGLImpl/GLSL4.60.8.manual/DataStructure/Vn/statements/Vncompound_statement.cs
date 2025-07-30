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
    /// Correspond to the Vn node compound_statement in the grammar(GLSL).
    /// </summary>
    partial class Vncompound_statement : Vnstatement {

        // [317] compound_statement : '{' '}' ;
        // [318] compound_statement : '{' statement_list '}' ;

        private readonly Token tkLeftBrace;
        private Vnstatement_list? statement_list1;
        private readonly Token tkRightBrace;

        public Vncompound_statement(Token tkLeftBrace, Vnstatement_list? statement_list1, Token tkRightBrace) {
            this._tokenRange = new TokenRange(tkLeftBrace, tkRightBrace);
            this.tkLeftBrace = tkLeftBrace;
            this.statement_list1 = statement_list1;
            this.tkRightBrace = tkRightBrace;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            { // print {
                context.PrintBlanksAnd(this.tkLeftBrace, preConfig, writer);
            }
            var forceNewline = this.tkRightBrace.start.line > this.tkLeftBrace.end.line;
            context.IncreaseTab();
            if (this.statement_list1 != null) {
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                // comment after { need not to print in next line
                context.PrintCommentsBetween(this.tkLeftBrace, this.statement_list1, config, writer);
                {
                    var config2 = config;
                    config2.forceNewline = forceNewline;
                    // statements need to print in next line
                    this.statement_list1.FullFormat(config2, writer, context);
                }
                // print comments between statement list and }
                context.PrintCommentsBetween(this.statement_list1, this.tkRightBrace, config, writer);
            }
            else {
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                // print comments between { and }
                context.PrintCommentsBetween(this.tkLeftBrace, this.tkRightBrace, config, writer);
            }
            context.DecreaseTab();
            { // print }
                var config = new BlankConfig(inlineBlank: 1, forceNewline);
                context.PrintBlanksAnd(this.tkRightBrace, config, writer);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkLeftBrace.value); writer.WriteLine();
        //    if (this.statement_list1 != null) {
        //        context.IncreaseTab();
        //        context.PrintTab(writer);
        //        this.statement_list1.Format(writer, context);
        //        writer.WriteLine();
        //        context.DecreaseTab();
        //        context.PrintTab(writer);
        //    }
        //    writer.Write(this.tkRightBrace.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkLeftBrace.value); yield return this.tkLeftBrace.value; writer.WriteLine();
        //    if (this.statement_list1 != null) {
        //        context.IncreaseTab();
        //        context.PrintTab(writer);
        //        foreach (var item in this.statement_list1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.WriteLine();
        //        context.DecreaseTab();
        //        context.PrintTab(writer);
        //    }
        //    writer.Write(this.tkRightBrace.value); yield return this.tkRightBrace.value;
        //}
    }
}
