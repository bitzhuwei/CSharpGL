using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glTexParameteri();
    /// </summary>
    public class SamplerParameterf : SamplerParameter
    {
        internal static readonly GLDelegates.void_uint_uint_float glSamplerParameterf;
        static SamplerParameterf()
        {
            glSamplerParameterf = GL.Instance.GetDelegateFor("glSamplerParameterf", GLDelegates.typeof_void_uint_uint_float) as GLDelegates.void_uint_uint_float;
        }

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
        public SamplerParameterf(uint pname, string pnameString, float pValue)
            : base(pname, pnameString)
        {
            this.PValue = pValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplerId"></param>
        public override void Apply(uint samplerId)
        {
            glSamplerParameterf(samplerId, this.PName, this.PValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glSamplerParameterf({0}, {1}, {2});", " ", this.PNameString, this.PValue);
        }
    }
}
