using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Provides a <see cref="Texture"/> object.
    /// </summary>
    public interface ITextureSource
    {
        /// <summary>
        /// The provided texture object.
        /// </summary>
        Texture BindingTexture { get; }
    }
}
