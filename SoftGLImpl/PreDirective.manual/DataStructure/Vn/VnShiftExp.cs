using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ShiftExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnShiftExp : IFullFormat {
        // [106] ShiftExp = AddExp ;
        // [107] ShiftExp = ShiftExp '<<' AddExp ;
        // [108] ShiftExp = ShiftExp '>>' AddExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [107] ShiftExp = ShiftExp '<<' AddExp ;
        public void Add(Token r1, VnAddExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                var value = item.CalcValue(ppContext);
                switch (item.r1.value) {
                case "<<": final = final << value; break;
                case ">>": final = final >> value; break;
                default: throw new NotImplementedException();
                }
            }
            return final;
        }


        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }

            internal int CalcValue(SoftGLImpl.PpContext ppContext) {
                return this.r0.CalcValue(ppContext);
            }


            public readonly Token r1;
            public readonly VnAddExp r0;
            public Postfix0(Token r1, VnAddExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [108] ShiftExp = ShiftExp '>>' AddExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0


        public readonly VnAddExp r0;
        public VnShiftExp(VnAddExp r0) {
            this.r0 = r0;
        }


    }
}
