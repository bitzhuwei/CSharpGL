using System;

namespace CSharpGL
{
    /// <summary>
    /// Quaternion
    /// </summary>
    public struct Quaternion
    {
        /// <summary>
        ///
        /// </summary>
        public float x;

        /// <summary>
        ///
        /// </summary>
        public float y;

        /// <summary>
        ///
        /// </summary>
        public float z;

        /// <summary>
        ///
        /// </summary>
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
        /// Transform this quaternion to equivalent matrix.
        /// </summary>
        /// <returns></returns>
        public mat3 ToRotationMatrix()
        {
            vec3 col0 = new vec3(
                w * w + x * x - y * y - z * z,
                2 * x * y - 2 * w * z,
                2 * x * z + 2 * w * y);
            vec3 col1 = new vec3(
                2 * x * y + 2 * w * z,
                w * w + y * y - x * x - z * z,
                2 * y * z - 2 * w * x);
            vec3 col2 = new vec3(
                2 * x * z - 2 * w * y,
                2 * y * z + 2 * w * x,
                w * w + z * z - x * x - y * y);

            return new mat3(col0, col1, col2);
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