using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ExtensionDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnExtensionDirective : IFullFormat {
        // [082] ExtensionDirective = '#extension' 'literalString' ':' 'literalString' ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            context.PrintBlanksAnd(this.r3, preConfig, writer);
            context.PrintCommentsBetween(this.r3, this.r2, config, writer);
            context.PrintBlanksAnd(this.r2, config, writer);
            context.PrintCommentsBetween(this.r2, this.r1, config, writer);
            context.PrintBlanksAnd(this.r1, config, writer);
            context.PrintCommentsBetween(this.r1, this.r0, config, writer);
            context.PrintBlanksAnd(this.r0, config, writer);
        }


        public readonly Token r3;
        public readonly Token r2;
        public readonly Token r1;
        public readonly Token r0;
        public VnExtensionDirective(Token r3, Token r2, Token r1, Token r0) {
            this.r3 = r3;
            this.r2 = r2;
            this.r1 = r1;
            this.r0 = r0;
            this._scope = new TokenRange(r3, r0);
        }


    }
}
