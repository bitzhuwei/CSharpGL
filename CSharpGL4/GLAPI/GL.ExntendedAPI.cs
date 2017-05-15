using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual Delegate GetDelegateFor(string functionName, Type functionDeclaration) { return null; }
    }
}
