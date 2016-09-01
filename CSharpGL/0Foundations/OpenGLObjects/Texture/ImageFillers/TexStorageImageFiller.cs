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
        public override void Fill(BindTextureTarget target)
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