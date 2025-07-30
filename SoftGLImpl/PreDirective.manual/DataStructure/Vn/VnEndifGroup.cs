using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node EndifGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnEndifGroup : IFullFormat {
        // [077] EndifGroup = '#endif' ;



        public void Update(SoftGLImpl.PpContext ppContext) {
            var objs = ppContext.conditionalObjs;
            var last = objs.LastOne();
            if (last != null) {
                last.AppendEndif();
            }
            else {// error: omit this #endif
            }
        }


        public readonly Token r0;
        public VnEndifGroup(Token r0) {
            this.r0 = r0;
        }


    }
}
