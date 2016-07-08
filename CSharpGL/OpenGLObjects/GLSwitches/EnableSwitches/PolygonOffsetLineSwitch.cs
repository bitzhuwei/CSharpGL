using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    /// <summary>
    /// 
    /// </summary>
    public class PolygonOffsetLineSwitch : PolygonOffsetSwitch
    {

        /// <summary>
        /// 
        /// </summary>
        public PolygonOffsetLineSwitch()
            : base(PolygonOffset.Line, true)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pullNear"></param>
        public PolygonOffsetLineSwitch(bool pullNear)
            : base(PolygonOffset.Line, pullNear)
        { }

    }

}
