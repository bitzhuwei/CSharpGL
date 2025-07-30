using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node LineDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnLineDirective : IFullFormat {
        // [085] LineDirective = '#line' 'number' ;
        // [086] LineDirective = '#line' 'number' 'number' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [085] LineDirective = '#line' 'number' ;
        public VnLineDirective(Token r1, Token r0) {
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
            public readonly Token r0;
            public complex0(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }

        // [086] LineDirective = '#line' 'number' 'number' ;
        public VnLineDirective(Token r2, Token r1, Token r0) {
            this.complex = new complex1(r2, r1, r0);
            this._scope = new TokenRange(r2, r0);
        }
        class complex1 : IFullFormat {
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
            public readonly Token r1;
            public readonly Token r0;
            public complex1(Token r2, Token r1, Token r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r2, r0);
            }
        }



    }
}
