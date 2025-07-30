using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node ParameterList in the grammar(PreDirective).
    /// </summary>
    internal partial class VnParameterList : IFullFormat {
        // [011] ParameterList = 'identifier' ;
        // [012] ParameterList = ParameterList ',' 'identifier' ;


        private readonly List<Postfix0> postfix = new();

        public void Update(SoftGLImpl.PpContext ppContext) {
        }

        // [012] ParameterList = ParameterList ',' 'identifier' ;
        public void Add(Token r1, Token r0) {
            this.postfix.Add(new Postfix0(r1, r0));
        }

        internal IEnumerable<Token> Enumerate() {
            yield return this.r0;
            foreach (var item in this.postfix) {
                yield return item.r0;
            }
        }

        class Postfix0 : IFullFormat {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public readonly Token r1;
            public readonly Token r0;
            public Postfix0(Token r1, Token r0) {
                this.r1 = r1;
                this.r0 = r0;
            }
        }


        public readonly Token r0;
        public VnParameterList(Token r0) {
            this.r0 = r0;
        }


    }
}
