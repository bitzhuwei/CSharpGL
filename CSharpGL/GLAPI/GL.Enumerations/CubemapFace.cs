using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum CubemapFace : uint
    {
        /// <summary>
        /// 
        /// </summary>
        PositiveX = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        /// <summary>
        /// 
        /// </summary>
        NegtiveX = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        /// <summary>
        /// 
        /// </summary>
        PositiveY = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        /// <summary>
        /// 
        /// </summary>
        NegtiveY = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        /// <summary>
        /// 
        /// </summary>
        PositiveZ = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        /// <summary>
        /// 
        /// </summary>
        NegtiveZ = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }
}
