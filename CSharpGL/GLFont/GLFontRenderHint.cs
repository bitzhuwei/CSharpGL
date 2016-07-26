namespace CSharpGL
{
    public enum GLFontRenderHint : byte
    {
        /// <summary>
        /// Use AntiAliasGridFit when rendering the ttf character set to create the GLFont texture
        /// </summary>
        AntiAliasGridFit,
        /// <summary>
        /// Use AntiAlias when rendering the ttf character set to create the GLFont texture
        /// </summary>
        AntiAlias,
        /// <summary>
        /// Use ClearTypeGridFit if the font is smaller than 12, otherwise use AntiAlias
        /// </summary>
        SizeDependent,
        /// <summary>
        /// Use ClearTypeGridFit when rendering the ttf character set to create the GLFont texture
        /// </summary>
        ClearTypeGridFit,
        /// <summary>
        /// Use SystemDefault when rendering the ttf character set to create the GLFont texture
        /// </summary>
        SystemDefault
    }
}
