using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract partial class TexParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public enum PropertyName : uint
        {
            /// <summary>
            /// 
            /// </summary>
            TextureMinFilter = GL.GL_TEXTURE_MIN_FILTER,
            /// <summary>
            /// 
            /// </summary>
            TextureMagFilter = GL.GL_TEXTURE_MAG_FILTER,
            /// <summary>
            /// 
            /// </summary>
            TextureMinLOD = GL.GL_TEXTURE_MIN_LOD,
            /// <summary>
            /// 
            /// </summary>
            TextureMaxLOD = GL.GL_TEXTURE_MAX_LOD,
            /// <summary>
            /// 
            /// </summary>
            TextrueBaseLevel = GL.GL_TEXTURE_BASE_LEVEL,
            /// <summary>
            /// 
            /// </summary>
            TextureMaxLevel = GL.GL_TEXTURE_MAX_LEVEL,
            /// <summary>
            /// 
            /// </summary>
            TextureWrapS = GL.GL_TEXTURE_WRAP_S,
            /// <summary>
            /// 
            /// </summary>
            TextureWrapT = GL.GL_TEXTURE_WRAP_T,
            /// <summary>
            /// 
            /// </summary>
            TextureWrapR = GL.GL_TEXTURE_WRAP_R,
            /// <summary>
            /// 
            /// </summary>
            TexturePriority = GL.GL_TEXTURE_PRIORITY,
            /// <summary>
            /// 
            /// </summary>
            TextureCompareMode = GL.GL_TEXTURE_COMPARE_MODE,
            /// <summary>
            /// 
            /// </summary>
            TextureCompareFunc = GL.GL_TEXTURE_COMPARE_FUNC,
            /// <summary>
            /// 
            /// </summary>
            DepthTextureMode = GL.GL_DEPTH_TEXTURE_MODE,
            /// <summary>
            /// 
            /// </summary>
            GenerateMipmap = GL.GL_GENERATE_MIPMAP,
            /// <summary>
            /// 
            /// </summary>
            TextureBorderColor = GL.GL_TEXTURE_BORDER_COLOR,
        }
    }
}
