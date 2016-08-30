using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content.
    /// </summary>
    public abstract class ImageBuilder
    {

        /// <summary>
        /// build texture's content.
        /// </summary>
        /// <param name="target"></param>
        public abstract void Build(BindTextureTarget target);
    }
}
