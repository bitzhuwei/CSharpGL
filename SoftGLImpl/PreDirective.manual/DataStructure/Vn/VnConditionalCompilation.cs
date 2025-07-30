using System;
using System.Diagnostics;
using bitzhuwei.Compiler;
using SoftGLImpl;

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

        public void Update(SoftGLImpl.PpContext ppContext) {
            complex.Update(ppContext);
            var last = ppContext.conditionalObjs.LastOne();
            Debug.Assert(last != null);
            if (last != null) {
                ppContext.isActive = last.IsActive(ppContext);
            }
        }


        // [068] ConditionalCompilation = IfGroup ;
        public VnConditionalCompilation(VnIfGroup r0) {
            this.complex = new complex0(r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnIfGroup r0;
            public complex0(VnIfGroup r0) {
                this.r0 = r0;
            }
        }

        // [069] ConditionalCompilation = ElseGroup ;
        public VnConditionalCompilation(VnElseGroup r0) {
            this.complex = new complex1(r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnElseGroup r0;
            public complex1(VnElseGroup r0) {
                this.r0 = r0;
            }
        }

        // [070] ConditionalCompilation = ElifGroup ;
        public VnConditionalCompilation(VnElifGroup r0) {
            this.complex = new complex2(r0);
        }
        class complex2 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnElifGroup r0;
            public complex2(VnElifGroup r0) {
                this.r0 = r0;
            }
        }

        // [071] ConditionalCompilation = EndifGroup ;
        public VnConditionalCompilation(VnEndifGroup r0) {
            this.complex = new complex3(r0);
        }
        class complex3 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnEndifGroup r0;
            public complex3(VnEndifGroup r0) {
                this.r0 = r0;
            }
        }



    }
}
