using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node IfGroup in the grammar(PreDirective).
    /// </summary>
    internal partial class VnIfGroup : IFullFormat {
        // [072] IfGroup = '#if' ConstExp ;
        // [073] IfGroup = '#ifdef' ConstExp ;
        // [074] IfGroup = '#ifndef' ConstExp ;


        private readonly IFullFormat complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
            this.complex.Update(ppContext);
        }


        // [072] IfGroup = '#if' ConstExp ;
        public VnIfGroup(Token r1, VnConstExp r0) {
            this.complex = new complex0(r1, r0);
        }
        class complex0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
                //ppContext.AppendConditionalTokens(tokens);
                //ppContext.RefreshConditionalState();
                If_.Kind kind;
                switch (this.r1.value) {
                case "#if": kind = If_.Kind.IF; break;
                case "#ifdef": kind = If_.Kind.IFDEF; break;
                case "#ifndef": kind = If_.Kind.IFNDEF; break;
                default: throw new NotImplementedException();
                }
                var obj = new IfElifsElseEnd(kind, this.r0.CalcValue(ppContext), endif: false);
                var objs = ppContext.conditionalObjs;
                var last = objs.LastOne();
                if (last == null || !last.Append(obj)) { objs.Add(obj); }
            }
            public readonly Token r1;
            public readonly VnConstExp r0;
            public complex0(Token r1, VnConstExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [073] IfGroup = '#ifdef' ConstExp ;
        // complex1 repeated with complex0

        // [074] IfGroup = '#ifndef' ConstExp ;
        // complex2 repeated with complex0



    }
}
