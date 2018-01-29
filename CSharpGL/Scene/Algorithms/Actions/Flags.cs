using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum TwoFlags : byte
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        BeforeChildren = 2,

        /// <summary>
        /// 
        /// </summary>
        Children = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ThreeFlags : byte
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        BeforeChildren = 2,

        /// <summary>
        /// 
        /// </summary>
        Children = 4,

        /// <summary>
        /// 
        /// </summary>
        AfterChildren = 8,
    }

}
