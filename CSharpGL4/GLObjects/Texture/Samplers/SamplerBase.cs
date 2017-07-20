using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    public abstract class SamplerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplerUnit">similar to texture's unit.</param>
        public abstract void Apply(uint samplerUnit);
    }
}
