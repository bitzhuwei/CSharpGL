using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node VersionDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnVersionDirective : IFullFormat {
        // [083] VersionDirective = '#version' 'number' ;
        // [084] VersionDirective = '#version' 'number' 'identifier' ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [083] VersionDirective = '#version' 'number' ;
        public VnVersionDirective(Token r1, Token r0) {
            this.complex = new complex0(r1, r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                ppContext.version = new SoftGLImpl.PreVersion(this.r0.value, "");
            }
            public readonly Token r1;
            public readonly Token r0;
            public complex0(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [084] VersionDirective = '#version' 'number' 'identifier' ;
        public VnVersionDirective(Token r2, Token r1, Token r0) {
            this.complex = new complex1(r2, r1, r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                ppContext.version = new SoftGLImpl.PreVersion(this.r1.value, this.r0.value);
            }
            public readonly Token r2;
            public readonly Token r1;
            public readonly Token r0;
            public complex1(Token r2, Token r1, Token r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }



    }
}
