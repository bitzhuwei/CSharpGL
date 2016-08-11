using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL._0Foundations.OpenGLObjects.Textures
{
    class NewSampler2D : NewSampler2DBase
    {
        public uint Id { get; private set; }

        public NewSampler2D(TextureWrapping wrapping, TextureFiltering textureFiltering, MipmapFiltering mipmapFiltering)
            : base(wrapping, textureFiltering, mipmapFiltering)
        {

        }

        public override void Setup()
        {
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)this.Wrapping);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)this.Wrapping);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)this.TextureFilter);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)this.TextureFilter);

            throw new NotImplementedException();
        }
    }
}
