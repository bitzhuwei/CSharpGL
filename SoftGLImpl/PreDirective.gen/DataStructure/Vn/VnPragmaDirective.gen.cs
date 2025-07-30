using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node PragmaDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnPragmaDirective : IFullFormat {
        // [079] PragmaDirective = '#pragma' 'identifier' ;
        // [080] PragmaDirective = '#pragma' 'identifier' '(' ParameterList ')' ;
        // [081] PragmaDirective = '#pragma' 'identifier' '(' ')' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [079] PragmaDirective = '#pragma' 'identifier' ;
        public VnPragmaDirective(Token r1, Token r0) {
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

        // [080] PragmaDirective = '#pragma' 'identifier' '(' ParameterList ')' ;
        public VnPragmaDirective(Token r4, Token r3, Token r2, VnParameterList r1, Token r0) {
            this.complex = new complex1(r4, r3, r2, r1, r0);
            this._scope = new TokenRange(r4, r0);
        }
        class complex1 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r4, preConfig, writer);
                context.PrintCommentsBetween(r4, r3, config, writer);
                context.PrintBlanksAnd(r3, config, writer);
                context.PrintCommentsBetween(r3, r2, config, writer);
                context.PrintBlanksAnd(r2, config, writer);
                context.PrintCommentsBetween(r2, r1, config, writer);
                context.PrintBlanksAnd(r1, config, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r4;
            public readonly Token r3;
            public readonly Token r2;
            public readonly VnParameterList r1;
            public readonly Token r0;
            public complex1(Token r4, Token r3, Token r2, VnParameterList r1, Token r0) {
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r4, r0);
            }
        }

        // [081] PragmaDirective = '#pragma' 'identifier' '(' ')' ;
        public VnPragmaDirective(Token r3, Token r2, Token r1, Token r0) {
            this.complex = new complex2(r3, r2, r1, r0);
            this._scope = new TokenRange(r3, r0);
        }
        class complex2 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r3, preConfig, writer);
                context.PrintCommentsBetween(r3, r2, config, writer);
                context.PrintBlanksAnd(r2, config, writer);
                context.PrintCommentsBetween(r2, r1, config, writer);
                context.PrintBlanksAnd(r1, config, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r3;
            public readonly Token r2;
            public readonly Token r1;
            public readonly Token r0;
            public complex2(Token r3, Token r2, Token r1, Token r0) {
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r3, r0);
            }
        }



    }
}
