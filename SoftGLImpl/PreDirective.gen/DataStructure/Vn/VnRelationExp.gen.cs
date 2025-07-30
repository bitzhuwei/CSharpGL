using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node RelationExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnRelationExp : IFullFormat {
        // [101] RelationExp = ShiftExp ;
        // [102] RelationExp = RelationExp '<' ShiftExp ;
        // [103] RelationExp = RelationExp '>' ShiftExp ;
        // [104] RelationExp = RelationExp '<=' ShiftExp ;
        // [105] RelationExp = RelationExp '>=' ShiftExp ;


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

        // [102] RelationExp = RelationExp '<' ShiftExp ;
        public void Add(Token r1, VnShiftExp r0) {
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
            public readonly VnShiftExp r0;
            public Postfix0(Token r1, VnShiftExp r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }

        // [103] RelationExp = RelationExp '>' ShiftExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0

        // [104] RelationExp = RelationExp '<=' ShiftExp ;
        // Pre/Postfix2 repeated with Pre/Postfix0

        // [105] RelationExp = RelationExp '>=' ShiftExp ;
        // Pre/Postfix3 repeated with Pre/Postfix0


        public readonly VnShiftExp r0;
        public VnRelationExp(VnShiftExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
