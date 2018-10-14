using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    public class TexParameteriv : TexParameter
    {
        private int[] pValue;

        public int[] PValue
        {
            get { return pValue; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameteriv(uint pname, string pnameString, params int[] pValue)
            : base(pname, pnameString)
        {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameteriv(PropertyName pname, params int[] pValue)
            : base((uint)pname, pname.ToString())
        {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Apply(TextureTarget target)
        {
            GL.Instance.TexParameteriv((uint)target, PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glTexParameteriv({0}, {1}, {2});", " ", this.PNameString, this.PValue);
        }
    }
}
