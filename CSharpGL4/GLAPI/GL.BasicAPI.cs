using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class GL
    {
        // basic OpenGL API
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public virtual void Begin(uint mode) { }
        /// <summary>
        /// 
        /// </summary>
        public virtual void End() { }
        // ...
    }
}
