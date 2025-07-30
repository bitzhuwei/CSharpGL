using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node PragmaDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnPragmaDirective : IFullFormat {
        // [079] PragmaDirective = '#pragma' 'identifier' ;
        // [080] PragmaDirective = '#pragma' 'identifier' '(' ParameterList ')' ;
        // [081] PragmaDirective = '#pragma' 'identifier' '(' ')' ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [079] PragmaDirective = '#pragma' 'identifier' ;
        public VnPragmaDirective(Token r1, Token r0) {
            this.complex = new complex0(r1, r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                ppContext.pragmas.Add(this.r0.value);
            }
            public readonly Token r1;
            public readonly Token r0;
            public complex0(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [080] PragmaDirective = '#pragma' 'identifier' '(' ParameterList ')' ;
        public VnPragmaDirective(Token r4, Token r3, Token r2, VnParameterList r1, Token r0) {
            this.complex = new complex1(r4, r3, r2, r1, r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public readonly Token r4;
            public readonly Token r3;
            public readonly Token r2;
            public readonly VnParameterList r1;
            public readonly Token r0;
            public complex1(Token r4, Token r3, Token r2, VnParameterList r1, Token r0) {
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [081] PragmaDirective = '#pragma' 'identifier' '(' ')' ;
        public VnPragmaDirective(Token r3, Token r2, Token r1, Token r0) {
            this.complex = new complex2(r3, r2, r1, r0);
        }
        class complex2 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public readonly Token r3;
            public readonly Token r2;
            public readonly Token r1;
            public readonly Token r0;
            public complex2(Token r3, Token r2, Token r1, Token r0) {
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }



    }
}
