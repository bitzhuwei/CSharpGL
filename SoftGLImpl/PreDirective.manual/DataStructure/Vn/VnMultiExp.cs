using System;
using System.Runtime.CompilerServices;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node MultiExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnMultiExp : IFullFormat {
        // [112] MultiExp = UnaryExp ;
        // [113] MultiExp = MultiExp '*' UnaryExp ;
        // [114] MultiExp = MultiExp '/' UnaryExp ;
        // [115] MultiExp = MultiExp '%' UnaryExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [113] MultiExp = MultiExp '*' UnaryExp ;
        public void Add(Token r1, VnUnaryExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var value2 = this.r0.CalcValue(ppContext);
            if (int.TryParse(value2, out var final)) {
                foreach (var item in postfix) {
                    int value = item.CalcValue(ppContext);
                    switch (item.r1.value) {
                    case "*": final = final * value; break;
                    case "/": final = final / value; break;
                    case "%": final = final % value; break;
                    default: throw new NotImplementedException();
                    }
                }
            }
            return final;
        }

        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal int CalcValue(SoftGLImpl.PpContext ppContext) {
                var value = this.r0.CalcValue(ppContext);
                if (int.TryParse(value, out var result)) { return result; }
                else {
                    throw new Exception("bug or wrong source code");
                    //return 0;
                }
            }


            public readonly Token r1;
            public readonly VnUnaryExp r0;
            public Postfix0(Token r1, VnUnaryExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [114] MultiExp = MultiExp '/' UnaryExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0

        // [115] MultiExp = MultiExp '%' UnaryExp ;
        // Pre/Postfix2 repeated with Pre/Postfix0


        public readonly VnUnaryExp r0;
        public VnMultiExp(VnUnaryExp r0) {
            this.r0 = r0;
        }


    }
}
