using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class function_call_with_parameters : Vnfunction_call_generic {
        // [23]: function_call_generic : function_call_header_with_parameters ')' ;

        private Vnfunction_call_header_with_parameters r1;
        private readonly Token tkRightParenthesis;

        public function_call_with_parameters(
            Vnfunction_call_header_with_parameters r1, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(r1, tkRightParenthesis);
            this.r1 = r1;
            this.tkRightParenthesis = tkRightParenthesis;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var firstTokens = context.tokens[r1.Scope.start];
            var newlines = this.tkRightParenthesis.start.line > firstTokens.end.line;
            if (newlines) { context.IncreaseTab(); }
            this.r1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.r1, this.tkRightParenthesis, config, writer);
            if (context.inInitArray) { // replace ')' in "uniform float values[] = float[](1.0, 1.0, 1.0);"
                context.PrintBlanksBefore(this.tkRightParenthesis, config, writer);
                writer.Write("}");
            }
            else {
                context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            }
            if (newlines) { context.DecreaseTab(); }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.r1.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.r1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //}
    }
    partial class function_call_no_parameters : Vnfunction_call_generic {
        // [24]: function_call_generic : function_call_header_no_parameters ')' ;

        private Vnfunction_call_header_no_parameters r1;
        private readonly Token tkRightParenthesis;

        public function_call_no_parameters(
            Vnfunction_call_header_no_parameters r1, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(r1, tkRightParenthesis);
            this.r1 = r1;
            this.tkRightParenthesis = tkRightParenthesis;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.r1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.r1, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.r1.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.r1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //}
    }
    /// <summary>
    /// Correspond to the Vn node function_call_generic in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnfunction_call_generic : IFullFormat {

        // [23] function_call_generic : function_call_header_with_parameters ')' ;
        // [24] function_call_generic : function_call_header_no_parameters ')' ;
        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
