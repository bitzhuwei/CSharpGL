using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node RelationExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnRelationExp : IFullFormat {
        // [101] RelationExp = ShiftExp ;
        // [102] RelationExp = RelationExp '<' ShiftExp ;
        // [103] RelationExp = RelationExp '>' ShiftExp ;
        // [104] RelationExp = RelationExp '<=' ShiftExp ;
        // [105] RelationExp = RelationExp '>=' ShiftExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [102] RelationExp = RelationExp '<' ShiftExp ;
        public void Add(Token r1, VnShiftExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            int final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                int value = item.CalcValue(ppContext);
                switch (item.r1.value) {
                case "<": final = (final < value) ? 1 : 0; break;
                case ">": final = (final > value) ? 1 : 0; break;
                case "<=": final = (final <= value) ? 1 : 0; break;
                case ">=": final = (final >= value) ? 1 : 0; break;
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
            public readonly VnShiftExp r0;
            public Postfix0(Token r1, VnShiftExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [103] RelationExp = RelationExp '>' ShiftExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0

        // [104] RelationExp = RelationExp '<=' ShiftExp ;
        // Pre/Postfix2 repeated with Pre/Postfix0

        // [105] RelationExp = RelationExp '>=' ShiftExp ;
        // Pre/Postfix3 repeated with Pre/Postfix0


        public readonly VnShiftExp r0;
        public VnRelationExp(VnShiftExp r0) {
            this.r0 = r0;
        }


    }
}
