using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node MicroDefinition in the grammar(PreDirective).
    /// </summary>
    internal partial class VnMicroDefinition : IFullFormat {
        // [007] MicroDefinition = '#define' 'identifier' '(' ParameterList ')' RandomTokens ;
        // [008] MicroDefinition = '#define' 'identifier' '(' ')' RandomTokens ;
        // [009] MicroDefinition = '#define' 'identifier' RandomTokens ;
        // [010] MicroDefinition = '#undef' 'identifier' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [007] MicroDefinition = '#define' 'identifier' '(' ParameterList ')' RandomTokens ;
        public VnMicroDefinition(Token r5, Token r4, Token r3, VnParameterList r2, Token r1, VnRandomTokens r0) {
            this.complex = new complex0(r5, r4, r3, r2, r1, r0);
            this._scope = new TokenRange(r5, r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r5, preConfig, writer);
                context.PrintCommentsBetween(r5, r4, config, writer);
                context.PrintBlanksAnd(r4, config, writer);
                context.PrintCommentsBetween(r4, r3, config, writer);
                context.PrintBlanksAnd(r3, config, writer);
                context.PrintCommentsBetween(r3, r2, config, writer);
                context.PrintBlanksAnd(r2, config, writer);
                context.PrintCommentsBetween(r2, r1, config, writer);
                context.PrintBlanksAnd(r1, config, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r5;
            public readonly Token r4;
            public readonly Token r3;
            public readonly VnParameterList r2;
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex0(Token r5, Token r4, Token r3, VnParameterList r2, Token r1, VnRandomTokens r0) {
                this.r5 = r5;
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r5, r0);
            }
        }

        // [008] MicroDefinition = '#define' 'identifier' '(' ')' RandomTokens ;
        public VnMicroDefinition(Token r4, Token r3, Token r2, Token r1, VnRandomTokens r0) {
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
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex1(Token r4, Token r3, Token r2, Token r1, VnRandomTokens r0) {
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r4, r0);
            }
        }

        // [009] MicroDefinition = '#define' 'identifier' RandomTokens ;
        public VnMicroDefinition(Token r2, Token r1, VnRandomTokens r0) {
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
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex2(Token r2, Token r1, VnRandomTokens r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r2, r0);
            }
        }

        // [010] MicroDefinition = '#undef' 'identifier' ;
        public VnMicroDefinition(Token r1, Token r0) {
            this.complex = new complex3(r1, r0);
            this._scope = new TokenRange(r1, r0);
        }
        class complex3 : IFullFormat {
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
            public complex3(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }



    }
}
