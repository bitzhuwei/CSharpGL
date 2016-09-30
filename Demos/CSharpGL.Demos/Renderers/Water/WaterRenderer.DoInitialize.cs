using System.Drawing;

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
            this.SetUniform("u_cubemap", this.cubeMap);
            this.backgroundRenderer.SetUniform("u_cubemap", this.cubeMap);
            this.SetUniform("u_waterTexture", this.waterTextureRenderer.MirrorTexture);

            // display back faces only.
            this.cullfaceSwitch = new CullFaceSwitch(CullFaceMode.Back);
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
            var cubemapFiller = new CubemapImageFiller(cubeMapImages, 0, OpenGL.GL_RGBA, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE);
            var cubemapTexture = new Texture(TextureTarget.TextureCubeMap, cubemapFiller,
                new SamplerParameters(
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureFilter.Linear,
                    TextureFilter.Linear));
            cubemapTexture.Initialize();

            cubeMapImages.Dispose();
            return cubemapTexture;
        }
    }
}