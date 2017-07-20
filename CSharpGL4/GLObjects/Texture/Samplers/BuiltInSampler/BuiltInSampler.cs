using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Built-in sampler object in a texture object.
    /// </summary>
    public class BuiltInSampler : List<TexParameter>
    {
        /// <summary>
        /// Apply all texture parameters to currently binding texture object.
        /// </summary>
        /// <param name="target"></param>
        public void Apply(TextureTarget target)
        {
            foreach (var item in this)
            {
                item.Apply(target);
            }
        }
    }
}
