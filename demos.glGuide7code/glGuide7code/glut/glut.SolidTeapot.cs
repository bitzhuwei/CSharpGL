
using CSharpGL;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glut {
        // 绘制球体的一部分（用于茶壶的壶身）
        public static void drawSpherePart(float radius, int slices, int stacks, float startPhi, float endPhi) {
            var gl = GL.Current; if (gl == null) { return; }

            //float phi, theta;
            //float x, y, z;
            //int i, j;

            for (var i = 0; i < stacks; i++) {
                var phi = startPhi + (float)i / stacks * (endPhi - startPhi);
                float nextPhi = startPhi + (float)(i + 1) / stacks * (endPhi - startPhi);

                gl.glBegin(GL.GL_TRIANGLE_STRIP);
                for (var j = 0; j <= slices; j++) {
                    var theta = (float)j / slices * 2.0f * (float)Math.PI;

                    // 计算当前栈的顶点
                    var x = (float)Math.Cos(theta) * (float)Math.Sin(phi);
                    var y = (float)Math.Cos(phi);
                    var z = (float)Math.Sin(theta) * (float)Math.Sin(phi);
                    gl.glNormal3f(x, y, z);
                    gl.glVertex3f(radius * x, radius * y, radius * z);

                    // 计算下一栈的顶点
                    x = (float)Math.Cos(theta) * (float)Math.Sin(nextPhi);
                    y = (float)Math.Cos(nextPhi);
                    z = (float)Math.Sin(theta) * (float)Math.Sin(nextPhi);
                    gl.glNormal3f(x, y, z);
                    gl.glVertex3f(radius * x, radius * y, radius * z);
                }
                gl.glEnd();
            }
        }

        // 绘制圆柱体（用于茶壶的壶嘴和把手）
        public static void drawCylinder(float radius, float height, int slices, bool topCap, bool bottomCap) {
            var gl = GL.Current; if (gl == null) { return; }
            float theta;
            float x, y, z;
            int i;

            // 侧面
            gl.glBegin(GL.GL_TRIANGLE_STRIP);
            for (i = 0; i <= slices; i++) {
                theta = (float)i / slices * 2.0f * (float)Math.PI;
                x = (float)Math.Cos(theta) * radius;
                z = (float)Math.Sin(theta) * radius;

                gl.glNormal3f(x, 0.0f, z);
                gl.glVertex3f(x, 0.0f, z);
                gl.glVertex3f(x, height, z);
            }
            gl.glEnd();

            // 顶部盖子
            if (topCap) {
                gl.glBegin(GL.GL_TRIANGLE_FAN);
                gl.glNormal3f(0.0f, 1.0f, 0.0f);
                gl.glVertex3f(0.0f, height, 0.0f);
                for (i = 0; i <= slices; i++) {
                    theta = (float)(slices - i) / slices * 2.0f * (float)Math.PI;
                    x = (float)Math.Cos(theta) * radius;
                    z = (float)Math.Sin(theta) * radius;
                    gl.glVertex3f(x, height, z);
                }
                gl.glEnd();
            }

            // 底部盖子
            if (bottomCap) {
                gl.glBegin(GL.GL_TRIANGLE_FAN);
                gl.glNormal3f(0.0f, -1.0f, 0.0f);
                gl.glVertex3f(0.0f, 0.0f, 0.0f);
                for (i = 0; i <= slices; i++) {
                    theta = (float)i / slices * 2.0f * (float)Math.PI;
                    x = (float)Math.Cos(theta) * radius;
                    z = (float)Math.Sin(theta) * radius;
                    gl.glVertex3f(x, 0.0f, z);
                }
                gl.glEnd();
            }
        }

        // 自定义茶壶函数（替代 gl.glutSolidTeapot）
        public static void SolidTeapot(float size) {
            var gl = GL.Current; if (gl == null) { return; }
            // 调整大小
            gl.glPushMatrix();
            gl.glScalef(size, size, size);

            // 壶身（球体的下半部分）
            gl.glPushMatrix();
            drawSpherePart(0.5f, 32, 16, 0.0f, (float)Math.PI / 2);
            gl.glPopMatrix();

            // 壶盖（球体的小部分）
            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.5f, 0.0f);
            drawSpherePart(0.35f, 32, 8, 0.0f, (float)Math.PI / 4);
            gl.glPopMatrix();

            // 壶嘴（圆柱体）
            gl.glPushMatrix();
            gl.glTranslatef(0.6f, 0.2f, 0.0f);
            gl.glRotatef(30.0f, 0.0f, 0.0f, 1.0f);
            drawCylinder(0.07f, 0.4f, 16, true, false);
            gl.glPopMatrix();

            // 把手（圆柱体）
            gl.glPushMatrix();
            gl.glTranslatef(-0.5f, 0.2f, 0.0f);
            gl.glRotatef(-30.0f, 0.0f, 0.0f, 1.0f);
            drawCylinder(0.07f, 0.5f, 16, false, false);
            gl.glPopMatrix();

            // 壶顶（圆锥体）
            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.7f, 0.0f);
            gl.glScalef(0.15f, 0.2f, 0.15f);
            drawCylinder(1.0f, 1.0f, 16, true, false);
            gl.glPopMatrix();

            gl.glPopMatrix();
        }




    }
}