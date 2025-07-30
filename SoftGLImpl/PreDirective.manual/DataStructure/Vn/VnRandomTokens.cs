using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node RandomTokens in the grammar(PreDirective).
    /// </summary>
    internal partial class VnRandomTokens : IFullFormat {
        // [013] RandomTokens = RandomTokens RandomToken ;
        // [014] RandomTokens = RandomToken ;
        // [015] RandomTokens = null ;

        interface IEnumerate {
            public IEnumerable<VnRandomToken> Enumerate();
        }
        private readonly IEnumerate complex;

        public void Update(SoftGLImpl.PpContext ppContext) {
        }
        public IEnumerable<VnRandomToken> Enumerate() {
            foreach (var item in this.complex.Enumerate()) {
                yield return item;
            }
            foreach (var item in this.postfix) {
                yield return item;
            }
        }

        private readonly List<VnRandomToken> postfix = new();
        public void Add(VnRandomToken r0) {
            this.postfix.Add(r0);
        }

        // [014] RandomTokens = RandomToken ;
        public VnRandomTokens(VnRandomToken r0) {
            this.complex = new complex0(r0);
        }
        class complex0 : IFullFormat, IEnumerate {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public IEnumerable<VnRandomToken> Enumerate() {
                yield return this.r0;
            }
            public readonly VnRandomToken r0;
            public complex0(VnRandomToken r0) {
                this.r0 = r0;
            }
        }

        // [015] RandomTokens = null ;
        public VnRandomTokens() {
            this.complex = new complex1();
        }
        class complex1 : IFullFormat, IEnumerate {
            public void Update(SoftGLImpl.PpContext ppContext) {
            }
            public IEnumerable<VnRandomToken> Enumerate() {
                yield break;
            }
            public complex1() {
            }
        }



    }
}
