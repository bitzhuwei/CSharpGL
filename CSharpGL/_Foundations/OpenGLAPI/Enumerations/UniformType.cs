using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum UniformType : uint
    {
        /// <summary>
        /// 
        /// </summary>
        MATERIAL = 0,
        /// <summary>
        /// 
        /// </summary>
        TRANSFORM0 = 1,
        /// <summary>
        /// 
        /// </summary>
        TRANSFORM1 = 2,
        /// <summary>
        /// 
        /// </summary>
        INDIRECTION = 3,
        /// <summary>
        /// 
        /// </summary>
        CONSTANT = 0,
        /// <summary>
        /// 
        /// </summary>
        PER_FRAME = 1,
        /// <summary>
        /// 
        /// </summary>
        PER_PASS = 2
    }
}
