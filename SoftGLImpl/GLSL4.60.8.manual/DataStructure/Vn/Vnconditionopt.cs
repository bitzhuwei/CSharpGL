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
    /// Correspond to the Vn node conditionopt in the grammar(GLSL).
    /// </summary>
    partial class Vnconditionopt : IFullFormat {
        // [338] conditionopt : condition ;
        // [339] conditionopt : empty ;

        private Vncondition? condition0;

        public Vnconditionopt(Vncondition? condition0) {
            if (condition0 != null) { this._tokenRange = new TokenRange(condition0); }
            else { this._tokenRange = TokenRange.empty(); }
            this.condition0 = condition0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.condition0 != null) { this.condition0.FullFormat(preConfig, writer, context); }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.condition0 != null) { this.condition0.Format(writer, context); }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.condition0 != null) {
        //        foreach (var item in this.condition0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
