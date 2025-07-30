
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    partial class glut {

        public static unsafe void WireCube(GLfloat size) {
            var gl = GL.Current; if (gl == null) { return; }

            GLfloat halfSize = size * 0.5f;

            float half = size / 2.0f;

            gl.glBegin(GL.GL_LINES);

            // 前面四条边
            gl.glVertex3f(-half, -half, half); gl.glVertex3f(half, -half, half);
            gl.glVertex3f(half, -half, half); gl.glVertex3f(half, half, half);
            gl.glVertex3f(half, half, half); gl.glVertex3f(-half, half, half);
            gl.glVertex3f(-half, half, half); gl.glVertex3f(-half, -half, half);

            // 后面四条边
            gl.glVertex3f(-half, -half, -half); gl.glVertex3f(half, -half, -half);
            gl.glVertex3f(half, -half, -half); gl.glVertex3f(half, half, -half);
            gl.glVertex3f(half, half, -half); gl.glVertex3f(-half, half, -half);
            gl.glVertex3f(-half, half, -half); gl.glVertex3f(-half, -half, -half);

            // 连接前后的四条边
            gl.glVertex3f(-half, -half, -half); gl.glVertex3f(-half, -half, half);
            gl.glVertex3f(half, -half, -half); gl.glVertex3f(half, -half, half);
            gl.glVertex3f(half, half, -half); gl.glVertex3f(half, half, half);
            gl.glVertex3f(-half, half, -half); gl.glVertex3f(-half, half, half);

            gl.glEnd();
        }
    }
}