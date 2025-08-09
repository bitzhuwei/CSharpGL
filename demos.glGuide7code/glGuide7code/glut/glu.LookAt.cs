
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {

        // 手动实现 gluLookAt 的功能
        public static unsafe void LookAt(GLfloat eyeX, GLfloat eyeY, GLfloat eyeZ,
            GLfloat centerX, GLfloat centerY, GLfloat centerZ,
            GLfloat upX, GLfloat upY, GLfloat upZ) {
            var gl = GL.Current; if (gl == null) { return; }

            // 计算视线方向（Z轴）
            GLfloat[] zAxis = {
                eyeX - centerX,
                eyeY - centerY,
                eyeZ - centerZ
            };

            // 归一化 Z 轴
            GLfloat lenZ = (float)Math.Sqrt(zAxis[0] * zAxis[0] + zAxis[1] * zAxis[1] + zAxis[2] * zAxis[2]);
            zAxis[0] /= lenZ;
            zAxis[1] /= lenZ;
            zAxis[2] /= lenZ;

            // 计算右方向（X轴） = 上方向 × Z轴
            GLfloat[] xAxis = {
                upY * zAxis[2] - upZ * zAxis[1],
                upZ * zAxis[0] - upX * zAxis[2],
                upX * zAxis[1] - upY * zAxis[0]
            };

            // 归一化 X 轴
            GLfloat lenX = (float)Math.Sqrt(xAxis[0] * xAxis[0] + xAxis[1] * xAxis[1] + xAxis[2] * xAxis[2]);
            xAxis[0] /= lenX;
            xAxis[1] /= lenX;
            xAxis[2] /= lenX;

            // 计算新的上方向（Y轴） = Z轴 × X轴
            GLfloat[] yAxis = {
                zAxis[1] * xAxis[2] - zAxis[2] * xAxis[1],
                zAxis[2] * xAxis[0] - zAxis[0] * xAxis[2],
                zAxis[0] * xAxis[1] - zAxis[1] * xAxis[0]
            };

            // 构建视图矩阵（列主序）
            GLfloat[] matrix = {
                xAxis[0], yAxis[0], zAxis[0], 0.0f,
                xAxis[1], yAxis[1], zAxis[1], 0.0f,
                xAxis[2], yAxis[2], zAxis[2], 0.0f,
                0.0f,     0.0f,     0.0f,     1.0f
            };

            // 应用旋转矩阵
            var array = matrix.ToArray();
            fixed (GLfloat* p = array) {
                gl.glMultMatrixf(p);
            }
            // 应用平移（相机位置的逆变换）
            gl.glTranslatef(-eyeX, -eyeY, -eyeZ);
        }
    }
}