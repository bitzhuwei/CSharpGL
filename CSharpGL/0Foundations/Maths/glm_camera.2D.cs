using System;

namespace CSharpGL
{
    // ReSharper disable InconsistentNaming
    public static partial class glm
    {
        /// Builds a rotation 3 * 3 matrix created from an angle.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="angleDegree">ANgle in Degree.</param>
        /// <returns></returns>
        public static mat3 rotate(mat3 m, float angleDegree)
        {
            float c = (float)Math.Cos(angleDegree * Math.PI / 180.0);
            float s = (float)Math.Sin(angleDegree * Math.PI / 180.0);

            mat3 rotate = mat3.identity();
            rotate.col0 = new vec2(c, s);
            rotate.col1 = new vec2(-s, c);

            mat3 result = rotate * m;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="angleDegree">ANgle in Degree.</param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static mat3 rotate(float angleDegree)
        {
            return rotate(mat3.identity(), angleDegree);
        }

        /// <summary>
        /// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to scale by.</param>
        /// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
        public static mat3 scale(mat3 m, vec2 v)
        {
            mat3 result = m;
            result.col0 = m.col0 * v.x;
            result.col1 = m.col1 * v.y;
            result.col2 = m.col2;

            return result;
        }

        /// <summary>
        /// Applies a translation transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to translate by.</param>
        /// <returns><paramref name="m"/> translated by <paramref name="v"/>.</returns>
        public static mat3 translate(mat3 m, vec2 v)
        {
            mat3 result = m;
            result.col2 = m.col0 * v.x + m.col1 * v.y + m.col2;
            return result;
        }

        /// <summary>
        /// Build a look at view matrix.
        /// transform object's coordinate from world's space to camera's space.
        /// </summary>
        /// <param name="eye">The eye.</param>
        /// <param name="center">The center.</param>
        /// <param name="up">Up.</param>
        /// <returns></returns>
        public static mat3 lookAt(vec2 eye, vec2 center, bool up)
        {
            // camera's back in world space coordinate system
            vec2 back = (eye - center).normalize();
            // camera's right in world space coordinate system
            vec2 right = up.cross(back).normalize();
            if (!up) { right = -right; }

            mat3 viewMatrix = new mat3(1);
            viewMatrix.col0.x = right.x;
            viewMatrix.col1.x = right.y;
            viewMatrix.col0.y = back.x;
            viewMatrix.col1.y = back.y;

            // Translation in world space coordinate system
            viewMatrix.col3.x = -eye.dot(right);
            viewMatrix.col3.y = -eye.dot(back);

            return viewMatrix;
        }
    }
}