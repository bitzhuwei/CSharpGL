using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node LineDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnLineDirective : IFullFormat {
        // [085] LineDirective = '#line' 'number' ;
        // [086] LineDirective = '#line' 'number' 'number' ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [085] LineDirective = '#line' 'number' ;
        public VnLineDirective(Token r1, Token r0) {
            this.complex = new complex0(r1, r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                if (int.TryParse(this.r0.value, out var line)) {
                    ppContext.currentLine = line;
                }
            }
            public readonly Token r1;
            public readonly Token r0;
            public complex0(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [086] LineDirective = '#line' 'number' 'number' ;
        public VnLineDirective(Token r2, Token r1, Token r0) {
            this.complex = new complex1(r2, r1, r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                if (int.TryParse(this.r1.value, out var line)) {
                    ppContext.currentLine = line;
                }
                if (int.TryParse(this.r0.value, out var file)) {
                    ppContext.currentFile = file;
                }
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
