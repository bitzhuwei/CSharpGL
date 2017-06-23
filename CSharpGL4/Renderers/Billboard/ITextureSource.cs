using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextureSource
    {
        /// <summary>
        /// 
        /// </summary>
        Texture BindingTexture { get; }
    }
}
