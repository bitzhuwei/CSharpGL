using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ErrorDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnErrorDirective : IFullFormat {
        // [078] ErrorDirective = '#error' 'literalString' ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            context.PrintBlanksAnd(this.r1, preConfig, writer);
            context.PrintCommentsBetween(this.r1, this.r0, config, writer);
            context.PrintBlanksAnd(this.r0, config, writer);
        }


        public readonly Token r1;
        public readonly Token r0;
        public VnErrorDirective(Token r1, Token r0) {
            this.r1 = r1;
            this.r0 = r0;
            this._scope = new TokenRange(r1, r0);
        }


    }
}
