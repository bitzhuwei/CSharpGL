using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LeveledData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual void LockData(out int level, out IntPtr data)
        {
            level = 0; data = IntPtr.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void FreeData() { }
    }
}
