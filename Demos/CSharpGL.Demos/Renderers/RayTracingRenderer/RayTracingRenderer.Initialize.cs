using System;
using System.IO;

namespace CSharpGL.Demos
{
    partial class RayTracingRenderer
    {
        private Texture texture;

        protected override void DoInitialize()
        {
            base.Initialize();

            var texture = new Texture(TextureTarget.Texture2D,
                new NullImageFiller(WIDTH, HEIGHT, OpenGL.GL_RGBA8, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE),
                new SamplerParameters(
                    TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                    TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();
            this.texture = texture;
        }

    }
}