namespace CSharpGL
{
    /// <summary>
    /// build texture's content.
    /// </summary>
    public abstract class ImageFiller
    {
        /// <summary>
        /// build texture's content.
        /// </summary>
        /// <param name="target"></param>
        public abstract void Fill(BindTextureTarget target);
    }
}