using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public interface ITextureSource
    {
        Texture BindingTexture { get; }
    }
}
