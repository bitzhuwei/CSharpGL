using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public enum TexStorageTarget : uint {
        Texture2D = GL.GL_TEXTURE_2D,
        ProxyTexture2D = GL.GL_PROXY_TEXTURE_2D,
        Texture1DArray = GL.GL_TEXTURE_1D_ARRAY,
        ProxyTexture1DArray = GL.GL_PROXY_TEXTURE_1D_ARRAY,
        TextureRectangle = GL.GL_TEXTURE_RECTANGLE,
        ProxyTextureRectangle = GL.GL_PROXY_TEXTURE_RECTANGLE,
        TextureCubeMap = GL.GL_TEXTURE_CUBE_MAP,
        ProxyTextureCubeMap = GL.GL_PROXY_TEXTURE_CUBE_MAP
    }
}
