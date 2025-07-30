using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node PrimaryExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnPrimaryExp : IFullFormat {
        // [123] PrimaryExp = 'number' ;
        // [124] PrimaryExp = 'identifier' ;
        // [125] PrimaryExp = '(' ConstExp ')' ;

        interface ICalcValue {
            public string CalcValue(SoftGLImpl.PpContext ppContext);
        }
        private readonly ICalcValue complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        internal string CalcValue(SoftGLImpl.PpContext ppContext) {
            return this.complex.CalcValue(ppContext);
        }

        // [123] PrimaryExp = 'number' ;
        public VnPrimaryExp(Token r0) {
            this.complex = new complex0(r0);
        }
        class complex0 : ICalcValue {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public string CalcValue(SoftGLImpl.PpContext ppContext) {
                return this.r0.value;
            }

            public IEnumerable<Token> EnumTokens() {
                yield return this.r0;
            }

            public readonly Token r0;
            public complex0(Token r0) {
                this.r0 = r0;
            }
        }

        // [124] PrimaryExp = 'identifier' ;
        // complex1 repeated with complex0

        // [125] PrimaryExp = '(' ConstExp ')' ;
        public VnPrimaryExp(Token r2, VnConstExp r1, Token r0) {
            this.complex = new complex2(r2, r1, r0);
        }
        class complex2 : ICalcValue {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            public string CalcValue(SoftGLImpl.PpContext ppContext) {
                var value = this.r1.CalcValue(ppContext);
                var final = 0; if (int.TryParse(value, out var iv)) { final = iv; }
                if (final != 0) { return "1"; }
                else { return "0"; }
            }

            public readonly Token r2;
            public readonly VnConstExp r1;
            public readonly Token r0;
            public complex2(Token r2, VnConstExp r1, Token r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }



    }
}
