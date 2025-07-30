﻿namespace CSharpGL {
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public unsafe class PolygonOffsetLineSwitch : PolygonOffsetSwitch {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetLineSwitch()
            : base(PolygonOffset.Line, true) { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetLineSwitch(bool pullNear)
            : base(PolygonOffset.Line, pullNear) { }
    }
}