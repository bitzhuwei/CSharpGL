using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexStorage3DTarget : uint
    {
        Texture3D = OpenGL.GL_TEXTURE_3D,
        ProxyTexture3D = OpenGL.GL_PROXY_TEXTURE_3D,
        Texture2DArray = OpenGL.GL_TEXTURE_2D_ARRAY,
        ProxyTexture2DArray = OpenGL.GL_PROXY_TEXTURE_2D_ARRAY,
        TextureCubeMapArray = OpenGL.GL_TEXTURE_CUBE_MAP_ARRAY,
        ProxyTextureCubeMapArray = OpenGL.GL_PROXY_TEXTURE_CUBE_MAP_ARRAY,
    }
}
