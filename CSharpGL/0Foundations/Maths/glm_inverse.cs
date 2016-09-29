namespace CSharpGL
{
    public static partial class glm
    {

        /// <summary>
        /// Gets the transposed matrix.
        /// <para>获取转置矩阵。</para>
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2 transpose(mat2 m)
        {
            vec2 col0 = m.col0;
            vec2 col1 = m.col1;
            return new mat2(
                new vec2(col0.x, col1.x),
                new vec2(col0.y, col1.y)
                );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2 inverse(mat2 m)
        {
            float OneOverDeterminant = (1f) / (
                +m[0][0] * m[1][1]
                - m[1][0] * m[0][1]);

            mat2 Inverse = new mat2(
                +m[1][1] * OneOverDeterminant,
                -m[0][1] * OneOverDeterminant,
                -m[1][0] * OneOverDeterminant,
                +m[0][0] * OneOverDeterminant);

            return Inverse;
        }

        /// <summary>
        /// Gets the transposed matrix.
        /// <para>获取转置矩阵。</para>
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3 transpose(mat3 m)
        {
            vec3 col0 = m.col0;
            vec3 col1 = m.col1;
            vec3 col2 = m.col2;
            return new mat3(
                new vec3(col0.x, col1.x, col2.x),
                new vec3(col0.y, col1.y, col2.y),
                new vec3(col0.z, col1.z, col2.z)
                );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3 inverse(mat3 m)
        {
            float OneOverDeterminant = (1f) / (
                +m[0][0] * (m[1][1] * m[2][2] - m[2][1] * m[1][2])
                - m[1][0] * (m[0][1] * m[2][2] - m[2][1] * m[0][2])
                + m[2][0] * (m[0][1] * m[1][2] - m[1][1] * m[0][2]));

            mat3 Inverse = new mat3(0);
            Inverse[0, 0] = +(m[1][1] * m[2][2] - m[2][1] * m[1][2]) * OneOverDeterminant;
            Inverse[1, 0] = -(m[1][0] * m[2][2] - m[2][0] * m[1][2]) * OneOverDeterminant;
            Inverse[2, 0] = +(m[1][0] * m[2][1] - m[2][0] * m[1][1]) * OneOverDeterminant;
            Inverse[0, 1] = -(m[0][1] * m[2][2] - m[2][1] * m[0][2]) * OneOverDeterminant;
            Inverse[1, 1] = +(m[0][0] * m[2][2] - m[2][0] * m[0][2]) * OneOverDeterminant;
            Inverse[2, 1] = -(m[0][0] * m[2][1] - m[2][0] * m[0][1]) * OneOverDeterminant;
            Inverse[0, 2] = +(m[0][1] * m[1][2] - m[1][1] * m[0][2]) * OneOverDeterminant;
            Inverse[1, 2] = -(m[0][0] * m[1][2] - m[1][0] * m[0][2]) * OneOverDeterminant;
            Inverse[2, 2] = +(m[0][0] * m[1][1] - m[1][0] * m[0][1]) * OneOverDeterminant;

            return Inverse;
        }

        /// <summary>
        /// Gets the transposed matrix.
        /// <para>获取转置矩阵。</para>
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4 transpose(mat4 m)
        {
            vec4 col0 = m.col0;
            vec4 col1 = m.col1;
            vec4 col2 = m.col2;
            vec4 col3 = m.col3;
            return new mat4(
                new vec4(col0.x, col1.x, col2.x, col3.x),
                new vec4(col0.y, col1.y, col2.y, col3.y),
                new vec4(col0.z, col1.z, col2.z, col3.z),
                new vec4(col0.w, col1.w, col2.w, col3.w)
                );
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// <para>获取逆矩阵。</para>
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4 inverse(mat4 m)
        {
            float Coef00 = m[2][2] * m[3][3] - m[3][2] * m[2][3];
            float Coef02 = m[1][2] * m[3][3] - m[3][2] * m[1][3];
            float Coef03 = m[1][2] * m[2][3] - m[2][2] * m[1][3];

            float Coef04 = m[2][1] * m[3][3] - m[3][1] * m[2][3];
            float Coef06 = m[1][1] * m[3][3] - m[3][1] * m[1][3];
            float Coef07 = m[1][1] * m[2][3] - m[2][1] * m[1][3];

            float Coef08 = m[2][1] * m[3][2] - m[3][1] * m[2][2];
            float Coef10 = m[1][1] * m[3][2] - m[3][1] * m[1][2];
            float Coef11 = m[1][1] * m[2][2] - m[2][1] * m[1][2];

            float Coef12 = m[2][0] * m[3][3] - m[3][0] * m[2][3];
            float Coef14 = m[1][0] * m[3][3] - m[3][0] * m[1][3];
            float Coef15 = m[1][0] * m[2][3] - m[2][0] * m[1][3];

            float Coef16 = m[2][0] * m[3][2] - m[3][0] * m[2][2];
            float Coef18 = m[1][0] * m[3][2] - m[3][0] * m[1][2];
            float Coef19 = m[1][0] * m[2][2] - m[2][0] * m[1][2];

            float Coef20 = m[2][0] * m[3][1] - m[3][0] * m[2][1];
            float Coef22 = m[1][0] * m[3][1] - m[3][0] * m[1][1];
            float Coef23 = m[1][0] * m[2][1] - m[2][0] * m[1][1];

            vec4 Fac0 = new vec4(Coef00, Coef00, Coef02, Coef03);
            vec4 Fac1 = new vec4(Coef04, Coef04, Coef06, Coef07);
            vec4 Fac2 = new vec4(Coef08, Coef08, Coef10, Coef11);
            vec4 Fac3 = new vec4(Coef12, Coef12, Coef14, Coef15);
            vec4 Fac4 = new vec4(Coef16, Coef16, Coef18, Coef19);
            vec4 Fac5 = new vec4(Coef20, Coef20, Coef22, Coef23);

            vec4 Vec0 = new vec4(m[1][0], m[0][0], m[0][0], m[0][0]);
            vec4 Vec1 = new vec4(m[1][1], m[0][1], m[0][1], m[0][1]);
            vec4 Vec2 = new vec4(m[1][2], m[0][2], m[0][2], m[0][2]);
            vec4 Vec3 = new vec4(m[1][3], m[0][3], m[0][3], m[0][3]);

            vec4 Inv0 = new vec4(Vec1 * Fac0 - Vec2 * Fac1 + Vec3 * Fac2);
            vec4 Inv1 = new vec4(Vec0 * Fac0 - Vec2 * Fac3 + Vec3 * Fac4);
            vec4 Inv2 = new vec4(Vec0 * Fac1 - Vec1 * Fac3 + Vec3 * Fac5);
            vec4 Inv3 = new vec4(Vec0 * Fac2 - Vec1 * Fac4 + Vec2 * Fac5);

            vec4 SignA = new vec4(+1, -1, +1, -1);
            vec4 SignB = new vec4(-1, +1, -1, +1);
            mat4 Inverse = new mat4(Inv0 * SignA, Inv1 * SignB, Inv2 * SignA, Inv3 * SignB);

            vec4 Row0 = new vec4(Inverse[0][0], Inverse[1][0], Inverse[2][0], Inverse[3][0]);

            vec4 Dot0 = new vec4(m[0] * Row0);
            float Dot1 = (Dot0.x + Dot0.y) + (Dot0.z + Dot0.w);

            float OneOverDeterminant = (1f) / Dot1;

            return Inverse * OneOverDeterminant;
        }
    }
}