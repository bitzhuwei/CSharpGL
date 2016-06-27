using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonOffsetFillSwitch : PolygonOffsetSwitch
    {

        public PolygonOffsetFillSwitch()
            : base(PolygonOffset.Fill, true)
        { }

        public PolygonOffsetFillSwitch(bool pullNear)
            : base(PolygonOffset.Fill, pullNear)
        { }

    }

}
