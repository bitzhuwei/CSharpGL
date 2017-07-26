using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glPixelStorei();
    /// </summary>
    public class PixelStorei : PixelStore
    {
        /// <summary>
        /// 
        /// </summary>
        public int PValue { get; set; }

        /// <summary>
        /// glPixelStorei();
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="pValue"></param>
        public PixelStorei(uint pname, string pnameString, int pValue)
            : base(pname, pnameString)
        {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Setup()
        {
            GL.Instance.PixelStorei(PName, PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glPixelStorei({0}, {1});", this.PNameString, this.PValue);
        }
    }
}
