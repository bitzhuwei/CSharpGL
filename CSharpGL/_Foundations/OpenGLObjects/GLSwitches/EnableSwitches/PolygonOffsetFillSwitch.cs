using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
    /// </summary>
    public class PolygonOffsetFillSwitch : PolygonOffsetSwitch
    {

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        public PolygonOffsetFillSwitch()
            : base(PolygonOffset.Fill, true)
        { }

        /// <summary>
        /// http://www.cnblogs.com/bitzhuwei/p/polygon-offset-for-stitching-andz-fighting.html
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetFillSwitch(bool pullNear)
            : base(PolygonOffset.Fill, pullNear)
        { }

    }

}
