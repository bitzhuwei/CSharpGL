
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    partial class glut {
        public static unsafe void SolidTorus(float innerRadius, float outerRadius, int slices, int stacks) {
            var gl = GL.Current; if (gl == null) { return; }

            float deltaTheta = (float)(2.0f * Math.PI / slices);
            float deltaRadius = (outerRadius - innerRadius) / stacks;

            for (int i = 0; i < stacks; ++i) {
                float r0 = innerRadius + i * deltaRadius;
                float r1 = innerRadius + (i + 1) * deltaRadius;

                for (int j = 0; j < slices; ++j) {
                    float theta0 = j * deltaTheta;
                    float theta1 = (j + 1) * deltaTheta;

                    // 计算四个顶点
                    var v0 = new vec3(r0 * (float)Math.Cos(theta0), r0 * (float)Math.Sin(theta0), 0.0f);
                    var v1 = new vec3(r0 * (float)Math.Cos(theta1), r0 * (float)Math.Sin(theta1), 0.0f);
                    var v2 = new vec3(r1 * (float)Math.Cos(theta0), r1 * (float)Math.Sin(theta0), 0.0f);
                    var v3 = new vec3(r1 * (float)Math.Cos(theta1), r1 * (float)Math.Sin(theta1), 0.0f);

                    // 绘制两个三角形（前向面）
                    gl.glBegin(GL.GL_TRIANGLES);
                    gl.glColor3f(1.0f, 0.0f, 0.0f); gl.glVertex3f(v0.x, v0.y, v0.z);
                    gl.glColor3f(0.0f, 1.0f, 0.0f); gl.glVertex3f(v1.x, v1.y, v1.z);
                    gl.glColor3f(0.0f, 0.0f, 1.0f); gl.glVertex3f(v2.x, v2.y, v2.z);
                    gl.glEnd();

                    gl.glBegin(GL.GL_TRIANGLES);
                    gl.glColor3f(1.0f, 0.0f, 1.0f); gl.glVertex3f(v1.x, v1.y, v1.z);
                    gl.glColor3f(0.0f, 1.0f, 1.0f); gl.glVertex3f(v3.x, v3.y, v3.z);
                    gl.glColor3f(1.0f, 1.0f, 0.0f); gl.glVertex3f(v2.x, v2.y, v2.z);
                    gl.glEnd();
                }
            }
        }
    }
}