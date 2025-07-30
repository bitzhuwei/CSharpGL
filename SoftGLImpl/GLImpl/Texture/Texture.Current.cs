using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        private static void SetCurrentTexture(RenderContext context, GLenum/*BindTextureTarget*/ target, GLTexture? texture) {
            TextureUnit currentUnit = context.textureUnits[context.currentTextureUnitIndex];
            switch ((BindTextureTarget)target) {
            case BindTextureTarget.Texture1D: currentUnit.texture1D = texture; break;
            case BindTextureTarget.Texture2D: currentUnit.texture2D = texture; break;
            case BindTextureTarget.Texture3D: currentUnit.texture3D = texture; break;
            case BindTextureTarget.Texture1DArray: currentUnit.texture1DArray = texture; break;
            case BindTextureTarget.Texture2DArray: currentUnit.texture2DArray = texture; break;
            case BindTextureTarget.TextureRectangle: currentUnit.textureRectangle = texture; break;
            case BindTextureTarget.TextureCubeMap: currentUnit.textureCubeMap = texture; break;
            case BindTextureTarget.Texture2DMultisample: currentUnit.texture2DMultisample = texture; break;
            case BindTextureTarget.Texture2DMultisampleArray: currentUnit.texture2DMultisampleArray = texture; break;
            case BindTextureTarget.TextureBuffer: currentUnit.textureBuffer = texture; break;
            case BindTextureTarget.TextureCubeMapArray: currentUnit.textureCubeMapArray = texture; break;
            default: throw new NotImplementedException();
            }
        }

        private static GLTexture? GetCurrentTexture(RenderContext context, GLenum/*BindTextureTarget*/ target) {
            GLTexture? texture = null;
            TextureUnit currentUnit = context.textureUnits[context.currentTextureUnitIndex];
            switch ((BindTextureTarget)target) {
            case BindTextureTarget.Texture1D: texture = currentUnit.texture1D; break;
            case BindTextureTarget.Texture2D: texture = currentUnit.texture2D; break;
            case BindTextureTarget.Texture3D: texture = currentUnit.texture3D; break;
            case BindTextureTarget.Texture1DArray: texture = currentUnit.texture1DArray; break;
            case BindTextureTarget.Texture2DArray: texture = currentUnit.texture2DArray; break;
            case BindTextureTarget.TextureRectangle: texture = currentUnit.textureRectangle; break;
            case BindTextureTarget.TextureCubeMap: texture = currentUnit.textureCubeMap; break;
            case BindTextureTarget.Texture2DMultisample: texture = currentUnit.texture2DMultisample; break;
            case BindTextureTarget.Texture2DMultisampleArray: texture = currentUnit.texture2DMultisampleArray; break;
            case BindTextureTarget.TextureBuffer: texture = currentUnit.textureBuffer; break;
            case BindTextureTarget.TextureCubeMapArray: texture = currentUnit.textureCubeMapArray; break;
            default: throw new NotImplementedException();
            }

            return texture;
        }
    }
}
