using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    //partial class assignment_expression_e2e : assignment_expression {
    //    private unary_expression unary_expression2;
    //    private assignment_operator assignment_operator1;
    //    private assignment_expression assignment_expression0;

    //    public assignment_expression_e2e(unary_expression unary_expression2, assignment_operator assignment_operator1, assignment_expression assignment_expression0) {
    //        this.unary_expression2 = unary_expression2;
    //        this.assignment_operator1 = assignment_operator1;
    //        this.assignment_expression0 = assignment_expression0;
    //    }

    //    public override void Format(TextWriter writer, FormatContext context) {
    //        // [72]: assignment_expression : unary_expression assignment_operator assignment_expression ;
    //        this.unary_expression2.Format(writer, context);
    //        writer.Write(" ");
    //        this.assignment_operator1.Format(writer, context);
    //        writer.Write(" ");
    //        this.assignment_expression0.Format(writer, context);
    //    }
    //}
    /// <summary>
    /// Correspond to the Vn node assignment_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnassignment_expression : IFullFormat {
        // [72] assignment_expression : conditional_expression ;
        // [73] assignment_expression : unary_expression assignment_operator assignment_expression ;

        private readonly List<Vnunary_expression> list0 = new();
        private readonly List<Vnassignment_operator> list1 = new();
        private Vnconditional_expression last;

        public void Insert(Vnunary_expression exp, Vnassignment_operator op) {
            this._tokenRange.start = exp.Scope.start;
            this.list0.Insert(0, exp);
            this.list1.Insert(0, op);
        }

        public Vnassignment_expression(Vnconditional_expression last) {
            this._tokenRange = new TokenRange(last);
            this.last = last;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var count = this.list0.Count;
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);

            for (var i = 0; i < count; i++) {
                var exp = this.list0[i];
                var op = this.list1[i];
                exp.FullFormat(i == 0 ? preConfig : config, writer, context);
                context.PrintCommentsBetween(exp, op, config, writer);
                op.FullFormat(config, writer, context);
                if (i + 1 < count) {
                    context.PrintCommentsBetween(op, this.list0[i + 1], config, writer);
                }
                else {
                    context.PrintCommentsBetween(op, this.last, config, writer);
                }
            }
            {
                this.last.FullFormat(count > 0 ? config : preConfig, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    var count = this.list0.Count;
        //    for (var i = 0; i < count; i++) {
        //        var exp = this.list0[i];
        //        var op = this.list1[i];
        //        exp.Format(writer, context);
        //        writer.Write(" ");
        //        op.Format(writer, context);
        //    }
        //    {
        //        this.last.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    var count = this.list0.Count;
        //    for (var i = 0; i < count; i++) {
        //        var exp = this.list0[i];
        //        var op = this.list1[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(" ");
        //        foreach (var item in op.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    {
        //        foreach (var item in this.last.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
