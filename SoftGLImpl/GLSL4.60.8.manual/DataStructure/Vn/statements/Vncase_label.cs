using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node case_label in the grammar(GLSL).
    /// </summary>
    partial class case_label_expression : Vncase_label {

        // [331] case_label : 'case' expression ':' ;

        private readonly Token tkCase;
        private Vnexpression expression1;
        private readonly Token tkColon;

        public case_label_expression(Token tkCase, Vnexpression expression1, Token tkColon) {
            this._tokenRange = new TokenRange(tkCase, tkColon);
            this.tkCase = tkCase;
            this.expression1 = expression1;
            this.tkColon = tkColon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkCase, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkCase, this.expression1, config, writer);
            this.expression1.FullFormat(config, writer, context);
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.expression1, this.tkColon, config, writer);
            context.PrintBlanksAnd(this.tkColon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkCase.value); writer.Write(" ");
        //    this.expression1.Format(writer, context); writer.Write(" ");
        //    writer.Write(this.tkColon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write("case");
        //    writer.Write(" ");
        //    yield return "case";
        //    foreach (var item in this.expression1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" "); writer.Write(":"); writer.Write(" ");
        //    yield return " : ";
        //}
    }
    /// <summary>
    /// Correspond to the Vn node case_label in the grammar(GLSL).
    /// </summary>
    partial class case_label_default : Vncase_label {
        // [332] case_label : 'default' ':' ;

        //public static readonly case_label_default instance = new();
        public readonly Token tkDefault;
        public readonly Token tkColon;
        public case_label_default(Token tkDefault, Token tkColon) {
            this._tokenRange = new TokenRange(tkDefault, tkColon);
            this.tkDefault = tkDefault;
            this.tkColon = tkColon;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkDefault, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var lastComment = context.PrintCommentsBetween(this.tkDefault, this.tkColon, config, writer);
            config.inlineBlank = lastComment != FormatContext.LastComment.None ? 1 : 0;
            context.PrintBlanksAnd(this.tkColon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDefault.value);
        //    writer.Write(this.tkColon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDefault.value);
        //    yield return "default";
        //    writer.Write(this.tkColon.value);
        //    yield return ":";
        //}
    }
    /// <summary>
    /// Correspond to the Vn node case_label in the grammar(GLSL).
    /// </summary>
    abstract partial class Vncase_label : Vnsimple_statement {
    }
}
