using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ElseGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnElseGroup : IFullFormat {
        // [075] ElseGroup = '#else' ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.r0, preConfig, writer);
        }


        public readonly Token r0;
        public VnElseGroup(Token r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
