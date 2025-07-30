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
    /// Correspond to the Vn node function_header_with_parameters in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_header_with_parameters : Vnfunction_declarator {
        // [102]: function_header_with_parameters : function_header parameter_declaration ;
        // [103]: function_header_with_parameters : function_header_with_parameters ',' parameter_declaration ;

        private Vnfunction_header first0;
        private readonly Vnparameter_declaration fisrt1;
        private readonly List<Token> list0 = new();
        private readonly List<Vnparameter_declaration> list1 = new();
        internal void Add(Token r1, Vnparameter_declaration r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        public Vnfunction_header_with_parameters(Vnfunction_header first0, Vnparameter_declaration first1) {
            this._tokenRange = new TokenRange(first0, first1);
            this.first0 = first0;
            this.fisrt1 = first1;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                this.first0.FullFormat(preConfig, writer, context);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.first0, this.fisrt1, config, writer);
                this.fisrt1.FullFormat(config, writer, context);
            }
            var config0 = new BlankConfig(inlineBlank: 0, forceNewline: false);
            var config1 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var op = this.list0[i];
                if (first) {
                    context.PrintCommentsBetween(this.fisrt1, op, config0, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list1[i - 1], op, config0, writer);
                }
                context.PrintBlanksAnd(op, config0, writer);
                var dec = this.list1[i];
                context.PrintCommentsBetween(op, dec, config1, writer);
                dec.FullFormat(config1, writer, context);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.first0.Format(writer, context);
        //    {
        //        this.fisrt1.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var dec = this.list1[i];
        //        writer.Write(op.value);
        //        writer.Write(" ");
        //        dec.Format(writer, context);
        //    }
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.first0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    {
        //        foreach (var item in this.fisrt1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list1.Count; i++) {
        //        var op = this.list0[i];
        //        var dec = this.list1[i];
        //        writer.Write(op.value); yield return op.value;
        //        writer.Write(" ");
        //        foreach (var item in dec.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
