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
        private float w;

        /// <summary>
        ///
        /// </summary>
        private float x;

        /// <summary>
        ///
        /// </summary>
        private float y;

        /// <summary>
        ///
        /// </summary>
        private float z;

        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        internal Quaternion(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x; this.y = y; this.z = z;
        }

        /// <summary>
        /// Quaternion from a rotation angle and axis.
        /// </summary>
        /// <param name="degreeAngle"></param>
        /// <param name="axis"></param>
        public Quaternion(float degreeAngle, vec3 axis)
        {
            vec3 normalized = axis.normalize();
            double radian = degreeAngle * Math.PI / 180.0;
            double halfRadian = radian / 2.0;
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
                2 * (x * x + w * w) - 1,
                2 * x * y + 2 * w * z,
                2 * x * z - 2 * w * y);
            vec3 col1 = new vec3(
                2 * x * y - 2 * w * z,
                2 * (y * y + w * w) - 1,
                2 * y * z + 2 * w * x);
            vec3 col2 = new vec3(
                2 * x * z + 2 * w * y,
                2 * y * z - 2 * w * x,
                2 * (z * z + w * w) - 1);

            return new mat3(col0, col1, col2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="degreeAngle"></param>
        /// <param name="axis"></param>
        public void Parse(out float degreeAngle, out vec3 axis)
        {
            degreeAngle = (float)(Math.Acos(w) * 2 * 180.0 / Math.PI);
            axis = (new vec3(x, y, z)).normalize();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}°, <{1}, {2}, {3}>", Math.Acos(w) * 2 * 180.0f / Math.PI, x, y, z);
        }
    }
}