using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterInnerRenderer
    {
        private Texture cubeMap;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.cubeMap = GetCubeMapTexture();
        }

        private Texture GetCubeMapTexture()
        {
            var cubeMapImages = new CubeMapImages(
               new Bitmap(@"Resources\data\water_pos_x.tga"),
               new Bitmap(@"Resources\data\water_neg_x.tga"),
               new Bitmap(@"Resources\data\water_pos_y.tga"),
               new Bitmap(@"Resources\data\water_neg_y.tga"),
               new Bitmap(@"Resources\data\water_pos_z.tga"),
               new Bitmap(@"Resources\data\water_neg_z.tga"));
            var cubeMapFiller = new CubeMapImageFiller(cubeMapImages, 0, OpenGL.GL_RGBA, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE);
            var cubeMap = new Texture(TextureTarget.TextureCubeMap, cubeMapFiller,
                new SamplerParameters(
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureWrapping.ClampToEdge,
                    TextureFilter.Linear,
                    TextureFilter.Linear));
            cubeMap.Initialize();
            cubeMapImages.Dispose();
            return cubeMap;
        }
    }
}