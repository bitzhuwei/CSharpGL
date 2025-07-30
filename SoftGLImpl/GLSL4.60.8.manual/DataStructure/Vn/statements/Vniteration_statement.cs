using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node iteration_statement in the grammar(GLSL).
    /// </summary>
    partial class iteration_while : Vniteration_statement {

        // [333]: iteration_statement : 'while' '(' condition ')' statement ;

        private readonly Token tkWhile;
        private readonly Token tkLeftParenthesis;
        private Vncondition condition2;
        private readonly Token tkRightParenthesis;
        private Vnstatement statement0;

        public iteration_while(Token tkWhile, Token tkLeftParenthesis,
            Vncondition condition2, Token tkRightParenthesis, Vnstatement statement0) {
            this._tokenRange = new TokenRange(tkWhile, statement0);
            this.tkWhile = tkWhile;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.condition2 = condition2;
            this.tkRightParenthesis = tkRightParenthesis;
            this.statement0 = statement0;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkWhile, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkWhile, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.condition2, config, writer);
            this.condition2.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.condition2, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            config.inlineBlank = 1;
            context.PrintCommentsBetween(this.tkRightParenthesis, this.statement0, config, writer);
            this.statement0.FullFormat(config, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    // [336]: iteration_statement : 'while' '(' condition ')' statement_no_new_scope ;
        //    writer.Write(this.tkWhile.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.condition2.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    this.statement0.Format(writer, context);
        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkWhile.value); yield return this.tkWhile.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //    foreach (var item in this.condition2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    foreach (var item in this.statement0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //}
    }
    /// <summary>
    /// Correspond to the Vn node iteration_statement in the grammar(GLSL).
    /// </summary>
    partial class iteration_for : Vniteration_statement {

        // [335]: iteration_statement : 'for' '(' for_init_statement for_rest_statement ')' statement ;

        private readonly Token tkFor;
        private readonly Token tkLeftParenthesis;
        private Vnfor_init_statement for_init_statement3;
        private Vnfor_rest_statement for_rest_statement2;
        private readonly Token tkRightParenthesis;
        private Vnstatement statement0;

        public iteration_for(Token tkFor, Token tkLeftParenthesis,
            Vnfor_init_statement for_init_statement3, Vnfor_rest_statement for_rest_statement2,
            Token tkRightParenthesis, Vnstatement statement0) {
            this._tokenRange = new TokenRange(tkFor, statement0);
            this.tkFor = tkFor;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.for_init_statement3 = for_init_statement3;
            this.for_rest_statement2 = for_rest_statement2;
            this.tkRightParenthesis = tkRightParenthesis;
            this.statement0 = statement0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkFor, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkFor, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            config.inlineBlank = 0;
            this.for_init_statement3.FullFormat(config, writer, context);
            config.inlineBlank = 1;
            this.for_rest_statement2.FullFormat(config, writer, context);
            config.inlineBlank = 0;
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            config.inlineBlank = 1;
            this.statement0.FullFormat(config, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    // [338]: iteration_statement : 'for' '(' for_init_statement for_rest_statement ')' statement_no_new_scope ;
        //    writer.Write(this.tkFor.value); writer.Write(" ");
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.for_init_statement3.Format(writer, context); writer.Write(" ");
        //    this.for_rest_statement2.Format(writer, context); writer.Write(" ");
        //    writer.Write(this.tkRightParenthesis.value); writer.Write(" ");
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    this.statement0.Format(writer, context);
        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkFor.value); writer.Write(" "); yield return this.tkFor.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkFor.value;
        //    foreach (var item in this.for_init_statement3.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    foreach (var item in this.for_rest_statement2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.tkRightParenthesis.value); writer.Write(" "); yield return this.tkFor.value;
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    foreach (var item in this.statement0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //}
    }
    /// <summary>
    /// Correspond to the Vn node iteration_statement in the grammar(GLSL).
    /// </summary>
    partial class iteration_do_while : Vniteration_statement {
        // [334]: iteration_statement : 'do' statement 'while' '(' expression ')' ';' ;

        private readonly Token tkDo;
        private Vnstatement statement5;
        private readonly Token tkWhile;
        private readonly Token tkLeftParenthesis;
        private Vnexpression expression2;
        private readonly Token tkRightParenthesis;
        private readonly Token tkSemicolon;

        public iteration_do_while(Token tkDo, Vnstatement statement5,
            Token tkWhile, Token tkLeftParenthesis, Vnexpression expression2,
            Token tkRightParenthesis, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkDo, tkSemicolon);
            this.tkDo = tkDo;
            this.statement5 = statement5;
            this.tkWhile = tkWhile;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.expression2 = expression2;
            this.tkRightParenthesis = tkRightParenthesis;
            this.tkSemicolon = tkSemicolon;
        }

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkDo, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkDo, this.statement5, config, writer);
            this.statement5.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.statement5, this.tkWhile, config, writer);
            context.PrintBlanksAnd(this.tkWhile, config, writer);
            context.PrintCommentsBetween(this.tkWhile, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.expression2, config, writer);
            this.expression2.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.expression2, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            context.PrintCommentsBetween(this.tkRightParenthesis, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDo.value);
        //    writer.Write(" ");
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    this.statement5.Format(writer, context);
        //    writer.Write(" ");
        //    writer.Write(this.tkWhile.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.expression2.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //    writer.Write(this.tkSemicolon.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDo.value); yield return this.tkDo.value;
        //    writer.Write(" ");
        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    foreach (var item in this.statement5.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.tkWhile.value); yield return this.tkDo.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkDo.value;
        //    foreach (var item in this.expression2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkDo.value;
        //    writer.Write(this.tkSemicolon.value); yield return this.tkDo.value;
        //}
    }
    /// <summary>
    /// Correspond to the Vn node iteration_statement in the grammar(GLSL).
    /// </summary>
    abstract partial class Vniteration_statement : Vnsimple_statement {
    }
}
