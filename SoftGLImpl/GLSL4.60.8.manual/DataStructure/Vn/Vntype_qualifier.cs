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
    /// Correspond to the Vn node type_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vntype_qualifier : IFullFormat {
        // [135]: type_qualifier : single_type_qualifier ;
        // [136]: type_qualifier : type_qualifier single_type_qualifier ;

        private readonly Vnsingle_type_qualifier first;
        private readonly List<Vnsingle_type_qualifier> list = new();
        internal void Add(Vnsingle_type_qualifier r0) {
            this.list.Add(r0);
            this._tokenRange.end = r0.Scope.end;
        }

        public Vntype_qualifier(Vnsingle_type_qualifier first) {
            this._tokenRange = new TokenRange(first);
            this.first = first;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public string LastQualifierName() {
            if (this.list.Count == 0) return this.first.Name;
            else return this.list.Last().Name;
        }

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
        //        var exp = this.list[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}

