namespace CSharpGL
{
    /// <summary>
    /// Turn on before rendering something and turn off after rendering.
    /// </summary>
    public interface IGroupSwitches
    {
        /// <summary>
        ///
        /// </summary>
        GLSwitchList SwitchList { get; }
    }
}