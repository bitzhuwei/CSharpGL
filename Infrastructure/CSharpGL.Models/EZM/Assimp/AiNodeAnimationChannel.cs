using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AiNodeAnimationChannel
    {
        public VectorKey[] PositionKeys { get; set; }

        public QuaternionKey[] QuaternionKeys { get; set; }

        public VectorKey[] ScalingKeys { get; set; }
    }
}
