using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLControlRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        void Render(IGLControl control);
    }
}
