using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PolygonOffsetFillSwitch : PolygonOffsetSwitch
    {

        /// <summary>
        /// 
        /// </summary>
        public PolygonOffsetFillSwitch()
            : base(PolygonOffset.Fill, true)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetFillSwitch(bool pullNear)
            : base(PolygonOffset.Fill, pullNear)
        { }

    }

}
