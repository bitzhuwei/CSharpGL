﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    public unsafe class SamplerParameteri : SamplerParameter {
        //internal static readonly GLDelegates.void_uint_uint_int glSamplerParameteri;
        //static SamplerParameteri() {
        //    glSamplerParameteri = gl.glGetDelegateFor("glSamplerParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
        //}

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
        public SamplerParameteri(uint pname, string pnameString, int pValue)
            : base(pname, pnameString) {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplerId"></param>
        public override void Apply(uint samplerId) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glSamplerParameteri(samplerId, this.PName, this.PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glSamplerParameteri({0}, {1}, {2});", " ", this.PNameString, this.PValue);
        }
    }
}
