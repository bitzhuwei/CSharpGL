using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexStorage3DTarget : uint
    {
        Texture3D = GL.GL_TEXTURE_3D,
        ProxyTexture3D = GL.GL_PROXY_TEXTURE_3D,
        Texture2DArray = GL.GL_TEXTURE_2D_ARRAY,
        ProxyTexture2DArray = GL.GL_PROXY_TEXTURE_2D_ARRAY,
        TextureCubeMapArray = GL.GL_TEXTURE_CUBE_MAP_ARRAY,
        ProxyTextureCubeMapArray = GL.GL_PROXY_TEXTURE_CUBE_MAP_ARRAY,
    }
}
