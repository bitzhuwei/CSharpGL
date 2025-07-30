using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node OrExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnOrExp : IFullFormat {
        // [092] OrExp = XorExp ;
        // [093] OrExp = OrExp '|' XorExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [093] OrExp = OrExp '|' XorExp ;
        public void Add(Token r1, VnXorExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal bool CalcValue(SoftGLImpl.PpContext ppContext) {
            if (this.r0.CalcValue(ppContext) != 0) { return true; }
            foreach (var item in this.postfix) {
                if (item.CalcValue(ppContext) != 0) { return true; }
            }

            return false;
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal int CalcValue(PpContext ppContext) {
                return this.r0.CalcValue(ppContext);
            }


            public readonly Token r1;
            public readonly VnXorExp r0;
            public Postfix0(Token r1, VnXorExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly VnXorExp r0;
        public VnOrExp(VnXorExp r0) {
            this.r0 = r0;
        }


    }
}
