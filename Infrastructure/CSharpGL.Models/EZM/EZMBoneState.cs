using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMBoneState
    {
        public EZMBoneState(vec3 position, vec4 orientation, vec3 scale)
        {
            this.Position = position;
            this.Orientation = orientation;
            this.Scale = scale;
        }

        public vec3 Position { get; private set; }

        public vec4 Orientation { get; private set; }

        public vec3 Scale { get; private set; }

        public override string ToString()
        {
            return string.Format("Orientation:{0} Pos:{1} Scale:{2}.", this.Orientation, this.Position, this.Scale);
        }
    }
}
