using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node AndAndExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnAndAndExp : IFullFormat {
        // [090] AndAndExp = OrExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [091] AndAndExp = AndAndExp '&&' OrExp ;
        public void Add(Token r1, VnOrExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal bool CalcValue(PpContext ppContext) {
            if (this.r0.CalcValue(ppContext) == false) { return false; }
            foreach (var item in this.postfix) {
                if (item.CalcValue(ppContext) == false) { return false; }
            }

            return true;
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal bool CalcValue(PpContext ppContext) {
                return this.r0.CalcValue(ppContext);
            }


            public readonly Token r1;
            public readonly VnOrExp r0;
            public Postfix0(Token r1, VnOrExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly VnOrExp r0;
        public VnAndAndExp(VnOrExp r0) {
            this.r0 = r0;
        }


    }
}
