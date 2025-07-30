using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ConstExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnConstExp : IFullFormat {
        // [087] ConstExp = OrOrExp ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.r0, preConfig, writer);
        }


        public readonly VnOrOrExp r0;
        public VnConstExp(VnOrOrExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
