using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexImageDataProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IntPtr LockData() { return IntPtr.Zero; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void FreeData() { }
    }
}
