using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    unsafe class TexParameterfv : TexParameter {
        private float* pValue;

        public float* PValue {
            get { return pValue; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(uint pname, string pnameString, float* pValue)
            : base(pname, pnameString) {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(PropertyName pname, float* pValue)
            : base((uint)pname, pname.ToString()) {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Apply(BindTextureTarget target) {
            SoftGL.glTexParameterfv((GLenum)target, PName, PValue);
            //GL.Instance.TexParameterfv((uint)target, PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glTexParameterfv({0}, {1}, {2} ..);", " ", this.PNameString, this.PValue[0]);
        }
    }
}
