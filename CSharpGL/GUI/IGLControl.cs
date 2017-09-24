using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLControl
    {
        /// <summary>
        /// 
        /// </summary>
        void Layout();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        void Render(IControlRenderer renderer);
    }
}
