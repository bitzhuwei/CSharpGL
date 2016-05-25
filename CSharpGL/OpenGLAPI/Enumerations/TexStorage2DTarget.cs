using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexStorage2DTarget : uint
    {
        Texture2D = OpenGL.GL_TEXTURE_2D,
        ProxyTexture2D = OpenGL.GL_PROXY_TEXTURE_2D,
        Texture1DArray = OpenGL.GL_TEXTURE_1D_ARRAY,
        ProxyTexture1DArray = OpenGL.GL_PROXY_TEXTURE_1D_ARRAY,
        TextureRectangle = OpenGL.GL_TEXTURE_RECTANGLE,
        ProxyTextureRectangle = OpenGL.GL_PROXY_TEXTURE_RECTANGLE,
        TextureCubeMap = OpenGL.GL_TEXTURE_CUBE_MAP,
        ProxyTextureCubeMap = OpenGL.GL_PROXY_TEXTURE_CUBE_MAP,
    }
}
