using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class return_ : Vnjump_statement {

        // [344]: jump_statement : 'return' ';' ;
        // [345]: jump_statement : 'return' expression ';' ;

        private readonly Token tkReturn;
        private readonly Vnexpression? expression1;
        private readonly Token tkSemicolon;

        public return_(Token tkReturn, Vnexpression? expression1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkReturn, tkSemicolon);
            this.tkReturn = tkReturn;
            this.expression1 = expression1;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.expression1 != null) {
                context.PrintBlanksAnd(this.tkReturn, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(this.tkReturn, this.expression1, config, writer);
                this.expression1.FullFormat(config, writer, context);
                config.inlineBlank = 0;
                context.PrintCommentsBetween(this.expression1, this.tkSemicolon, config, writer);
                context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            }
            else {
                context.PrintBlanksAnd(this.tkReturn, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    if (this.expression1 != null) {
        //        writer.Write(this.tkReturn.value);
        //        writer.Write(" ");
        //        this.expression1.Format(writer, context);
        //        writer.Write(this.tkSemicolon.value);
        //    }
        //    else {
        //        writer.Write(this.tkReturn.value);
        //        writer.Write(this.tkSemicolon.value);
        //    }
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.expression1 != null) {
        //        writer.Write(this.tkReturn.value); yield return this.tkReturn.value;
        //        writer.Write(" ");
        //        foreach (var item in this.expression1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //    }
        //    else {
        //        writer.Write(this.tkReturn.value); yield return this.tkReturn.value;
        //        writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //    }
        //}
    }
    partial class discard : Vnjump_statement {

        // [346]: jump_statement : 'discard' ';' ;
        private readonly Token tkDiscard;
        private readonly Token tkSemicolon;

        public discard(Token tkDiscard, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkDiscard, tkSemicolon);
            this.tkDiscard = tkDiscard;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkDiscard, preConfig, writer);
            writer.Write(" = true");
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.tkDiscard, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDiscard.value);
        //    writer.Write(this.tkSemicolon.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkDiscard.value); yield return this.tkDiscard.value;
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }
    partial class continue_ : Vnjump_statement {
        // [342]: jump_statement : 'continue' ';' ;

        private readonly Token tkContinue;
        private readonly Token tkSemicolon;
        public continue_(Token tkContinue, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkContinue, tkSemicolon);
            this.tkContinue = tkContinue;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkContinue, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.tkContinue, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContinue.value);
        //    writer.Write(this.tkSemicolon.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContinue.value); yield return this.tkContinue.value;
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }

    partial class break_ : Vnjump_statement {
        // [343]: jump_statement : 'break' ';' ;

        private readonly Token tkBreak;
        private readonly Token tkSemicolon;

        public break_(Token tkBreak, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkBreak, tkSemicolon);
            this.tkBreak = tkBreak;
            this.tkSemicolon = tkSemicolon;
        }

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkBreak, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.tkBreak, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkBreak.value);
        //    writer.Write(this.tkSemicolon.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkBreak.value); yield return this.tkBreak.value;
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }

    /// <summary>
    /// Correspond to the Vn node jump_statement in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnjump_statement : Vnsimple_statement {
    }
}
