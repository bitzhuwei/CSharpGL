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

        protected vec2 vec2(double v1, double v2) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(double v1, double v2, double v3) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(vec2 v1, double v2) { throw new NotNeedToImplementException(); }
        protected vec3 vec3(double v1, vec2 v2) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(double v1, double v2, double v3, double v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec2 v2, double v3, double v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(double v1, vec2 v3, double v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(double v1, double v2, vec2 v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(vec3 v3, double v4) { throw new NotNeedToImplementException(); }
        protected vec4 vec4(double v1, vec3 v4) { throw new NotNeedToImplementException(); }


        protected vec4 texture(sampler1D texture, double uv) { throw new NotNeedToImplementException(); }
        protected vec4 texture(sampler2D texture, vec2 uv) { throw new NotNeedToImplementException(); }
        protected vec4 texture(sampler3D texture, vec3 uv) { throw new NotNeedToImplementException(); }

        #endregion

    }
}
