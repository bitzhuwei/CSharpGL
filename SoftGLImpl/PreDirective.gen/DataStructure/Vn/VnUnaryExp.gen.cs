using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node UnaryExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnUnaryExp : IFullFormat {
        // [116] UnaryExp = PrimaryExp ;
        // [117] UnaryExp = UnaryOp UnaryExp ;



        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            var config = new BlankConfig();
            var prefixCount = this.prefix.Count;
            for (var i = 0; i < prefixCount; i++) {
                context.PrintBlanksAnd(this.prefix[i], i == 0 ? preConfig : config, writer);
                if (i + 1 < prefixCount) {
                    context.PrintCommentsBetween(this.prefix[i], this.prefix[i + 1], config, writer);
                }
                else {
                    context.PrintCommentsBetween(this.prefix[i], this.r0, config, writer);
                }
            }
            context.PrintBlanksAnd(this.r0, prefixCount == 0 ? preConfig : config, writer);
        }

        private readonly List<VnUnaryOp> prefix = new();
        public void Insert(VnUnaryOp r1) {
            this.prefix.Insert(0, r1);
            this._scope.start = r1.Scope.start;
        }

        public readonly VnPrimaryExp r0;
        public VnUnaryExp(VnPrimaryExp r0) {
            this.r0 = r0;
            this._scope = new TokenRange(r0);
        }


    }
}
