using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    public class TexParameterfv : TexParameter
    {
        private float[] pValue;

        public float[] PValue
        {
            get { return pValue; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(uint pname, string pnameString, params float[] pValue)
            : base(pname, pnameString)
        {
            this.pValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameterfv(PropertyName pname, params float[] pValue)
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
            GL.Instance.TexParameterfv((uint)target, PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glTexParameterf({0}, {1}, {2});", " ", this.PNameString, this.PValue);
        }
    }
}
