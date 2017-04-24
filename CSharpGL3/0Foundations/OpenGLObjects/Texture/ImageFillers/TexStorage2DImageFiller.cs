namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class TexStorage2DImageFiller : ImageFiller
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
        public TexStorage2DImageFiller(int levels, uint internalFormat, int width, int height)
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
        public override void Fill()
        {
            OpenGL.TexStorage2D(TexStorage2DTarget.Texture2D, levels, internalFormat, width, height);
        }
    }
}