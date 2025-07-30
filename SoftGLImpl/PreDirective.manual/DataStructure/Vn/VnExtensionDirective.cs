using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ExtensionDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnExtensionDirective : IFullFormat {
        // [082] ExtensionDirective = '#extension' 'literalString' ':' 'literalString' ;



        public void Update(SoftGLImpl.PpContext ppContext) {
            ppContext.extension2State.Set(this.r2.value, this.r0.value);
        }


        public readonly Token r3;
        public readonly Token r2;
        public readonly Token r1;
        public readonly Token r0;
        public VnExtensionDirective(Token r3, Token r2, Token r1, Token r0) {
            this.r3 = r3;
            this.r2 = r2;
            this.r1 = r1;
            this.r0 = r0;
        }


    }
}
