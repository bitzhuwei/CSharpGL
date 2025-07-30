using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node PrimaryExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnPrimaryExp : IFullFormat {
        // [123] PrimaryExp = 'number' ;
        // [124] PrimaryExp = 'identifier' ;
        // [125] PrimaryExp = '(' ConstExp ')' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [123] PrimaryExp = 'number' ;
        public VnPrimaryExp(Token r0) {
            this.complex = new complex0(r0);
            this._scope = new TokenRange(r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly Token r0;
            public complex0(Token r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [124] PrimaryExp = 'identifier' ;
        // complex1 repeated with complex0

        // [125] PrimaryExp = '(' ConstExp ')' ;
        public VnPrimaryExp(Token r2, VnConstExp r1, Token r0) {
            this.complex = new complex2(r2, r1, r0);
            this._scope = new TokenRange(r2, r0);
        }
        class complex2 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r2, preConfig, writer);
                context.PrintCommentsBetween(r2, r1, config, writer);
                context.PrintBlanksAnd(r1, config, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r2;
            public readonly VnConstExp r1;
            public readonly Token r0;
            public complex2(Token r2, VnConstExp r1, Token r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r2, r0);
            }
        }



    }
}
