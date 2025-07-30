﻿namespace CSharpGL {
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public unsafe class PolygonOffsetFillSwitch : PolygonOffsetSwitch {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetFillSwitch()
            : base(PolygonOffset.Fill, true) { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetFillSwitch(bool pullNear)
            : base(PolygonOffset.Fill, pullNear) { }
    }
}