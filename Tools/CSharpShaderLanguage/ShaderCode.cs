using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage
{
    /// <summary>
    /// 所有shader都共有的内容。
    /// </summary>
    public abstract class ShaderCode
    {
        #region build-in variables

        #endregion

        #region build-in functions

        protected vec4 vec4(vec3 in_Position, double p)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
