using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Quaternion
    /// </summary>
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }

        /// <summary>
        /// Quaternion from a rotation angle and axis.
        /// </summary>
        /// <param name="degreeAngle"></param>
        /// <param name="axis"></param>
        public Quaternion(float degreeAngle, vec3 axis)
        {
            vec3 normalized = axis.normalize();
            float radian = (float)(degreeAngle * Math.PI / 180.0f);
            float halfRadian = radian / 2.0f;
            this.w = (float)Math.Cos(halfRadian);
            float sin = (float)Math.Sin(halfRadian);
            this.x = sin * normalized.x;
            this.y = sin * normalized.y;
            this.z = sin * normalized.z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}°, <{1}, {2}, {3}>", w * 180.0f / Math.PI, x, y, z);
        }
    }
}
