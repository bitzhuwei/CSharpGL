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
    /// Correspond to the Vn node function_call_header_with_parameters in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_call_header_with_parameters : IFullFormat {
        // [27]: function_call_header_with_parameters : function_call_header assignment_expression ;
        // [28]: function_call_header_with_parameters : function_call_header_with_parameters ',' assignment_expression ;

        private readonly Vnfunction_call_header first0;
        private readonly Vnassignment_expression first1;
        private readonly List<Token> list0 = new();
        private readonly List<Vnassignment_expression> list1 = new();
        internal void Add(Token r1, Vnassignment_expression r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        /// <summary>
        /// func(param1, param2, ..)
        /// </summary>
        /// <param name="first0"></param>
        /// <param name="first1"></param>
        public Vnfunction_call_header_with_parameters(
            Vnfunction_call_header first0, Vnassignment_expression first1) {
            this._tokenRange = new TokenRange(first0, first1);
            this.first0 = first0;
            this.first1 = first1;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.first0.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.first0, this.first1, config, writer);
            {
                this.first1.FullFormat(config, writer, context);
            }
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var op = this.list0[i];
                config.inlineBlank = 0;
                {
                    if (first) {
                        context.PrintCommentsBetween(this.first1, op, config, writer);
                        first = false;
                    }
                    else {
                        context.PrintCommentsBetween(this.list1[i - 1], op, config, writer);
                    }
                }
                context.PrintBlanksAnd(op, config, writer);
                var exp = this.list1[i];
                config.inlineBlank = 1;
                context.PrintCommentsBetween(op, exp, config, writer);
                exp.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.first0.Format(writer, context);
        //    {
        //        this.first1.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var exp = this.list1[i];
        //        writer.Write(op.value);
        //        writer.Write(" ");
        //        exp.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.first0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    {
        //        foreach (var item in this.first1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var exp = this.list1[i];
        //        writer.Write(op.value); yield return op.value;
        //        writer.Write(" ");
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
