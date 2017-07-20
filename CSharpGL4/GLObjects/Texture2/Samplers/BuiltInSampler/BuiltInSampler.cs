using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    public class BuiltInSampler : SamplerBase
    {

        private List<TexParameter> parameterList = new List<TexParameter>();

        /// <summary>
        /// 
        /// </summary>
        public List<TexParameter> ParameterList { get { return parameterList; } }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            foreach (var item in this.parameterList)
            {
                item.Apply();
            }
        }
    }
}
