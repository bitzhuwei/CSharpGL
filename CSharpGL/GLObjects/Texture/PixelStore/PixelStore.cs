using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// glPixelStore/f();
    /// </summary>
    public abstract unsafe class PixelStore {
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
        protected PixelStore(uint pname, string pnameString) {
            this.PName = pname; this.PNameString = pnameString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PixelStore Create(uint pname, string pnameString, int value) {
            return new PixelStorei(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PixelStore Create(uint pname, string pnameString, float value) {
            return new PixelStoref(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Setup();
    }
}
