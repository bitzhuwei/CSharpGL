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

        ///// <summary>
        ///// 此shader保存到GLSL文件时的名字。
        ///// </summary>
        //public string Filename { get; set; }

        ///// <summary>
        ///// 此类型的shader保存到GLSL文件时的扩展名。（不包含'.'）
        ///// </summary>
        //public abstract string ExtensionName { get; }

        //public string GetShaderFilename()
        //{
        //    string name = this.GetType().Name;
        //    if (name.ToLower().EndsWith(this.ExtensionName.ToLower()))
        //    {
        //        name = name.Substring(0, name.Length - this.ExtensionName.Length) + "." + ExtensionName;
        //    }
        //    else
        //    {
        //        name = name + "." + ExtensionName;
        //    }

        //    return name;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="fullname">此shader代码所在的文件名。</param>
        ///// <returns></returns>
        //public abstract SemanticShader Dump(string fullname);

        /// <summary>
        /// 每个shader都必须实现自己的main函数。
        /// </summary>
        public abstract void main();

        ///// <summary>
        ///// 所有CSSL都共有的内容。
        ///// </summary>
        ///// <param name="shaderFilename">此shader保存到GLSL文件时的名字。</param>
        //public ShaderCode(string shaderFilename = null)
        //{
        //    if (string.IsNullOrEmpty(shaderFilename))
        //    {
        //        string name = this.GetType().Name;
        //        if (name.ToLower().EndsWith(this.ExtensionName.ToLower()))
        //        {
        //            this.Filename = name.Substring(0, name.Length - this.ExtensionName.Length);
        //        }
        //        else
        //        {
        //            this.Filename = name;
        //        }
        //    }
        //    else
        //    {
        //        this.Filename = shaderFilename;
        //    }
        //}
    }
}
