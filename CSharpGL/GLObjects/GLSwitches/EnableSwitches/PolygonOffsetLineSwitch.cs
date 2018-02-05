namespace CSharpGL
{
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public class PolygonOffsetLineState : PolygonOffsetState
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetLineState()
            : base(PolygonOffset.Line, true)
        { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetLineState(bool pullNear)
            : base(PolygonOffset.Line, pullNear)
        { }
    }
}