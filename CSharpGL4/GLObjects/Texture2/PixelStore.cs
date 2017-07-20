using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// glPixelStore/f();
    /// </summary>
    public class PixelStore
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
        /// 
        /// </summary>
        public int PValueI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float PValueF { get; set; }

        private readonly bool useI;

        private PixelStore(uint pname, string pnameString, int pValueI, float pValueF, bool useI)
        {
            this.PName = pname; this.PNameString = pnameString;
            this.PValueI = pValueI; this.PValueF = pValueF;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PixelStore Create(uint pname, string pnameString, int value)
        {
            return new PixelStore(pname, pnameString, value, value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PixelStore Create(uint pname, string pnameString, float value)
        {
            return new PixelStore(pname, pnameString, (int)value, value, false);
        }

        public void Setup()
        {
            if (this.useI)
            {
                GL.Instance.PixelStorei(PName, PValueI);
            }
            else
            {
                GL.Instance.PixelStoref(PName, PValueF);
            }
        }

        public override string ToString()
        {
            if (this.useI)
            {
                return string.Format("glPixelStorei({0}, {1});", this.PNameString, this.PValueI);
            }
            else
            {
                return string.Format("glPixelStoref({0}, {1});", this.PNameString, this.PValueF);
            }
        }
    }
}
