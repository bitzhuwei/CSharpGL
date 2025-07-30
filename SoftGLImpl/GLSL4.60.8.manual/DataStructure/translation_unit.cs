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
    /// extracted info from syntax tree(<see cref="LRNode"/>).
    /// </summary>
    public partial class translation_unit : IFullFormat {
        private readonly Vntranslation_unit @final;
        internal translation_unit(Vntranslation_unit @final) {
            this.@final = @final;
            this._scope = new TokenRange(@final);
        }
        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                var start = 0;
                var end = this.final.Scope.start - 1;
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(start, end, config, writer);
            }
            context.PrintBlanksAnd(this.@final, preConfig, writer);
            {
                var start = this.final.Scope.end + 1;
                var end = context.tokens.Count - 1;
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(start, end, config, writer);
            }
        }

        //public void Format(TextWriter writer, FormatContext context) {
        //    this.final.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    var enumerable = this.final.YieldTokens(writer, context);
        //    var enumerator = enumerable.GetEnumerator();
        //    for (int i = 0; i < context.tokens.Count; i++) {
        //        var token = context.tokens[i];
        //        if (token.type == CompilerGLSL.st.blockComment块) {
        //            PrintBlockComment(token, writer, context);
        //        }
        //        else if (token.type == CompilerGLSL.st.inlineComment行) {
        //            PrintInlineComment(token, writer, context);
        //        }
        //        else {
        //            enumerator.MoveNext();
        //            // this line prints token.
        //            var formattedString = enumerator.Current;
        //        }
        //    }
        //    yield return string.Empty;
        //}

        private static void PrintInlineComment(Token token, TextWriter writer, FormatContext context) {
            writer.WriteLine();
            context.PrintTab(writer);
            writer.WriteLine(token.value);
            context.PrintTab(writer);
        }

        private static void PrintBlockComment(Token token, TextWriter writer, FormatContext context) {
            writer.WriteLine();
            context.PrintTab(writer);
            writer.WriteLine(token.value);
            context.PrintTab(writer);
        }
    }
}
