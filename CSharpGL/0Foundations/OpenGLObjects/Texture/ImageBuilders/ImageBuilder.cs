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
        private BindTextureTarget target;

        /// <summary>
        /// 
        /// </summary>
        public BindTextureTarget Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// build texture's content.
        /// </summary>
        /// <returns></returns>
        public abstract void Build();
    }
}
