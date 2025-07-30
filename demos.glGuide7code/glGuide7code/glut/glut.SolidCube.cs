
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    partial class glut {

        private static readonly GLfloat[] vertices = new GLfloat[8 * 3] {
                -1.0f, -1.0f, -1.0f,
                1.0f, -1.0f, -1.0f,
                1.0f,  1.0f, -1.0f,
                -1.0f,  1.0f, -1.0f,
                -1.0f, -1.0f,  1.0f,
                1.0f, -1.0f,  1.0f,
                1.0f,  1.0f,  1.0f,
                -1.0f,  1.0f,  1.0f
            };

        private static readonly GLushort[] SolidCubIndices = new GLushort[] {
                // 前面
                4,5,6, 4,6,7,
                // 后面
                0,1,2, 0,2,3,
                // 左面
                0,3,7, 0,7,4,
                // 右面
                1,5,6, 1,6,2,
                // 底面
                0,4,5, 0,5,1,
                // 顶面
                3,2,6, 3,6,7
            };
        public static unsafe void SolidCube(GLfloat size) {
            var gl = GL.Current; if (gl == null) { return; }

            GLfloat halfSize = size * 0.5f;

            gl.glBegin(GL.GL_TRIANGLES);
            for (int i = 0; i < 36; i++) {
                var index = SolidCubIndices[i];
                var x = vertices[index * 3 + 0] * halfSize;
                var y = vertices[index * 3 + 1] * halfSize;
                var z = vertices[index * 3 + 2] * halfSize;
                gl.glVertex3f(x, y, z);
            }
            gl.glEnd();
        }
    }
}