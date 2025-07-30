using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node UnaryExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnUnaryExp : IFullFormat {
        // [116] UnaryExp = PrimaryExp ;
        // [117] UnaryExp = UnaryOp UnaryExp ;



        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        private readonly List<VnUnaryOp> prefix = new();
        public void Insert(VnUnaryOp r1) {
            this.prefix.Insert(0, r1);
        }

        internal string CalcValue(SoftGLImpl.PpContext ppContext) {
            string final = this.r0.CalcValue(ppContext);
            for (int i = prefix.Count - 1; i >= 0; i--) {
                var op = prefix[i];
                switch (op.GetToken().value) {
                case "defined": final = ppContext.name2Define.ContainsKey(final) ? "1" : "0"; break;
                case "+": {
                    if (int.TryParse(final, out var value)) {
                        final = $"{+value}";
                    }
                }
                break;
                case "-": {
                    if (int.TryParse(final, out var value)) {
                        final = $"{-value}";
                    }
                }
                break;
                case "~": {
                    if (int.TryParse(final, out var value)) {
                        final = $"{~value}";
                    }
                }
                break;
                case "!": {
                    if (int.TryParse(final, out var value)) {
                        if (value == 0) { final = "1"; }
                        else { final = "0"; }
                    }
                }
                break;
                default: throw new NotImplementedException();
                }
            }
            return final;// final is string or integer
        }


        public readonly VnPrimaryExp r0;
        public VnUnaryExp(VnPrimaryExp r0) {
            this.r0 = r0;
        }


    }
}
