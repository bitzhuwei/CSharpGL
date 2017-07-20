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
        private static readonly GLDelegates.void_int_uintN glGenSamplers;
        private static readonly GLDelegates.void_uint_uint glBindSampler;
        private static readonly GLDelegates.void_int_uintN glDeleteSamplers;
        static Sampler()
        {
            glGenSamplers = GL.Instance.GetDelegateFor("glGenSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindSampler = GL.Instance.GetDelegateFor("glBindSampler", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteSamplers = GL.Instance.GetDelegateFor("glDeleteSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        }

        private List<SamplerParameter> parameterList = new List<SamplerParameter>();

        /// <summary>
        /// 
        /// </summary>
        public List<SamplerParameter> ParameterList { get { return parameterList; } }

        private uint[] ids = new uint[1];

        /// <summary>
        /// 
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// 
        /// </summary>
        public Sampler()
        {
            glGenSamplers(this.ids.Length, this.ids);
        }

        private bool isBinded = false;
        private uint samplerUnit = uint.MaxValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplerUnit">similar to texture's unit.</param>
        public void Bind(uint samplerUnit)
        {
            if (!this.isBinded)
            {
                glBindSampler(samplerUnit, this.ids[0]);
                this.samplerUnit = samplerUnit;
                this.isBinded = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind()
        {
            if (this.isBinded)
            {
                glBindSampler(this.samplerUnit, 0);
                this.samplerUnit = uint.MaxValue;
                this.isBinded = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            foreach (var item in this.parameterList)
            {
                item.Apply(this.Id);
            }
        }
    }
}
