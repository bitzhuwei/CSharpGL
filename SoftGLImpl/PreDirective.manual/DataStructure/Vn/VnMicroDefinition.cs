using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node MicroDefinition in the grammar(PreDirective).
    /// </summary>
    internal partial class VnMicroDefinition : IFullFormat {
        // [007] MicroDefinition = '#define' 'identifier' '(' ParameterList ')' RandomTokens ;
        // [008] MicroDefinition = '#define' 'identifier' '(' ')' RandomTokens ;
        // [009] MicroDefinition = '#define' 'identifier' RandomTokens ;
        // [010] MicroDefinition = '#undef' 'identifier' ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [007] MicroDefinition = '#define' 'identifier' '(' ParameterList ')' RandomTokens ;
        public VnMicroDefinition(Token r5, Token r4, Token r3, VnParameterList r2, Token r1, VnRandomTokens r0) {
            this.complex = new complex0(r5, r4, r3, r2, r1, r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                var preDefine = new PreDefine(this.r4.value, hasParentheses: true);
                foreach (var item in this.r0.Enumerate()) {
                    var token = item.complex;
                    preDefine.postTokens.Add(token);
                }
                {
                    var index = 0;
                    foreach (var token in this.r2.Enumerate()) {
                        preDefine.formalParam2Index.Add(token.value, index++);
                    }
                }
                ppContext.name2Define.Add(this.r4.value, preDefine);
            }
            public readonly Token r5;
            public readonly Token r4;
            public readonly Token r3;
            public readonly VnParameterList r2;
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex0(Token r5, Token r4, Token r3, VnParameterList r2, Token r1, VnRandomTokens r0) {
                this.r5 = r5;
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [008] MicroDefinition = '#define' 'identifier' '(' ')' RandomTokens ;
        public VnMicroDefinition(Token r4, Token r3, Token r2, Token r1, VnRandomTokens r0) {
            this.complex = new complex1(r4, r3, r2, r1, r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                var preDefine = new PreDefine(this.r3.value, hasParentheses: true);
                foreach (var item in this.r0.Enumerate()) {
                    var token = item.complex;
                    preDefine.postTokens.Add(token);
                }
                ppContext.name2Define.Add(this.r3.value, preDefine);
            }
            public readonly Token r4;
            public readonly Token r3;
            public readonly Token r2;
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex1(Token r4, Token r3, Token r2, Token r1, VnRandomTokens r0) {
                this.r4 = r4;
                this.r3 = r3;
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [009] MicroDefinition = '#define' 'identifier' RandomTokens ;
        public VnMicroDefinition(Token r2, Token r1, VnRandomTokens r0) {
            this.complex = new complex2(r2, r1, r0);
        }
        class complex2 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                var preDefine = new PreDefine(this.r1.value, hasParentheses: true);
                foreach (var item in this.r0.Enumerate()) {
                    var token = item.complex;
                    preDefine.postTokens.Add(token);
                }
                ppContext.name2Define.Add(this.r1.value, preDefine);
            }
            public readonly Token r2;
            public readonly Token r1;
            public readonly VnRandomTokens r0;
            public complex2(Token r2, Token r1, VnRandomTokens r0) {
                this.r2 = r2;
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [010] MicroDefinition = '#undef' 'identifier' ;
        public VnMicroDefinition(Token r1, Token r0) {
            this.complex = new complex3(r1, r0);
        }
        class complex3 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                ppContext.name2Define.Remove(this.r0.value);
            }
            public readonly Token r1;
            public readonly Token r0;
            public complex3(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }



    }
}
