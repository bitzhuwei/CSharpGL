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
    /// Correspond to the Vn node relational_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnrelational_expression : IFullFormat {
        // [50]: relational_expression : shift_expression ;
        // [51]: relational_expression : relational_expression '<' shift_expression ;
        // [52]: relational_expression : relational_expression '>' shift_expression ;
        // [53]: relational_expression : relational_expression '<=' shift_expression ;
        // [54]: relational_expression : relational_expression '>=' shift_expression ;

        private readonly Vnshift_expression first;
        private readonly List<Token> list0 = new();
        /// <summary>
        /// item == item != item ..
        /// </summary>
        private readonly List<Vnshift_expression> list1 = new();
        internal void Add(Token r1, Vnshift_expression r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }


        public Vnrelational_expression(Vnshift_expression first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


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
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var op = this.list0[i];
        //        writer.Write(" "); writer.Write(op.value); writer.Write(" ");
        //        var exp = this.list1[i];
        //        exp.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        foreach (var item in this.first.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var op = this.list0[i];
        //        writer.Write(" "); writer.Write(op.value); writer.Write(" ");
        //        yield return op.value;
        //        var exp = this.list1[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
