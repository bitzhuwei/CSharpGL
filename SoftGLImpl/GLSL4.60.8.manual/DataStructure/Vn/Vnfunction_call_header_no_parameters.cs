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
    /// Correspond to the Vn node function_call_header_no_parameters in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_call_header_no_parameters : Vnfunction_call_generic {
        // [25]: function_call_header_no_parameters : function_call_header 'void' ;
        // [26]: function_call_header_no_parameters : function_call_header ;

        private Vnfunction_call_header function_call_header1;
        /// <summary>
        /// void
        /// </summary>
        private Token? tkVoid;

        /// <summary>
        /// func(void) or func()
        /// </summary>
        /// <param name="function_call_header1"></param>
        /// <param name="tkVoid"></param>
        public Vnfunction_call_header_no_parameters(
            Vnfunction_call_header function_call_header1, Token? tkVoid) {
            if (tkVoid != null) { this._tokenRange = new TokenRange(function_call_header1, tkVoid); }
            else { this._tokenRange = new TokenRange(function_call_header1); }
            this.function_call_header1 = function_call_header1;
            this.tkVoid = tkVoid;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_call_header1.FullFormat(preConfig, writer, context);
            if (this.tkVoid != null) {
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.function_call_header1, this.tkVoid, config, writer);
                //context.PrintBlanksAnd(tkVoid, config, writer);
                context.PrintBlanksBefore(tkVoid, config, writer); writer.Write($"/*{tkVoid.value}*/");
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.function_call_header1.Format(writer, context);
        //    if (this.tkVoid != null) { writer.Write(this.tkVoid.value); }
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_call_header1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    if (this.tkVoid != null) {
        //        writer.Write(this.tkVoid.value); yield return this.tkVoid.value;
        //    }
        //}
    }
}
