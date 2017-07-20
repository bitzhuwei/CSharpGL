using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameteri();
    /// </summary>
    public class TexParameteri : TexParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public int PValue { get; set; }

        public TexParameteri(TextureTarget target, uint pname, string pnameString, int pValue)
            : base(target, pname, pnameString)
        {
            this.PValue = pValue;
        }


        public override void Apply()
        {
            GL.Instance.TexParameteri((uint)Target, PName, PValue);
        }

        public override string ToString()
        {
            return string.Format("glTexParameteri({0}, {1}, {2});", this.Target, this.PNameString, this.PValue);
        }
    }
}
