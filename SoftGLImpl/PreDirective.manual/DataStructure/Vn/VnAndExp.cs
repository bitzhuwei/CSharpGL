using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node AndExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnAndExp : IFullFormat {
        // [096] AndExp = EqualExp ;
        // [097] AndExp = AndExp '&' EqualExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [097] AndExp = AndExp '&' EqualExp ;
        public void Add(Token r1, VnEqualExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                int value = item.CalcValue(ppContext);
                final = final & value;
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
            public readonly VnEqualExp r0;
            public Postfix0(Token r1, VnEqualExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly VnEqualExp r0;
        public VnAndExp(VnEqualExp r0) {
            this.r0 = r0;
        }


    }
}
