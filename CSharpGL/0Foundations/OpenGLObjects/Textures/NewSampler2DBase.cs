using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL._0Foundations.OpenGLObjects.Textures
{
    public abstract class NewSampler2DBase
    {
        public NewSampler2DBase(TextureWrapping wrapping, TextureFiltering textureFiltering, MipmapFiltering mipmapFiltering)
        {
            this.Wrapping = wrapping;
            this.TextureFilter = textureFiltering;
            this.MipmapFilter = mipmapFiltering;
        }

        public abstract void Setup();

        public TextureWrapping Wrapping { get; private set; }

        public TextureFiltering TextureFilter { get; private set; }

        public MipmapFiltering MipmapFilter { get; private set; }
    }
}
