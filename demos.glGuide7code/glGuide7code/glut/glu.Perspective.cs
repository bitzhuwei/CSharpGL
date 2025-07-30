
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {

        /// <summary>
        /// 等效于 gluPerspective(fovy, aspect, zNear, zFar)
        /// </summary>
        /// <param name="gl"></param>
        /// <param name="fovy"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public static unsafe void Perspective(GLfloat fovy, GLfloat aspect, GLfloat zNear, GLfloat zFar) {
            var gl = GL.Current; if (gl == null) { return; }

            GLfloat f = 1.0f / (GLfloat)Math.Tan(fovy * 0.5f * Math.PI / 180.0f);
            GLfloat nf = 1.0f / (zNear - zFar);

            GLfloat[] matrix = {
                f / aspect, 0.0f,   0.0f,                     0.0f,
                0.0f,       f,      0.0f,                     0.0f,
                0.0f,       0.0f,   (zFar + zNear) * nf,     -1.0f,
                0.0f,       0.0f,   2.0f * zFar * zNear * nf, 0.0f
            };

            // 将矩阵应用到当前矩阵栈
            gl.glMultMatrixf(matrix);
        }
    }
}