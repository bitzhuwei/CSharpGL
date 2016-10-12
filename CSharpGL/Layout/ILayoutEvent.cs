namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public interface ILayoutEvent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool DoBeforeLayout();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool DoAfterLayout();
    }
}