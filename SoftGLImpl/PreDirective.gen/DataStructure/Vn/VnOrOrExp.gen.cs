using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node OrOrExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnOrOrExp : IFullFormat {
        // [088] OrOrExp = AndAndExp ;
        // [089] OrOrExp = OrOrExp '||' AndAndExp ;


        private readonly List<IFullFormat> postfix = new();

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            context.PrintBlanksAnd(this.r0, preConfig, writer);
            var postfixCount = this.postfix.Count;
            for (var i = 0; i < postfixCount; i++) {
                if (i == 0) {
                    context.PrintCommentsBetween(this.postfix[i], this.r0, config, writer);
                }
                else {
                    context.PrintCommentsBetween(this.postfix[i], this.postfix[i - 1], config, writer);
                }
                context.PrintBlanksAnd(this.postfix[i], config, writer);
            }
        }

        // [089] OrOrExp = OrOrExp '||' AndAndExp ;
        public void Add(Token r1, VnAndAndExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
            this._scope.end = r0.Scope.end;
        }
        class Postfix0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                var config = new BlankConfig();
                context.PrintBlanksAnd(r1, preConfig, writer);
                context.PrintCommentsBetween(r1, r0, config, writer);
                context.PrintBlanksAnd(r0, config, writer);
            }
            public readonly Token r1;
            public readonly VnAndAndExp r0;
            public Postfix0(Token r1, VnAndAndExp r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }


        public readonly VnAndAndExp r0;
        public VnOrOrExp(VnAndAndExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
