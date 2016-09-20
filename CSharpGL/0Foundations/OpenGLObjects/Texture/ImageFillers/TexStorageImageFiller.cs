namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class TexStorageImageFiller : ImageFiller
    {
        private int levels;
        private uint internalFormat;
        private int width;
        private int height;

        /// <summary>
        ///
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public TexStorageImageFiller(int levels, uint internalFormat, int width, int height)
        {
            // TODO: Complete member initialization
            this.levels = levels;
            this.internalFormat = internalFormat;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        public override void Fill(TextureTarget target)
        {
            switch (target)
            {
                case TextureTarget.Unknown:
                    break;

                case TextureTarget.Texture1D:
                    break;

                case TextureTarget.Texture2D:
                    OpenGL.TexStorage2D(TexStorage2DTarget.Texture2D, levels, internalFormat, width, height);
                    break;

                case TextureTarget.Texture3D:
                    break;

                case TextureTarget.TextureCubeMap:
                    break;

                case TextureTarget.TextureBuffer:
                    break;

                default:
                    break;
            }
        }
    }
}