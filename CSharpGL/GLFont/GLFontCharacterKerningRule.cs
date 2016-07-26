namespace CSharpGL
{
	public enum GLFontCharacterKerningRule : byte
    {
        /// <summary>
        /// Ordinary kerning
        /// </summary>
        Normal,
        /// <summary>
        /// All kerning pairs involving this character will kern by 0. This will
        /// override both Normal and NotMoreThanHalf for any pair.
        /// </summary>
        Zero,
        /// <summary>
        /// Any kerning pairs involving this character will not kern
        /// by more than half the minimum width of the two characters 
        /// involved. This will override Normal for any pair.
        /// </summary>
        NotMoreThanHalf
    }
}
