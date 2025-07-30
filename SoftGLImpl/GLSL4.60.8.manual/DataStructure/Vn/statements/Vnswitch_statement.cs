using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node switch_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnswitch_statement : Vnsimple_statement {

        // [328]: switch_statement : 'switch' '(' expression ')' '{' switch_statement_list '}' ;

        private readonly Token tkSwitch;
        private readonly Token tkLeftParenthesis;
        private Vnexpression expression4;
        private readonly Token tkRightParenthesis;
        private readonly Token tkLeftBrace;
        private Vnswitch_statement_list switch_statement_list1;
        private readonly Token tkRightBrace;

        public Vnswitch_statement(Token tkSwitch, Token tkLeftParenthesis,
            Vnexpression expression4, Token tkRightParenthesis,
            Token tkLeftBrace, Vnswitch_statement_list switch_statement_list1, Token tkRightBrace) {
            this._tokenRange = new TokenRange(tkSwitch, tkRightBrace);
            this.tkSwitch = tkSwitch;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.expression4 = expression4;
            this.tkRightParenthesis = tkRightParenthesis;
            this.tkLeftBrace = tkLeftBrace;
            this.switch_statement_list1 = switch_statement_list1;
            this.tkRightBrace = tkRightBrace;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkSwitch, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkSwitch, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.expression4, config, writer);
            this.expression4.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.expression4, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            config.inlineBlank = 1;
            context.PrintCommentsBetween(this.tkRightParenthesis, this.tkLeftBrace, config, writer);
            context.PrintBlanksAnd(this.tkLeftBrace, config, writer);
            context.PrintCommentsBetween(this.tkLeftBrace, this.switch_statement_list1, config, writer);
            var config2 = new BlankConfig(inlineBlank: 1,
                forceNewline: this.tkRightBrace.start.line > this.tkLeftBrace.end.line);
            this.switch_statement_list1.FullFormat(config2, writer, context);
            context.PrintCommentsBetween(this.switch_statement_list1, this.tkRightBrace, config, writer);
            context.PrintBlanksAnd(this.tkRightBrace, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkSwitch.value);
        //    writer.Write(" ");
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.expression4.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //    writer.Write(this.tkLeftBrace.value);
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //    this.switch_statement_list1.Format(writer, context);
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //    writer.Write(this.tkRightBrace.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkSwitch.value); yield return this.tkSwitch.value;
        //    writer.Write(" ");
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkSwitch.value;
        //    foreach (var item in this.expression4.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkSwitch.value;
        //    writer.Write(this.tkLeftBrace.value); yield return this.tkSwitch.value;
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //    foreach (var item in this.switch_statement_list1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //    writer.Write(this.tkRightBrace.value); yield return this.tkSwitch.value;
        //}
    }
}
