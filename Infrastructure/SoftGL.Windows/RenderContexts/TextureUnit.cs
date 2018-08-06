using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public struct TextureUnit
    {
        public uint texture1D;
        public uint texture2D;
        public uint texture2DMultisample;
        public uint texture2DArray;
        public uint texture3D;
        public uint texture2DMultisampleArray;
        public uint textureCubeMap;
        public uint textureBuffer;
        public uint textureRectangle;
    }

    public partial class SoftGLRenderContext
    {
        private const int GL_MAX_TEXTURE_IMAGE_UNITS = 8;
        private TextureUnit[] textureUnits = new TextureUnit[GL_MAX_TEXTURE_IMAGE_UNITS];
        private uint currentTextureUnitIndex = 0;

        public void ActiveTexture(uint textureUnit)
        {
            if (textureUnit < GL.GL_TEXTURE0)
            {
                this.SetLastError(ErrorCode.InvalidEnum);
                return;
            }

            if (GL.GL_TEXTURE0 + GL_MAX_TEXTURE_IMAGE_UNITS <= textureUnit)
            {
                this.SetLastError(ErrorCode.InvalidEnum);
                return;
            }

            this.currentTextureUnitIndex = textureUnit - GL.GL_TEXTURE0;
        }

        public void BindTexture(TextureTarget target, uint textureId)
        {
            TextureUnit currentUnit = this.textureUnits[this.currentTextureUnitIndex];
            switch (target)
            {
                case TextureTarget.Texture1D:
                    currentUnit.texture1D = textureId;
                    break;
                case TextureTarget.Texture2D:
                    currentUnit.texture2D = textureId;
                    break;
                case TextureTarget.Texture2DMultisample:
                    currentUnit.texture2DMultisample = textureId;
                    break;
                case TextureTarget.Texture2DArray:
                    currentUnit.texture2DArray = textureId;
                    break;
                case TextureTarget.Texture3D:
                    currentUnit.texture3D = textureId;
                    break;
                case TextureTarget.Texture2DMultisampleArray:
                    currentUnit.texture2DMultisampleArray = textureId;
                    break;
                case TextureTarget.TextureCubeMap:
                    currentUnit.textureCubeMap = textureId;
                    break;
                case TextureTarget.TextureBuffer:
                    currentUnit.textureBuffer = textureId;
                    break;
                case TextureTarget.TextureRectangle:
                    currentUnit.textureRectangle = textureId;
                    break;
                default:
                    break;
            }
        }
    }
}
