using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node EqualExp in the grammar(PreDirective).
    /// </summary>
    internal partial class VnEqualExp : IFullFormat {
        // [098] EqualExp = RelationExp ;
        // [099] EqualExp = EqualExp '==' RelationExp ;
        // [100] EqualExp = EqualExp '!=' RelationExp ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [098] EqualExp = EqualExp '==' RelationExp ;
        public void Add(Token r1, VnRelationExp r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal int CalcValue(SoftGLImpl.PpContext ppContext) {
            var final = this.r0.CalcValue(ppContext);
            foreach (var item in this.postfix) {
                int value = item.CalcValue(ppContext);
                if (final == value) { final = 1; }
                else { final = 0; }
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
            public readonly VnRelationExp r0;
            public Postfix0(Token r1, VnRelationExp r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }

        // [099] EqualExp = EqualExp '!=' RelationExp ;
        // Pre/Postfix1 repeated with Pre/Postfix0


        public readonly VnRelationExp r0;
        public VnEqualExp(VnRelationExp r0) {
            this.r0 = r0;
        }


    }
}
