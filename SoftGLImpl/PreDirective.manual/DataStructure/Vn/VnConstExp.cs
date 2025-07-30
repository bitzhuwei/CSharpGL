using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ConstExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnConstExp : IFullFormat {
        // [087] ConstExp = OrOrExp ;


        public string CalcValue(PpContext ppContext) {
            return this.r0.CalcValue(ppContext);
        }

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        public readonly VnOrOrExp r0;
        public VnConstExp(VnOrOrExp r0) {
            this.r0 = r0;
        }


    }
}
