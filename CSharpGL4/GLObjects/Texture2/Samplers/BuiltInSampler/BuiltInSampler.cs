using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// Built-in sampler object in a texture object.
    /// </summary>
    public class BuiltInSampler : List<TexParameter>
    {
        /// <summary>
        /// Apply all texture parameters to currently binding texture object.
        /// </summary>
        public void Apply()
        {
            foreach (var item in this)
            {
                item.Apply();
            }
        }
    }
}
