using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLM
{
    public class EulerAngle
    {
        public float Heading { get; set; }
        public float Pitch { get; set; }
        public float Bank { get; set; }

        public mat4 ToMat4()
        {
            float cosH = (float)Math.Cos(Heading);
            float sinH = (float)Math.Sin(Heading);
            float cosP = (float)Math.Cos(Pitch);
            float sinP = (float)Math.Sin(Pitch);
            float cosB = (float)Math.Cos(Bank);
            float sinB = (float)Math.Sin(Bank);

            mat4 result = new mat4(
                new vec4(cosH * cosB + sinH * sinP * sinB, sinB * cosP, -sinH * cosB + cosH * sinP * sinB, 0),
                new vec4(-cosH * sinB + sinH * sinP * cosB, cosB * cosP, sinB * sinH + cosH * sinP * cosB, 0),
                new vec4(sinH * cosP, -sinP, cosH * cosP, 0),
                new vec4(0, 0, 0, 1));

            return result;
        }
    }
}
