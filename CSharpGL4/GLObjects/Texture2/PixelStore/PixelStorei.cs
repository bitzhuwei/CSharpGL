using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
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

        public PixelStorei(uint pname, string pnameString, int pValue)
            : base(pname, pnameString)
        {
            this.PValue = pValue;
        }

        public override void Setup()
        {
            GL.Instance.PixelStorei(PName, PValue);
        }

        public override string ToString()
        {
            return string.Format("glPixelStorei({0}, {1});", this.PNameString, this.PValue);
        }
    }
}
