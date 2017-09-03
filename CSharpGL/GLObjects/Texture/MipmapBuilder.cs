using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Generates mipmap for texture.
    /// </summary>
    public class MipmapBuilder
    {
        private static readonly GLDelegates.void_uint glGenerateMipmap;

        static MipmapBuilder()
        {
            glGenerateMipmap = GL.Instance.GetDelegateFor("glGenerateMipmap", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        }

        /// <summary>
        /// Generates mipmap for texture.
        /// </summary>
        /// <param name="textureTarget">GL_TEXTURE_1D, GL_TEXTURE_2D, etc..</param>
        public virtual void GenerateMipmmap(uint textureTarget)
        {
            glGenerateMipmap(textureTarget);
        }
    }
}
