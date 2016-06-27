using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonOffsetPointSwitch : PolygonOffsetSwitch
    {

        public PolygonOffsetPointSwitch()
            : base(PolygonOffset.Point, true)
        { }

        public PolygonOffsetPointSwitch(bool pullNear)
            : base(PolygonOffset.Point, pullNear)
        { }

    }

}
