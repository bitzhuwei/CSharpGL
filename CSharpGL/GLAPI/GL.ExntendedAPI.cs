using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GL
    {
        // extended OpenGL API
        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionName">function name</param>
        /// <param name="functionDeclaration"></param>
        /// <returns></returns>
        public abstract Delegate GetDelegateFor(string functionName, Type functionDeclaration);
    }
}
