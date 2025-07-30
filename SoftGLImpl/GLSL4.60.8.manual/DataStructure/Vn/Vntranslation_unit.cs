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
    /// Correspond to the Vn node translation_unit in the grammar(GLSL).
    /// </summary>
    partial class Vntranslation_unit : IFullFormat {
        // [0]: translation_unit : external_declaration ;
        // [1]: translation_unit : translation_unit external_declaration ;

        private readonly Vnexternal_declaration first;
        private readonly List<Vnexternal_declaration> list = new();
        internal void Add(Vnexternal_declaration r0) {
            this.list.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        public Vntranslation_unit(Vnexternal_declaration first) {
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
            for (var i = 0; i < this.list.Count; i++) {
                var exp = this.list[i];
                if (first) {
                    context.PrintCommentsBetween(this.first, exp, config, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list[i - 1], exp, config, writer);
                }
                exp.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        this.first.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list.Count; i++) {
        //        writer.WriteLine();
        //        context.PrintTab(writer);
        //        var exp = this.list[i];
        //        exp.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        foreach (var item in this.first.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list.Count; i++) {
        //        writer.WriteLine();
        //        context.PrintTab(writer);
        //        var exp = this.list[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
