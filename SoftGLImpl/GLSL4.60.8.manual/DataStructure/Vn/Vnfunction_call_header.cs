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
    /// Correspond to the Vn node function_call_header in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_call_header : IFullFormat {
        // [29]: function_call_header : function_identifier '(' ;

        private Vnfunction_identifier function_identifier1;
        private readonly Token tkLeftParenthesis;

        public Vnfunction_call_header(
            Vnfunction_identifier function_identifier1, Token tkLeftParenthesis) {
            this._tokenRange = new TokenRange(function_identifier1, tkLeftParenthesis);
            this.function_identifier1 = function_identifier1;
            this.tkLeftParenthesis = tkLeftParenthesis;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (preConfig != null) {
                context.PrintBlanksBefore(this.function_identifier1, preConfig.Value, writer);
            }
            if (context.inInitArray) { writer.Write("new "); }
            context.PrintBlanksAnd(this.function_identifier1, null, writer);

            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.function_identifier1, this.tkLeftParenthesis, config, writer);
            if (context.inInitArray) { // replace '(', in "uniform float values[] = float[](1.0, 1.0, 1.0);"
                context.PrintBlanksBefore(this.tkLeftParenthesis, config, writer);
                writer.Write("{");
            }
            else {
                context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.function_identifier1.Format(writer, context);
        //    writer.Write(this.tkLeftParenthesis.value);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_identifier1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //}
    }
}
