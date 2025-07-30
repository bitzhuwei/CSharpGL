using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class AiAnimation {
        public int TicksPerSecond { get; internal set; }

        public float DurationInTicks { get; internal set; }

        public AiNodeAnimationChannel[] NodeAnimationChannels { get; internal set; }

        public string Name { get; set; }
    }
}
