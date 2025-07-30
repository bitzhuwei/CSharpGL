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
    /// Correspond to the Vn node layout_qualifier_id_list in the grammar(GLSL).
    /// </summary>
    partial class Vnlayout_qualifier_id_list : IFullFormat {
        // [129]: layout_qualifier_id_list : layout_qualifier_id ;
        // [130]: layout_qualifier_id_list : layout_qualifier_id_list ',' layout_qualifier_id ;

        private readonly Vnlayout_qualifier_id first;
        private readonly List<Token> list0 = new();
        private readonly List<Vnlayout_qualifier_id> list1 = new();
        internal void Add(Token r1, Vnlayout_qualifier_id r0) {
            this.list0.Add(r1);
            this.list1.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        public Vnlayout_qualifier_id_list(Vnlayout_qualifier_id first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            // move self value(std140 etc.) to last positions 
            var array = new Vnlayout_qualifier_id[1 + this.list1.Count];
            var next = 0; var firstSelfValue = int.MinValue;
            {
                if (!this.first.IsSelfValue()) { array[next++] = this.first; }
            }
            for (var i = 0; i < this.list1.Count; i++) {
                if (!this.list1[i].IsSelfValue()) { array[next++] = this.list1[i]; }
            }
            firstSelfValue = next;
            {
                if (this.first.IsSelfValue()) { array[next++] = this.first; }
            }
            for (var i = 0; i < this.list1.Count; i++) {
                if (this.list1[i].IsSelfValue()) { array[next++] = this.list1[i]; }
            }
            {
                array[0].FullFormat(preConfig, writer, context);
            }
            var config0 = new BlankConfig(inlineBlank: 0, forceNewline: false);
            var config1 = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var first = true;
            for (var i = 0; i < this.list1.Count; i++) {
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
                var lastComment = context.PrintCommentsBetween(op, exp, config1, writer);
                if (0 < firstSelfValue && firstSelfValue == i + 1) { // values = [ ... ] exists
                    if (lastComment == FormatContext.LastComment.InlineComment) {
                        writer.WriteLine();
                        context.PrintTab(writer);
                    }
                    writer.Write("values = [");
                }
                array[i + 1].FullFormat(config1, writer, context);
            }
            if (0 < firstSelfValue && firstSelfValue <= this.list1.Count) { // values = [ ... ] exists
                writer.Write(" ]");
            }
            // original version
            //{
            //    this.first.FullFormat(preConfig, writer, context);
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
            //    exp.FullFormat(config1, writer, context);
            //}
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
