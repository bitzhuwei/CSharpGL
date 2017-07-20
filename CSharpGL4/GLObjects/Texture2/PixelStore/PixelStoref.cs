using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// glPixelStoref();
    /// </summary>
    public class PixelStoref : PixelStore
    {
        /// <summary>
        /// 
        /// </summary>
        public float PValue { get; set; }

        public PixelStoref(uint pname, string pnameString, float pValue)
            : base(pname, pnameString)
        {
            this.PValue = pValue;
        }

        public override void Setup()
        {
            GL.Instance.PixelStoref(PName, PValue);
        }

        public override string ToString()
        {
            return string.Format("glPixelStoref({0}, {1});", this.PNameString, this.PValue);
        }
    }
}
