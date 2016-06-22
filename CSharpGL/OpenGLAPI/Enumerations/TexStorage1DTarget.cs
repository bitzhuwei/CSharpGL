using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public enum TexStorage1DTarget : uint
    {
        Texture1D = OpenGL.GL_TEXTURE_1D,
        ProxyTexture1D = OpenGL.GL_PROXY_TEXTURE_1D,
    }
}
