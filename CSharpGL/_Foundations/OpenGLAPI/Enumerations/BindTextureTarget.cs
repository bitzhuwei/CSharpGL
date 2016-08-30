using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Specifies the target to which the texture is bound. Must be either GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, or GL_TEXTURE_CUBE_MAP. 
    /// </summary>
    public enum BindTextureTarget : uint
    {
        /// <summary>
        /// The initial value is GL_ZERO
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
        TextureCubeMap = OpenGL.GL_TEXTURE_CUBE_MAP,
    }

}
