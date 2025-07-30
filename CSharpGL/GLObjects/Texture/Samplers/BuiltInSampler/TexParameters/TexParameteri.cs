﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glTexParameteri();
    /// </summary>
    public unsafe class TexParameteri : TexParameter {
        /// <summary>
        /// 
        /// </summary>
        public int PValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameteri(uint pname, string pnameString, int pValue)
            : base(pname, pnameString) {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameteri(PropertyName pname, int pValue)
            : base((uint)pname, pname.ToString()) {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Apply(TextureTarget target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glTexParameteri((GLenum)target, PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glTexParameteri({0}, {1}, {2});", " ", this.PNameString, this.PValue);
        }
    }
}
