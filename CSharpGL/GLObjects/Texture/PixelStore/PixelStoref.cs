using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glPixelStoref();
    /// </summary>
    public unsafe class PixelStoref : PixelStore {
        public float PValue;

        /// <summary>
        /// glPixelStoref();
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public PixelStoref(uint pname, string pnameString, float pValue)
            : base(pname, pnameString) {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Setup() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glPixelStoref(PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glPixelStoref({0}, {1});", this.PNameString, this.PValue);
        }
    }
}
