using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node OrOrExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnOrOrExp : IFullFormat {
        // [088] OrOrExp = AndAndExp ;
        // [089] OrOrExp = OrOrExp '||' AndAndExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [089] OrOrExp = OrOrExp '||' AndAndExp ;
        public void Add(Token r1, VnAndAndExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal string CalcValue(PpContext ppContext) {
            if (this.r0.CalcValue(ppContext)) { return "1"; }
            foreach (var item in this.postfix) {
                if (item.CalcValue(ppContext)) { return "1"; }
            }
            return "0";
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal bool CalcValue(PpContext ppContext) {
                return this.r0.CalcValue(ppContext);
            }


            public readonly Token r1;
            public readonly VnAndAndExp r0;
            public Postfix0(Token r1, VnAndAndExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly VnAndAndExp r0;
        public VnOrOrExp(VnAndAndExp r0) {
            this.r0 = r0;
        }


    }
}
