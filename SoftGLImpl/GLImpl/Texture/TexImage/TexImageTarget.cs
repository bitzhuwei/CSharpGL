using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public enum ImageTarget : uint {
        Texture2D = GL.GL_TEXTURE_2D,
        ProxyTexture2D = GL.GL_PROXY_TEXTURE_2D,
        Texture1DArray = GL.GL_TEXTURE_1D_ARRAY,
        ProxyTexture1DArray = GL.GL_PROXY_TEXTURE_1D_ARRAY,
        TextureRectangle = GL.GL_TEXTURE_RECTANGLE,
        ProxyTextureRectangle = GL.GL_PROXY_TEXTURE_RECTANGLE,
        TextureCubeMapPositiveX = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        TextureCubeMapNegativeX = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        TextureCubeMapPositiveY = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        TextureCubeMapNegativeY = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        TextureCubeMapPositiveZ = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        TextureCubeMapNegativeZ = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
        ProxyTextureCubeMap = GL.GL_PROXY_TEXTURE_CUBE_MAP
    }
}
