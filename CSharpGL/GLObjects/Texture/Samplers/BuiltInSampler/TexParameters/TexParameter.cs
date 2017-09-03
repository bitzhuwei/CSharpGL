using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameteri/f();
    /// </summary>
    public abstract partial class TexParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public string PNameString { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public uint PName { get; private set; }

        /// <summary>
        /// glTexParameteri/f();
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        protected TexParameter(uint pname, string pnameString)
        {
            this.PName = pname; this.PNameString = pnameString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TexParameter Create(uint pname, string pnameString, int value)
        {
            return new TexParameteri(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TexParameter Create(PropertyName pname, int value)
        {
            return new TexParameteri((uint)pname, pname.ToString(), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TexParameter Create(uint pname, string pnameString, float value)
        {
            return new TexParameterf(pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TexParameter Create(PropertyName pname, float value)
        {
            return new TexParameterf((uint)pname, pname.ToString(), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public abstract void Apply(TextureTarget target);
    }
}
