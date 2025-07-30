using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node EqualExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnEqualExp : IFullFormat {
        // [098] EqualExp = RelationExp ;
        // [099] EqualExp = EqualExp '==' RelationExp ;
        // [100] EqualExp = EqualExp '!=' RelationExp ;


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

        // [099] EqualExp = EqualExp '==' RelationExp ;
        public void Add(Token r1, VnRelationExp r0) {
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
            public readonly VnRelationExp r0;
            public Postfix0(Token r1, VnRelationExp r0) {
                this.r1 = r1;
                this.r0 = r0;
                this._scope = new TokenRange(r1, r0);
            }
        }

        // [100] EqualExp = EqualExp '!=' RelationExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0


        public readonly VnRelationExp r0;
        public VnEqualExp(VnRelationExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
