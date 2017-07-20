using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexImageDataProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IntPtr GetData();
    }
}
