using GLM;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 通过此接口设置元素的MVP矩阵
    /// </summary>
    [Obsolete("这个设计的不好！", "error")]    
    public interface IMVP
    {
        /// <summary>
        /// 更新此元素的MVP值。
        /// </summary>
        /// <param name="mvp">三个矩阵的乘积（Projection * View * Model）</param>
        void SetShaderProgram(mat4 mvp);

        /// <summary>
        /// 解绑当前shader program。
        /// </summary>
        void ResetShaderProgram();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Shaders.ShaderProgram GetShaderProgram();

    }
}
