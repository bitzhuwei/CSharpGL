namespace CSharpGL
{
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public class PolygonOffsetFillState : PolygonOffsetState
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetFillState()
            : base(PolygonOffset.Fill, true)
        { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetFillState(bool pullNear)
            : base(PolygonOffset.Fill, pullNear)
        { }
    }
}