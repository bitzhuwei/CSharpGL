using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class NewBitmapBuilder : NewImageBuilder
    {
        private System.Drawing.Bitmap bitmap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public NewBitmapBuilder(System.Drawing.Bitmap bitmap)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Build()
        {
            throw new NotImplementedException();
        }
    }
}
