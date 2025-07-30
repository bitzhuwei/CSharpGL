using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ElifGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnElifGroup : IFullFormat {
        // [076] ElifGroup = '#elif' ConstExp ;



        public void Update(SoftGLImpl.PpContext ppContext) {
            var objs = ppContext.conditionalObjs;
            var last = objs.LastOne();
            if (last != null) {
                var elif_ = new Elif_(exp: this.r0.CalcValue(ppContext));
                last.Append(elif_);
            }
            else {// error: omit this #elif
            }
        }


        public readonly Token r1;
        public readonly VnConstExp r0;
        public VnElifGroup(Token r1, VnConstExp r0) {
            this.r1 = r1;
            this.r0 = r0;
        }


    }
}
