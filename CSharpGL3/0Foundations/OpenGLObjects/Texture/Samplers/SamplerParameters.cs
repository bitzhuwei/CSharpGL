namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public class SamplerParameters
    {
        /// <summary>
        ///
        /// </summary>
        public TextureWrapping wrapS = TextureWrapping.ClampToEdge;

        /// <summary>
        ///
        /// </summary>
        public TextureWrapping wrapT = TextureWrapping.ClampToEdge;

        /// <summary>
        ///
        /// </summary>
        public TextureWrapping wrapR = TextureWrapping.ClampToEdge;

        /// <summary>
        ///
        /// </summary>
        public TextureFilter minFilter = TextureFilter.Linear;

        /// <summary>
        ///
        /// </summary>
        public TextureFilter magFilter = TextureFilter.Linear;

        /// <summary>
        ///
        /// </summary>
        public SamplerParameters() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="wrapS"></param>
        /// <param name="wrapT"></param>
        /// <param name="wrapR"></param>
        /// <param name="minFilter"></param>
        /// <param name="magFilter"></param>
        public SamplerParameters(
            TextureWrapping wrapS = TextureWrapping.ClampToEdge,
            TextureWrapping wrapT = TextureWrapping.ClampToEdge,
            TextureWrapping wrapR = TextureWrapping.ClampToEdge,
            TextureFilter minFilter = TextureFilter.Linear,
            TextureFilter magFilter = TextureFilter.Linear
            )
        {
            this.wrapS = wrapS;
            this.wrapT = wrapT;
            this.wrapR = wrapR;

            this.minFilter = minFilter;
            this.magFilter = magFilter;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("R:{0}, S:{1}, T:{2}, Min:{3}, Mag:{4}",
                this.wrapR, this.wrapS, this.wrapT,
                this.minFilter, this.magFilter);
        }
    }
}