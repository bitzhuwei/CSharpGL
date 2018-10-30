using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class VectorKey
    {
        public readonly double time;
        public readonly vec3 value;

        public VectorKey(double time, vec3 value)
        {
            this.time = time;
            this.value = value;
        }
    }
}
