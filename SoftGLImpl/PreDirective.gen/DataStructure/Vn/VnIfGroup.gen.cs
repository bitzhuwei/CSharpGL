using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node IfGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnIfGroup : IFullFormat {
        // [072] IfGroup = '#if' ConstExp ;
        // [073] IfGroup = '#ifdef' ConstExp ;
        // [074] IfGroup = '#ifndef' ConstExp ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [072] IfGroup = '#if' ConstExp ;
        public VnIfGroup(Token r1, VnConstExp r0) {
            this.complex = new complex0(r1, r0);
            this._scope = new TokenRange(r1, r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r1, preConfig, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r1;
            public readonly VnConstExp r0;
            public complex0(Token r1, VnConstExp r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }

        // [073] IfGroup = '#ifdef' ConstExp ;
        // complex1 repeated with complex0

        // [074] IfGroup = '#ifndef' ConstExp ;
        // complex2 repeated with complex0



    }
}
