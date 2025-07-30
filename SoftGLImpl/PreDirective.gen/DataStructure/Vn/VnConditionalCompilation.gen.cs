using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ConditionalCompilation in the grammar(PreDirective).
    /// </summary>
    internal partial class VnConditionalCompilation : IFullFormat {
        // [068] ConditionalCompilation = IfGroup ;
        // [069] ConditionalCompilation = ElseGroup ;
        // [070] ConditionalCompilation = ElifGroup ;
        // [071] ConditionalCompilation = EndifGroup ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [068] ConditionalCompilation = IfGroup ;
        public VnConditionalCompilation(VnIfGroup r0) {
            this.complex = new complex0(r0);
            this._scope = new TokenRange(r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly VnIfGroup r0;
            public complex0(VnIfGroup r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [069] ConditionalCompilation = ElseGroup ;
        public VnConditionalCompilation(VnElseGroup r0) {
            this.complex = new complex1(r0);
            this._scope = new TokenRange(r0);
        }
        class complex1 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly VnElseGroup r0;
            public complex1(VnElseGroup r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [070] ConditionalCompilation = ElifGroup ;
        public VnConditionalCompilation(VnElifGroup r0) {
            this.complex = new complex2(r0);
            this._scope = new TokenRange(r0);
        }
        class complex2 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly VnElifGroup r0;
            public complex2(VnElifGroup r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [071] ConditionalCompilation = EndifGroup ;
        public VnConditionalCompilation(VnEndifGroup r0) {
            this.complex = new complex3(r0);
            this._scope = new TokenRange(r0);
        }
        class complex3 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly VnEndifGroup r0;
            public complex3(VnEndifGroup r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }



    }
}
