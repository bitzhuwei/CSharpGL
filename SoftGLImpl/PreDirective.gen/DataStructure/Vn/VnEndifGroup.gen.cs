using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node EndifGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnEndifGroup : IFullFormat {
        // [077] EndifGroup = '#endif' ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.r0, preConfig, writer);
        }


        public readonly Token r0;
        public VnEndifGroup(Token r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
