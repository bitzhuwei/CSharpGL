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
    /// Correspond to the Vn node function_prototype in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_prototype : IFullFormat {
        // [99]: function_prototype : function_declarator ')' ;

        private Vnfunction_declarator function_declarator1;
        private readonly Token tkRightParenthesis;

        public Vnfunction_prototype(Vnfunction_declarator function_declarator1, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(function_declarator1, tkRightParenthesis);
            this.function_declarator1 = function_declarator1;
            this.tkRightParenthesis = tkRightParenthesis;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_declarator1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.function_declarator1, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.function_declarator1.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_declarator1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //}
    }
}
