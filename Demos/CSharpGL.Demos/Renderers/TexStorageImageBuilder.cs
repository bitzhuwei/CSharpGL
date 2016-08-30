using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos.Renderers
{
    class TexStorageImageBuilder : ImageBuilder
    {
        private int levels;
        private uint internalFormat;
        private int width;
        private int height;

        public TexStorageImageBuilder(int levels, uint internalFormat, int width, int height)
        {
            // TODO: Complete member initialization
            this.levels = levels;
            this.internalFormat = internalFormat;
            this.width = width;
            this.height = height;
        }

        public override void Build(BindTextureTarget target)
        {
            switch (target)
            {
                case BindTextureTarget.Unknown:
                    break;
                case BindTextureTarget.Texture1D:
                    break;
                case BindTextureTarget.Texture2D:
                    OpenGL.TexStorage2D(TexStorage2DTarget.Texture2D, levels, internalFormat, width, height);
                    break;
                case BindTextureTarget.Texture3D:
                    break;
                case BindTextureTarget.TextureCubeMap:
                    break;
                case BindTextureTarget.TextureBuffer:
                    break;
                default:
                    break;
            }
        }
    }
}
