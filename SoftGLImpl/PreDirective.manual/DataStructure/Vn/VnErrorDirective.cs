using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ErrorDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnErrorDirective : IFullFormat {
        // [078] ErrorDirective = '#error' 'literalString' ;



        public void Update(SoftGLImpl.PpContext ppContext) {
            ppContext.errors.Add(this.r0.value);
        }


        public readonly Token r1;
        public readonly Token r0;
        public VnErrorDirective(Token r1, Token r0) {
            this.r1 = r1;
            this.r0 = r0;
        }


    }
}
