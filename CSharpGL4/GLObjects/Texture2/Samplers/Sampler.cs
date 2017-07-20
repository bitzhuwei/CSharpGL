using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Sampler : SamplerBase, IDisposable
    {
        private static readonly GLDelegates.void_int_uintN glDeleteSamplers;
        static Sampler()
        {
            glDeleteSamplers = GL.Instance.GetDelegateFor("glDeleteSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        }

        private List<SamplerParameter> pparameterList = new List<SamplerParameter>();

        /// <summary>
        /// 
        /// </summary>
        public List<SamplerParameter> PparameterList { get { return pparameterList; } }

        private uint[] ids = new uint[1];

        /// <summary>
        /// 
        /// </summary>
        public uint Id { get { return this.ids[0]; } }


    }
}
