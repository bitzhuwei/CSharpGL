using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Specifies the target to which the texture whose mimaps to generate is bound. target​ must be GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D_ARRAY, GL_TEXTURE_CUBE_MAP, or GL_TEXTURE_CUBE_MAP_ARRAY
    /// </summary>
    public enum MipmapTarget : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Texture1D = OpenGL.GL_TEXTURE_1D,
        /// <summary>
        /// 
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,
        /// <summary>
        /// 
        /// </summary>
        Texture3D = OpenGL.GL_TEXTURE_3D,
        /// <summary>
        /// 
        /// </summary>
        Texture1DArray = OpenGL.GL_TEXTURE_1D_ARRAY,
        /// <summary>
        /// 
        /// </summary>
        Texture2DArray = OpenGL.GL_TEXTURE_2D_ARRAY,
        /// <summary>
        /// 
        /// </summary>
        TextureCubeMap = OpenGL.GL_TEXTURE_CUBE_MAP,
        /// <summary>
        /// 
        /// </summary>
        TextureCubeMapArray = OpenGL.GL_TEXTURE_CUBE_MAP_ARRAY
    }
}
