using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node RandomTokens in the grammar(PreDirective).
    /// </summary>
    internal partial class VnRandomTokens : IFullFormat {
        // [013] RandomTokens = RandomTokens RandomToken ;
        // [014] RandomTokens = RandomToken ;
        // [015] RandomTokens = null ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            context.PrintBlanksAnd(this.complex, preConfig, writer);
            var postfixCount = this.postfix.Count;
            for (var i = 0; i < postfixCount; i++) {
                if (i == 0) {
                    context.PrintCommentsBetween(this.postfix[i], this.complex, config, writer);
                }
                else {
                    context.PrintCommentsBetween(this.postfix[i], this.postfix[i - 1], config, writer);
                }
                context.PrintBlanksAnd(this.postfix[i], config, writer);
            }
        }

        private readonly List<VnRandomToken> postfix = new();
        public void Add(VnRandomToken r0) {
            this.postfix.Add(r0);
            this._scope.end = r0.Scope.end;
            if (this._scope.start == int.MaxValue) { this._scope.start = r0.Scope.start; }
        }

        // [014] RandomTokens = RandomToken ;
        public VnRandomTokens(VnRandomToken r0) {
            this.complex = new complex0(r0);
            this._scope = new TokenRange(r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly VnRandomToken r0;
            public complex0(VnRandomToken r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [015] RandomTokens = null ;
        public VnRandomTokens() {
            this.complex = new complex1();
            this._scope = TokenRange.empty();
        }
        class complex1 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            }
            public complex1() {
                this._scope = TokenRange.empty();
            }
        }



    }
}
