using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node AddExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnAddExp : IFullFormat {
        // [109] AddExp = MultiExp ;
        // [110] AddExp = AddExp '+' MultiExp ;
        // [111] AddExp = AddExp '-' MultiExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [110] AddExp = AddExp '+' MultiExp ;
        public void Add(Token r1, VnMultiExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                var value = item.CalcValue();
                switch (item.r1.value) {
                case "+": final = final + value; break;
                case "-": final = final - value; break;
                default: throw new NotImplementedException();
                }
            }
            return final;
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal int CalcValue() {
                throw new NotImplementedException();
            }


            public readonly Token r1;
            public readonly VnMultiExp r0;
            public Postfix0(Token r1, VnMultiExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [111] AddExp = AddExp '-' MultiExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0


        public readonly VnMultiExp r0;
        public VnAddExp(VnMultiExp r0) {
            this.r0 = r0;
        }


    }
}
