using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    enum BindTextureTarget : uint {
        Texture1D = GL.GL_TEXTURE_1D,
        Texture2D = GL.GL_TEXTURE_2D,
        Texture3D = GL.GL_TEXTURE_3D,
        Texture1DArray = GL.GL_TEXTURE_1D_ARRAY,
        Texture2DArray = GL.GL_TEXTURE_2D_ARRAY,
        TextureRectangle = GL.GL_TEXTURE_RECTANGLE,
        TextureCubeMap = GL.GL_TEXTURE_CUBE_MAP,
        Texture2DMultisample = GL.GL_TEXTURE_2D_MULTISAMPLE,
        Texture2DMultisampleArray = GL.GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
        TextureBuffer = GL.GL_TEXTURE_BUFFER,
        TextureCubeMapArray = GL.GL_TEXTURE_CUBE_MAP_ARRAY
    }
}
