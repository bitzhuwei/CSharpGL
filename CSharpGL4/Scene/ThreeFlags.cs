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
    public enum ThreeFlags : byte
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        BeforeChildren,

        /// <summary>
        /// 
        /// </summary>
        Children,

        /// <summary>
        /// 
        /// </summary>
        AfterChildren,
    }

}
