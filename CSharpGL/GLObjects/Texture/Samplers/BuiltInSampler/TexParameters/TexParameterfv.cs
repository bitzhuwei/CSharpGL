using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    public unsafe class TexParameterfv : TexParameter {
        public readonly float[] pValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(uint pname, string pnameString, params float[] pValue)
            : base(pname, pnameString) {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(PropertyName pname, params float[] pValue)
            : base((uint)pname, pname.ToString()) {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Apply(TextureTarget target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glTexParameterfv((GLenum)target, PName, pValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glTexParameterfv({0}, {1}, {2});", " ", this.PNameString, this.pValue);
        }
    }
}
