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
    /// Correspond to the Vn node identifier_list in the grammar(GLSL).
    /// </summary>
    partial class Vnidentifier_list : IFullFormat {
        // [97]: identifier_list : ',' 'identifier' ;
        // [98]: identifier_list : identifier_list ',' 'identifier' ;

        private readonly Token first0;
        private readonly Token first1;
        // , identifier , identifier ...
        private readonly List<Token> list0 = new();
        private readonly List<Token> list1 = new();
        internal void Add(Token r1, Token r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.index;
        }

        public Vnidentifier_list(Token first0, Token first1) {
            this._tokenRange = new TokenRange(first0, first1);
            this.first0 = first0;
            this.first1 = first1;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config0 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var config1 = new BlankConfig(inlineBlank: 0, forceNewline: false);
            {
                context.PrintBlanksAnd(this.first0, preConfig, writer);
                context.PrintCommentsBetween(this.first0, this.first1, config0, writer);
                context.PrintBlanksAnd(this.first1, config0, writer);
            }
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var op = this.list0[i];
                if (first) {
                    context.PrintCommentsBetween(this.first1, op, config1, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list1[i - 1], op, config1, writer);
                }
                context.PrintBlanksAnd(op, config1, writer);
                var exp = this.list1[i];
                context.PrintCommentsBetween(op, exp, config0, writer);
                context.PrintBlanksAnd(exp, config0, writer);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //	{
        //		writer.Write(this.first0.value);
        //		writer.Write(this.first1.value);
        //	}
        //	for (var i = 0; i < this.list0.Count; i++) {
        //		var op = this.list0[i];
        //		writer.Write(op.value); writer.Write(" ");
        //		var exp = this.list1[i];
        //		writer.Write(exp.value);
        //	}
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //	{
        //		writer.Write(this.first0.value); yield return this.first0.value;
        //		writer.Write(this.first1.value); yield return this.first1.value;
        //	}
        //	for (var i = 0; i < this.list0.Count; i++) {
        //		var op = this.list0[i];
        //		writer.Write(op.value); writer.Write(" "); yield return op.value;
        //		var exp = this.list1[i];
        //		writer.Write(exp.value); yield return exp.value;
        //	}
        //}
    }
}
