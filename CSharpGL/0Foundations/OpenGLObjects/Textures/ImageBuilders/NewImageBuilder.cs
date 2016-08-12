using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// build texture.
    /// </summary>
    public abstract class NewImageBuilder
    {

        /// <summary>
        /// Build texture.
        /// </summary>
        /// <returns></returns>
        public abstract void Build();
    }
}
