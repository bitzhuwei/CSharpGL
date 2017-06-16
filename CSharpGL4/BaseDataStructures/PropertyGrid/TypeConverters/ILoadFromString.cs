namespace CSharpGL
{
    /// <summary>
    /// Load an instance from string.
    /// </summary>
    public interface ILoadFromString
    {
        /// <summary>
        /// Load values for this instance from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Load(string value);
    }
}