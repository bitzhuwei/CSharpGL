
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glut {
        public static void SolidCone(float base_, float height, GLint slices, GLint stacks) {
            var gl = GL.Current; if (gl == null) { return; }

            int i, j;
            GLfloat angle, x, y, nx, ny;

            // 绘制圆锥侧面
            gl.glBegin(GL.GL_TRIANGLE_STRIP);
            for (i = 0; i <= slices; i++) {
                angle = 2.0f * (float)Math.PI * (GLfloat)i / (GLfloat)slices;
                x = (float)Math.Cos(angle);
                y = (float)Math.Sin(angle);
                nx = x;
                ny = y;

                // 底面边缘点的法向量（垂直于底面）
                gl.glNormal3f(nx, ny, 0.0f);
                gl.glVertex3f(x * base_, y * base_, 0.0f);

                // 顶点的法向量（沿母线方向）
                gl.glNormal3f(nx, ny, base_ / height);
                gl.glVertex3f(0.0f, 0.0f, height);
            }
            gl.glEnd();

            // 绘制圆锥底面（圆形）
            gl.glBegin(GL.GL_TRIANGLE_FAN);
            gl.glNormal3f(0.0f, 0.0f, -1.0f);  // 底面法向量向下
            gl.glVertex3f(0.0f, 0.0f, 0.0f);   // 圆心

            for (i = 0; i <= slices; i++) {
                angle = 2.0f * (float)Math.PI * (GLfloat)i / (GLfloat)slices;
                x = (float)Math.Cos(angle);
                y = (float)Math.Sin(angle);
                gl.glVertex3f(x * base_, y * base_, 0.0f);
            }
            gl.glEnd();
        }




    }
}