using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node UnaryOp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnUnaryOp : IFullFormat {
        // [118] UnaryOp = 'defined' ;
        // [119] UnaryOp = '+' ;
        // [120] UnaryOp = '-' ;
        // [121] UnaryOp = '~' ;
        // [122] UnaryOp = '!' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [118] UnaryOp = 'defined' ;
        public VnUnaryOp(Token r0) {
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

        // [119] UnaryOp = '+' ;
        // complex1 repeated with complex0

        // [120] UnaryOp = '-' ;
        // complex2 repeated with complex0

        // [121] UnaryOp = '~' ;
        // complex3 repeated with complex0

        // [122] UnaryOp = '!' ;
        // complex4 repeated with complex0



    }
}
