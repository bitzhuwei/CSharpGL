using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ElifGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnElifGroup : IFullFormat {
        // [076] ElifGroup = '#elif' ConstExp ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            context.PrintBlanksAnd(this.r1, preConfig, writer);
            context.PrintCommentsBetween(this.r1, this.r0, config, writer);
            context.PrintBlanksAnd(this.r0, config, writer);
        }


        public readonly Token r1;
        public readonly VnConstExp r0;
        public VnElifGroup(Token r1, VnConstExp r0) {
            this.r1 = r1;
            this.r0 = r0;
            this._scope = new TokenRange(r1, r0);
        }


    }
}
