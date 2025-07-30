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
    /// Correspond to the Vn node unary_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnunary_expression : IFullFormat {
        // [32]: unary_expression : postfix_expression ;
        // [33]: unary_expression : '++' unary_expression ;
        // [34]: unary_expression : '--' unary_expression ;
        // [35]: unary_expression : unary_operator unary_expression ;

        private readonly List<IFullFormat> list = new();
        private readonly Vnpostfix_expression last;

        public Vnunary_expression(Vnpostfix_expression last) {
            this._tokenRange = new TokenRange(last);
            this.last = last;
        }

        public void Insert(Token token) {
            this._tokenRange.start = token.index;
            this.list.Insert(0, new unaryOp(token));
        }
        public void Insert(Vnunary_operator op) {
            this._tokenRange.start = op.Scope.start;
            this.list.Insert(0, op);
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var count = this.list.Count;
            var config1 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            for (var i = 0; i < count; i++) {
                var exp = this.list[i];
                exp.FullFormat(i == 0 ? preConfig : config1, writer, context);
                if (i + 1 < count) {
                    context.PrintCommentsBetween(exp, this.list[i + 1], config1, writer);
                }
                else {
                    context.PrintCommentsBetween(exp, this.last, config1, writer);
                }
            }
            {
                if (count > 0) {
                    config1.inlineBlank = 0;
                    this.last.FullFormat(config1, writer, context);
                }
                else {
                    this.last.FullFormat(preConfig, writer, context);
                }
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    var count = this.list.Count;
        //    for (var i = 0; i < count; i++) {
        //        var exp = this.list[i];
        //        exp.Format(writer, context);
        //        if (i + 1 < this.list.Count) { writer.Write(" "); }
        //    }
        //    {
        //        this.last.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    var count = this.list.Count;
        //    for (var i = 0; i < count; i++) {
        //        var exp = this.list[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        if (i + 1 < this.list.Count) { writer.Write(" "); }
        //    }
        //    {
        //        foreach (var item in this.last.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    //for (var i = this.list.Count - 1; i >= 0; i--) {
        //    //    var op = this.list[i];
        //    //    switch (op) {
        //    //    case PreOperator.addAdd: writer.Write(" ++"); yield return " ++"; break;
        //    //    case PreOperator.minusMinus: writer.Write(" --"); yield return " --"; break;
        //    //    case PreOperator.add: writer.Write(" +"); yield return " +"; break;
        //    //    case PreOperator.minus: writer.Write(" -"); yield return " -"; break;
        //    //    case PreOperator.trueFalse: writer.Write(" !"); yield return " !"; break;
        //    //    case PreOperator.reverse: writer.Write(" ~"); yield return " ~"; break;
        //    //    default: throw new NotImplementedException();
        //    //    }
        //    //}
        //    //foreach (var item2 in this.postfix_expression0.YieldTokens(writer, context)) {
        //    //    yield return item2;
        //    //}
        //}

        class unaryOp : IFullFormat {
            private Token token;

            public unaryOp(Token token) {
                this._tokenRange = new TokenRange(token);
                this.token = token;
            }

            private readonly TokenRange _tokenRange;
            public TokenRange Scope => _tokenRange;



            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(this.token, preConfig, writer);
            }

            //public void Format(TextWriter writer, FormatContext context) {
            //    writer.Write(this.token.value);
            //}

            //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
            //    writer.Write(this.token.value); yield return this.token.value;
            //}

        }
    }
}
