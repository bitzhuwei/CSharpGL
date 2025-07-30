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
    /// Correspond to the Vn node selection_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnselection_statement : Vnsimple_statement {

        // [323]: selection_statement : 'if' '(' expression ')' selection_rest_statement ;
        private readonly Token tkIf;
        private readonly Token tkLeftParenthesis;
        private Vnexpression expression2;
        private readonly Token tkRightParenthesis;
        private Vnselection_rest_statement selection_rest_statement0;

        public Vnselection_statement(Token tkIf, Token tkLeftParenthesis,
            Vnexpression expression2, Token tkRightParenthesis, Vnselection_rest_statement selection_rest_statement0) {
            this._tokenRange = new TokenRange(tkIf, selection_rest_statement0);
            this.tkIf = tkIf;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.expression2 = expression2;
            this.tkRightParenthesis = tkRightParenthesis;
            this.selection_rest_statement0 = selection_rest_statement0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkIf, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkIf, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.expression2, config, writer);
            this.expression2.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.expression2, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            config.inlineBlank = 1;
            context.PrintCommentsBetween(this.tkRightParenthesis, this.selection_rest_statement0, config, writer);
            this.selection_rest_statement0.FullFormat(config, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkIf.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.expression2.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //    this.selection_rest_statement0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkIf.value); yield return this.tkIf.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //    foreach (var item in this.expression2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //    foreach (var item in this.selection_rest_statement0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
