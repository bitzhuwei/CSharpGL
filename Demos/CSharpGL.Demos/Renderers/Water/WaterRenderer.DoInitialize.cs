using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {
        private Texture cubeMap;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.waterTextureRenderer.Initialize();
            this.backgroundRenderer.Initialize();

            this.cubeMap = GetCubeMapTexture();

            this.SetUniform("u_waterPlaneLength", (float)this.waterPlaneLength);
            this.SetUniform("u_cubemap", this.cubeMap.ToSamplerValue());
            this.backgroundRenderer.SetUniform("u_cubemap", this.cubeMap.ToSamplerValue());
            this.SetUniform("u_waterTexture", this.waterTextureRenderer.MirrorTexture.ToSamplerValue());

            OpenGL.Enable(OpenGL.GL_CULL_FACE);
        }

        private Texture GetCubeMapTexture()
        {
            var cubeMapImages = new CubemapImages(
               new Bitmap(@"Resources\data\water_pos_x.png"),
               new Bitmap(@"Resources\data\water_neg_x.png"),
               new Bitmap(@"Resources\data\water_pos_y.png"),
               new Bitmap(@"Resources\data\water_neg_y.png"),
               new Bitmap(@"Resources\data\water_pos_z.png"),
               new Bitmap(@"Resources\data\water_neg_z.png"));
            var cubeMapFiller = new CubemapImageFiller(cubeMapImages, 0, OpenGL.GL_RGBA, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE);
            var cubeMap = new Texture(TextureTarget.TextureCubeMap, cubeMapFiller,
                new SamplerParameters(
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureFilter.Linear,
                    TextureFilter.Linear));
            cubeMap.ActiveTexture = OpenGL.GL_TEXTURE0;
            cubeMap.Initialize();

            cubeMapImages.Dispose();
            return cubeMap;
        }
    }
}