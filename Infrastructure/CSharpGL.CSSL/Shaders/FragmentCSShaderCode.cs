using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.CSSL
{

    /// <summary>
    /// fragment shader共有的内容。
    /// 想写一个fragment shader，就继承此类型吧。
    /// </summary>
    public abstract partial class FragmentCSShaderCode : CSShaderCode
    {

        protected vec4 gl_FragCoord { get { return null; } private set { } }

        protected vec2 gl_PointCoord { get { return null; } private set { } }

        //TODO:在CSharpShaderLanguage.Convertor项目中没有区分vertex shader和fragment shader的Dump动作。目前是认为没有下面这个discard();方法的。注意注意！以后要改啊！
        /// <summary>
        /// 代表GLSL里的discard;语句。
        /// </summary>
        protected void discard() { }

    }

}
