using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PolygonOffsetPointSwitch : PolygonOffsetSwitch
    {

        /// <summary>
        /// 
        /// </summary>
        public PolygonOffsetPointSwitch()
            : base(PolygonOffset.Point, true)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetPointSwitch(bool pullNear)
            : base(PolygonOffset.Point, pullNear)
        { }

    }

}
