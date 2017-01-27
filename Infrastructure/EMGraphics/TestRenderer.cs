using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMGraphics
{
    /// <summary>
    /// 
    /// </summary>
    public class TestRenderer : PickableRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TestRenderer Create()
        {
            throw new NotImplementedException();
        }

        private TestRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {

        }
    }
}
