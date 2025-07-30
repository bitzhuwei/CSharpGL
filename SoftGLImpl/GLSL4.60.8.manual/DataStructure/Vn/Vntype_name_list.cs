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
    /// Correspond to the Vn node type_name_list in the grammar(GLSL).
    /// </summary>
    partial class Vntype_name_list : IFullFormat {
        // [160]: type_name_list : 'type_name' ;
        // [161]: type_name_list : type_name_list ',' 'type_name' ;

        private readonly Token first;
        private readonly List<Token> list0 = new();
        private readonly List<Token> list1 = new();
        internal void Add(Token r1, Token r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.index;
        }

        public Vntype_name_list(Token first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                if (preConfig != null) {
                    context.PrintBlanksBefore(this.first, preConfig.Value, writer);
                }
                writer.Write("\""); writer.Write(this.first.value); writer.Write("\"");
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
                context.PrintBlanksBefore(exp, config1, writer);
                writer.Write("\""); writer.Write(exp.value); writer.Write("\"");
            }
            //original version
            //{
            //    context.PrintBlanksAnd(this.first, preConfig, writer);
            //}
            //var config0 = new BlankConfig(inlineBlank: 0, forceNewline: false);
            //var config1 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //var first = true;
            //for (var i = 0; i < this.list0.Count; i++) {
            //    var op = this.list0[i];
            //    if (first) {
            //        context.PrintCommentsBetween(this.first, op, config0, writer);
            //        first = false;
            //    }
            //    else {
            //        context.PrintCommentsBetween(this.list1[i - 1], op, config0, writer);
            //    }
            //    context.PrintBlanksAnd(op, config0, writer);
            //    var exp = this.list1[i];
            //    context.PrintCommentsBetween(op, exp, config1, writer);
            //    context.PrintBlanksAnd(exp, config1, writer);
            //}
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        writer.Write(this.first.value);
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var op = this.list0[i];
        //        writer.Write(op.value); writer.Write(" ");
        //        var exp = this.list1[i];
        //        writer.Write(exp.value);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        writer.Write(this.first.value); yield return this.first.value;
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var op = this.list0[i];
        //        writer.Write(op.value); writer.Write(" "); yield return op.value;
        //        var exp = this.list1[i];
        //        writer.Write(exp.value); yield return exp.value;
        //    }
        //}
    }
}
