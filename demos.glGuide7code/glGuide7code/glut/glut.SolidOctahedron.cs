
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    partial class glut {

        private static readonly GLfloat[] SolidOctahedronVertices = new GLfloat[6 * 3]  {
                 1.0f,  0.0f,  0.0f,
                -1.0f,  0.0f,  0.0f,
                 0.0f,  1.0f,  0.0f,
                 0.0f, -1.0f,  0.0f,
                 0.0f,  0.0f,  1.0f,
                 0.0f,  0.0f, -1.0f
            };

        private static readonly GLushort[] SolidOctahedronIndices = new GLushort[]  {
                // 前后面
                4,0,3,4,3,5,
                5,2,1,5,1,0,
                // 左右面
                0,1,3,0,3,2,
                2,4,0,2,0,1,
                // 顶底面
                3,1,4,3,4,2,
                1,5,4,1,4,0
            };

        public static unsafe void SolidOctahedron() {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glBegin(GL.GL_TRIANGLES);
            for (int i = 0; i < 24; i++) {
                var index = SolidOctahedronIndices[i];
                var x = SolidOctahedronVertices[index * 3 + 0];
                var y = SolidOctahedronVertices[index * 3 + 1];
                var z = SolidOctahedronVertices[index * 3 + 2];
                gl.glVertex3f(x, y, z);
            }
            gl.glEnd();
        }
    }
}