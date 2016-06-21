using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid.helper
{
    public class vec3Helper
    {
        public static vec3 Minvec3(vec3 min, vec3 value)
        {
            if (min.x > value.x)
                min.x = value.x;
            if (min.y > value.y)
                min.y = value.y;
            if (min.z > value.z)
                min.z = value.z;
            return min;
        }

        public static vec3 Maxvec3(vec3 max, vec3 value)
        {
            if (max.x < value.x)
                max.x = value.x;
            if (max.y < value.y)
                max.y = value.y;
            if (max.z < value.z)
                max.z = value.z;
            return max;
        }

    }
}
