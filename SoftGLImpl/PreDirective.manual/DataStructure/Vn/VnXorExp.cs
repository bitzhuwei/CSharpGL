using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node XorExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnXorExp : IFullFormat {
        // [094] XorExp = AndExp ;
        // [095] XorExp = XorExp '^' AndExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [095] XorExp = XorExp '^' AndExp ;
        public void Add(Token r1, VnAndExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                var value = item.CalcValue(ppContext);
                final = final ^ value;
            }
            return final;
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal int CalcValue(SoftGLImpl.PpContext ppContext) {
                return this.r0.CalcValue(ppContext);
            }


            public readonly Token r1;
            public readonly VnAndExp r0;
            public Postfix0(Token r1, VnAndExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly VnAndExp r0;
        public VnXorExp(VnAndExp r0) {
            this.r0 = r0;
        }


    }
}
