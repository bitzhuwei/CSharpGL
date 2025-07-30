using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ShiftExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnShiftExp : IFullFormat {
        // [106] ShiftExp = AddExp ;
        // [107] ShiftExp = ShiftExp '<<' AddExp ;
        // [108] ShiftExp = ShiftExp '>>' AddExp ;


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

        // [107] ShiftExp = ShiftExp '<<' AddExp ;
        public void Add(Token r1, VnAddExp r0) {
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
            public readonly VnAddExp r0;
            public Postfix0(Token r1, VnAddExp r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }

        // [108] ShiftExp = ShiftExp '>>' AddExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0


        public readonly VnAddExp r0;
        public VnShiftExp(VnAddExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
