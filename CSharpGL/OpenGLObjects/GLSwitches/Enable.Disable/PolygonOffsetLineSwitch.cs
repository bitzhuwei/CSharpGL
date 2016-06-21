using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonOffsetLineSwitch : PolygonOffsetSwitch
    {

        public PolygonOffsetLineSwitch()
            : base(PolygonOffset.Line, true)
        { }

        public PolygonOffsetLineSwitch(bool pullNear)
            : base(PolygonOffset.Line, pullNear)
        { }

    }

}
