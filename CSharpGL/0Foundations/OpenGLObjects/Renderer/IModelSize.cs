using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// gets model's original size.
    /// </summary>
    public interface IModelSize
    {
        /// <summary>
        /// Length in X axis.
        /// </summary>
        float XLength { get; }
        /// <summary>
        /// Length in Y axis.
        /// </summary>
        float YLength { get; }
        /// <summary>
        /// Length in Z axis.
        /// </summary>
        float ZLength { get; }
    }
}
