using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="IGLControl"/>.
    /// </summary>
    public interface IGLControlRenderer
    {
        /// <summary>
        /// Renders the specified <paramref name="control"/>.
        /// </summary>
        /// <param name="control"></param>
        void Render(IGLControl control);
    }
}
