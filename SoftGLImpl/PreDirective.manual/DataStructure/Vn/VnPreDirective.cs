using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node PreDirective in the grammar(PreDirective).
    /// </summary>
    internal partial class VnPreDirective : IFullFormat {
        // [000] PreDirective = MicroDefinition ;
        // [001] PreDirective = ConditionalCompilation ;
        // [002] PreDirective = ErrorDirective ;
        // [003] PreDirective = PragmaDirective ;
        // [004] PreDirective = ExtensionDirective ;
        // [005] PreDirective = VersionDirective ;
        // [006] PreDirective = LineDirective ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [000] PreDirective = MicroDefinition ;
        public VnPreDirective(VnMicroDefinition r0) {
            this.complex = new complex0(r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnMicroDefinition r0;
            public complex0(VnMicroDefinition r0) {
                this.r0 = r0;
            }
        }

        // [001] PreDirective = ConditionalCompilation ;
        public VnPreDirective(VnConditionalCompilation r0) {
            this.complex = new complex1(r0);
        }
        class complex1 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnConditionalCompilation r0;
            public complex1(VnConditionalCompilation r0) {
                this.r0 = r0;
            }
        }

        // [002] PreDirective = ErrorDirective ;
        public VnPreDirective(VnErrorDirective r0) {
            this.complex = new complex2(r0);
        }
        class complex2 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnErrorDirective r0;
            public complex2(VnErrorDirective r0) {
                this.r0 = r0;
            }
        }

        // [003] PreDirective = PragmaDirective ;
        public VnPreDirective(VnPragmaDirective r0) {
            this.complex = new complex3(r0);
        }
        class complex3 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnPragmaDirective r0;
            public complex3(VnPragmaDirective r0) {
                this.r0 = r0;
            }
        }

        // [004] PreDirective = ExtensionDirective ;
        public VnPreDirective(VnExtensionDirective r0) {
            this.complex = new complex4(r0);
        }
        class complex4 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnExtensionDirective r0;
            public complex4(VnExtensionDirective r0) {
                this.r0 = r0;
            }
        }

        // [005] PreDirective = VersionDirective ;
        public VnPreDirective(VnVersionDirective r0) {
            this.complex = new complex5(r0);
        }
        class complex5 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnVersionDirective r0;
            public complex5(VnVersionDirective r0) {
                this.r0 = r0;
            }
        }

        // [006] PreDirective = LineDirective ;
        public VnPreDirective(VnLineDirective r0) {
            this.complex = new complex6(r0);
        }
        class complex6 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                this.r0.Update(ppContext);
            }
            public readonly VnLineDirective r0;
            public complex6(VnLineDirective r0) {
                this.r0 = r0;
            }
        }



    }
}
