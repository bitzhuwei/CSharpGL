using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameterf();
    /// </summary>
    public class TexParameterf : TexParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public float PValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public TexParameterf(uint pname, string pnameString, float pValue)
            : base(pname, pnameString)
        {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pValue"></param>
        public TexParameterf(PropertyName pname, float pValue)
            : base((uint)pname, pname.ToString())
        {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Apply(TextureTarget target)
        {
            GL.Instance.TexParameterf((uint)target, PName, PValue);
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
