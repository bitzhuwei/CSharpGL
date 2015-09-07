using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common
{
    public static class Vec3Helper
    {
        static Random random = new Random();
        public static vec3 GetRandomVec3(float minmag = 0.0f, float maxmag = 1.0f)
        {
            var distance = maxmag - minmag;
            vec3 result = new vec3(
                (float)(random.NextDouble() * distance + minmag),
                (float)(random.NextDouble() * distance + minmag),
                (float)(random.NextDouble() * distance + minmag)
                );
            return result;
        }

    }
}
