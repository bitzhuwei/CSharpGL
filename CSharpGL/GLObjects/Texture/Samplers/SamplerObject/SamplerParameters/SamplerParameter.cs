using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glTexParameteri/f();
    /// </summary>
    public abstract unsafe class SamplerParameter {
        /// <summary>
        /// 
        /// </summary>
        public readonly string PNameString;

        /// <summary>
        /// 
        /// </summary>
        public readonly uint PName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        protected SamplerParameter(uint pname, string pnameString) {
            this.PName = pname; this.PNameString = pnameString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SamplerParameter Create(uint pname, string pnameString, int value) {
            return new SamplerParameteri(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SamplerParameter Create(uint pname, string pnameString, float value) {
            return new SamplerParameterf(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplerId"></param>
        public abstract void Apply(uint samplerId);
    }
}
