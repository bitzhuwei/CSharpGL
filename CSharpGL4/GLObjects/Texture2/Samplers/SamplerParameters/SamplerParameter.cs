using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// glTexParameteri/f();
    /// </summary>
    public abstract class SamplerParameter
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
        public TextureTarget Target { get; private set; }

        protected SamplerParameter(TextureTarget target, uint pname, string pnameString)
        {
            this.Target = target;
            this.PName = pname; this.PNameString = pnameString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SamplerParameter Create(TextureTarget target, uint pname, string pnameString, int value)
        {
            return new SamplerParameteri(target, pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pnameString"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SamplerParameter Create(TextureTarget target, uint pname, string pnameString, float value)
        {
            return new SamplerParameterf(target, pname, pnameString, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Apply();
    }
}
