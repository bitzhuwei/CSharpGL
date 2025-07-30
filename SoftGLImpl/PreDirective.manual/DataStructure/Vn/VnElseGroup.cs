using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ElseGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnElseGroup : IFullFormat {
        // [075] ElseGroup = '#else' ;



        public void Update(SoftGLImpl.PpContext ppContext) {
            var objs = ppContext.conditionalObjs;
            var last = objs.LastOne();
            if (last != null) { last.Append(new Else_()); }
            else {// error: omit this #else
            }
        }


        public readonly Token r0;
        public VnElseGroup(Token r0) {
            this.r0 = r0;
        }


    }
}
