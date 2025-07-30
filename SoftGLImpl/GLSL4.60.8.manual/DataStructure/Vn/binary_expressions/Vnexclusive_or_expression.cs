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
    /// Correspond to the Vn node exclusive_or_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnexclusive_or_expression : IFullFormat {
        // [60]: exclusive_or_expression : and_expression ;
        // [61]: exclusive_or_expression : exclusive_or_expression '^' and_expression ;

        private readonly Vnand_expression first;
        private readonly List<Token> list0 = new();
        /// <summary>
        /// item ^ item ^ item ..
        /// </summary>
        private readonly List<Vnand_expression> list1 = new();
        internal void Add(Token r1, Vnand_expression r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        public Vnexclusive_or_expression(Vnand_expression first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                this.first.FullFormat(preConfig, writer, context);
            }
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var op = this.list0[i];
                if (first) {
                    context.PrintCommentsBetween(this.first, op, config, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list1[i - 1], op, config, writer);
                }
                context.PrintBlanksAnd(op, config, writer);
                var exp = this.list1[i];
                context.PrintCommentsBetween(op, exp, config, writer);
                exp.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        this.first.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var exp = this.list1[i];
        //        writer.Write(" ");
        //        writer.Write(op.value);
        //        writer.Write(" ");
        //        exp.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        foreach (var item in this.first.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var exp = this.list1[i];
        //        writer.Write(" ");
        //        writer.Write(op.value); yield return op.value;
        //        writer.Write(" ");
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
