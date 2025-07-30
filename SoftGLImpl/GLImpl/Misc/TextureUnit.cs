using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    struct TextureUnit {
        public GLTexture? texture1D;
        public GLTexture? texture2D;
        public GLTexture? texture3D;
        public GLTexture? texture1DArray;
        public GLTexture? texture2DArray;
        public GLTexture? textureRectangle;
        public GLTexture? textureCubeMap;
        public GLTexture? texture2DMultisample;
        public GLTexture? texture2DMultisampleArray;
        public GLTexture? textureBuffer;
        public GLTexture? textureCubeMapArray;
    }
}
