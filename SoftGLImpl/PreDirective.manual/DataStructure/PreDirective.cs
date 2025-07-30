using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// extracted info from syntax tree(<see cref="LRNode"/>).
    /// </summary>
    public partial class PreDirective {
        private readonly VnPreDirective @final;
        internal PreDirective(VnPreDirective @final) {
            this.@final = @final;
        }
        public void Update(SoftGLImpl.PpContext ppContext) {
            this.final.Update(ppContext);
        }

    }
}
