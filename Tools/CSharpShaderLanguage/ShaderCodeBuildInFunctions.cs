using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class ShaderCode
    {

        #region build-in functions

        protected vec4 vec4(vec3 in_Position, double p)
        {
            throw new NotImplementedException();
        }


        protected vec4 texture(sampler2D texture1, vec2 pass_UV)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
