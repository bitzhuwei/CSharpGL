using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Maths
{
    public static class mat4Helper
    {
        /// <summary>
        /// 把连续16个float值按照列优先的顺序转换为mat4
        /// </summary>
        /// <param name="values"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static mat4 ToMat4(this float[] values, int startIndex = 0)
        {
            mat4 result;
            result = new mat4(
                values.ToVec4(startIndex + 0), values.ToVec4(startIndex + 4), values.ToVec4(startIndex + 8), values.ToVec4(startIndex + 12));

            return result;
        }

        /// <summary>
        /// 如果此矩阵是glm.ortho()的结果，那么返回glm.ortho()的各个参数值。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <returns></returns>
        public static bool TryParse(this mat4 matrix,
            out float left, out float right, out float bottom, out float top, out float zNear, out float zFar)
        {
            /*
                     var result = mat4.identity();
            result[0, 0] = (2f) / (right - left);
            result[1, 1] = (2f) / (top - bottom);
            result[2, 2] = -(2f) / (zFar - zNear);
            result[3, 0] = -(right + left) / (right - left);
            result[3, 1] = -(top + bottom) / (top - bottom);
            result[3, 2] = -(zFar + zNear) / (zFar - zNear);
            return result;
             */
            {
                float negHalfLeftRight = matrix[3, 0] / matrix[0, 0];
                float halfRightMinusLeft = 1.0f / matrix[0][0];
                left = -(halfRightMinusLeft + negHalfLeftRight);
                right = halfRightMinusLeft - negHalfLeftRight;
            }

            {
                float negHalfBottomTop = matrix[3, 1] / matrix[1, 1];
                float halfTopMinusBottom = 1.0f / matrix[1, 1];
                bottom = -(halfTopMinusBottom + negHalfBottomTop);
                top = halfTopMinusBottom - negHalfBottomTop;
            }

            {
                float halfNearFar = matrix[3, 2] / matrix[2, 2];
                float negHalfFarMinusNear = 1.0f / matrix[2, 2];
                zNear = negHalfFarMinusNear + halfNearFar;
                zFar = halfNearFar - negHalfFarMinusNear;
            }

            if (matrix[0, 0] == 0.0f || matrix[1, 1] == 0.0f || matrix[2, 2] == 0.0f)
            {
                return false;
            }

            if (matrix[1, 0] != 0.0f || matrix[2, 0] != 0.0f
                || matrix[0, 1] != 0.0f || matrix[2, 1] != 0.0f
                || matrix[0, 2] != 0.0f || matrix[1, 2] != 0.0f
                || matrix[0, 3] != 0.0f || matrix[1, 3] != 0.0f || matrix[2, 3] != 0.0f)
            {
                return false;
            }

            if (matrix[3, 3] != 1.0f)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 如果此矩阵是glm.perspective()的结果，那么返回glm.perspective()的各个参数值。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="fovy"></param>
        /// <param name="aspectRatio"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <returns></returns>
        public static bool TryParse(this mat4 matrix,
            out float fovy, out float aspectRatio, out float zNear, out float zFar)
        {
            /*
            var result = mat4.identity();
            float tangent = (float)Math.Tan(fovy / 2.0f);
            float height = zNear * tangent;
            float width = height * aspect;
            float l = -width, r = width, b = -height, t = height, n = zNear, f = zFar;
            result[0, 0] = 2 * n / (r - l);// = 2 * zNear / (2 * zNear * tangent * aspect)
            result[1, 1] = 2 * n / (t - b);// = 2 * zNear / (2 * zNear * tangent)
            result[2, 0] = (r + l) / (r - l);// = 0
            result[2, 1] = (t + b) / (t - b);// = 0
            result[2, 2] = -(f + n) / (f - n);
            result[2, 3] = -1;
            result[3, 2] = -(2 * f * n) / (f - n);
            result[3, 3] = 0;
             */
            float tanHalfFovy = 1.0f / matrix[1, 1];
            fovy = 2 * (float)(Math.Atan(tanHalfFovy));
            //aspectRatio = 1.0f / matrix[0, 0] / tanHalfFovy;
            aspectRatio = matrix[1, 1] / matrix[0, 0];
            zNear = matrix[3, 2] / (1 - matrix[2, 2]);
            zFar = matrix[3, 2] / (1 + matrix[2, 2]);

            if (matrix[0, 0] == 0.0f || matrix[1, 1] == 0.0f || matrix[2, 2] == 0.0f)
            {
                return false;
            }

            if (matrix[1, 0] != 0.0f || matrix[3, 0] != 0.0f
                || matrix[0, 1] != 0.0f || matrix[3, 1] != 0.0f
                || matrix[0, 2] != 0.0f || matrix[1, 2] != 0.0f
                || matrix[0, 3] != 0.0f || matrix[1, 3] != 0.0f || matrix[3, 3] != 0.0f)
            {
                return false;
            }

            if (matrix[3, 2] != -1.0f)
            {
                return false;
            }

            return true;
        }

    }
}
