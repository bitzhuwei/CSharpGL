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
        public readonly int level;

        /// <summary>
        /// 
        /// </summary>
        public LeveledData() : this(0) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        public LeveledData(int level)
        {
            this.level = level;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IntPtr LockData()
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void FreeData() { }
    }
}
