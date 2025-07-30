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
    /// Correspond to the Vn node struct_declarator_list in the grammar(GLSL).
    /// </summary>
    partial class Vnstruct_declarator_list : IFullFormat {
        // [298]: struct_declarator_list : struct_declarator ;
        // [299]: struct_declarator_list : struct_declarator_list ',' struct_declarator ;

        public readonly Vnstruct_declarator first;
        public readonly List<Token> list0 = new();
        public readonly List<Vnstruct_declarator> list1 = new();
        internal void Add(Token r1, Vnstruct_declarator r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        public Vnstruct_declarator_list(Vnstruct_declarator first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                this.first.FullFormat(preConfig, writer, context);
            }
            var config0 = new BlankConfig(inlineBlank: 0, forceNewline: false);
            var config1 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var op = this.list0[i];
                if (first) {
                    context.PrintCommentsBetween(this.first, op, config0, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list1[i - 1], op, config0, writer);
                }
                context.PrintBlanksAnd(op, config0, writer);
                var exp = this.list1[i];
                context.PrintCommentsBetween(op, exp, config1, writer);
                exp.FullFormat(config1, writer, context);
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
