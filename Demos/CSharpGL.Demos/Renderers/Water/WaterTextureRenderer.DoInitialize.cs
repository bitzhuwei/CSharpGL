using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterTextureRenderer
    {

        private Texture mirrorTexture;
        const int TEXTURE_SIZE = 1024;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(TEXTURE_SIZE, TEXTURE_SIZE, OpenGL.GL_RGB, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE),
                new SamplerParameters(
                    TextureWrapping.Repeat,
                    TextureWrapping.Repeat,
                    TextureWrapping.Repeat,
                    TextureFilter.Linear,
                    TextureFilter.Linear));
            texture.Initialize();
            this.mirrorTexture = texture;
        }
    }
}