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
    /// Correspond to the Vn node array_specifier in the grammar(GLSL).
    /// </summary>
    partial class Vnarray_specifier : IFullFormat {
        // [164] array_specifier : '[' ']' ;
        // [165] array_specifier : '[' conditional_expression ']' ;
        // [166] array_specifier : array_specifier '[' ']' ;
        // [167] array_specifier : array_specifier '[' conditional_expression ']' ;


        private readonly Token first0;
        private readonly Vnconditional_expression? first1;
        private readonly Token first2;
        /// <summary>
        /// [
        /// </summary>
        private readonly List<Token> list0 = new();
        private readonly List<Vnconditional_expression?> list1 = new();
        /// <summary>
        /// ]
        /// </summary>
        private readonly List<Token> list2 = new();
        internal void Add(Token r2, Vnconditional_expression? r1, Token r0) {
            this.list0.Add(r2);
            this.list1.Add(r1);
            this.list2.Add(r0);
            this._tokenRange.end = r0.index;
        }

        public Vnarray_specifier(Token leftBracket, Vnconditional_expression? exp, Token rightBracket) {
            this._tokenRange = new TokenRange(leftBracket, rightBracket);
            this.first0 = leftBracket;
            this.first1 = exp;
            this.first2 = rightBracket;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            {
                context.PrintBlanksAnd(this.first0, preConfig, writer);
                if (this.first1 != null) {
                    context.PrintCommentsBetween(this.first0, this.first1, config, writer);
                    this.first1.FullFormat(config, writer, context);
                    context.PrintCommentsBetween(this.first1, this.first2, config, writer);
                }
                context.PrintBlanksAnd(this.first2, config, writer);
            }
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var leftBracket = this.list0[i];
                var exp = this.list1[i];
                var rightBracket = this.list2[i];
                if (first) {
                    context.PrintCommentsBetween(this.first2, leftBracket, config, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list2[i - 1], leftBracket, config, writer);
                }
                context.PrintBlanksAnd(leftBracket, config, writer);
                if (exp != null) {
                    context.PrintCommentsBetween(leftBracket, exp, config, writer);
                    exp.FullFormat(config, writer, context);
                    context.PrintCommentsBetween(exp, rightBracket, config, writer);
                }
                else {
                    context.PrintCommentsBetween(leftBracket, rightBracket, config, writer);
                }
                context.PrintBlanksAnd(rightBracket, config, writer);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        writer.Write(this.first0.value);
        //        if (this.first1 != null) {
        //            this.first1.Format(writer, context);
        //        }
        //        writer.Write(this.first2.value);
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var leftBracket = this.list0[i];
        //        var exp = this.list1[i];
        //        var rightBracket = this.list2[i];
        //        writer.Write(leftBracket.value);
        //        if (exp != null) {
        //            exp.Format(writer, context);
        //        }
        //        writer.Write(rightBracket.value);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        writer.Write(this.first0.value); yield return this.first0.value;
        //        if (this.first1 != null) {
        //            foreach (var item in this.first1.YieldTokens(writer, context)) {
        //                yield return item;
        //            }
        //        }
        //        writer.Write(this.first2.value); yield return this.first2.value;
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var leftBracket = this.list0[i];
        //        var exp = this.list1[i];
        //        var rightBracket = this.list2[i];
        //        writer.Write(leftBracket.value); yield return leftBracket.value;
        //        if (exp != null) {
        //            foreach (var item in exp.YieldTokens(writer, context)) {
        //                yield return item;
        //            }
        //        }
        //        writer.Write(rightBracket.value); yield return rightBracket.value;
        //    }
        //}
    }
}
