﻿namespace CSharpGL {
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public unsafe class PolygonOffsetPointSwitch : PolygonOffsetSwitch {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetPointSwitch()
            : base(PolygonOffset.Point, true) { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetPointSwitch(bool pullNear)
            : base(PolygonOffset.Point, pullNear) { }
    }
}