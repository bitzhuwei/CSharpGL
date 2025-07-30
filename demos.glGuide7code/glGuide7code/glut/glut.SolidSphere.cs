
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    partial class glut {
        //public static unsafe void SolidSphere(float radius, int slices, int stacks) {
        //    var gl = GL.Current; if (gl == null) { return; }

        //    float deltaTheta = (float)Math.PI / stacks;    // 纬度增量
        //    float deltaPhi = 2.0f * (float)Math.PI / slices; // 经度增量

        //    gl.glBegin(GL.GL_TRIANGLES);
        //    for (int i = 0; i <= stacks; ++i) {
        //        float theta = i * deltaTheta;  // 当前纬度
        //        float r = radius * (float)Math.Sin(theta); // 当前纬度的半径
        //        float y = radius * (float)Math.Cos(theta); // Z 轴高度

        //        for (int j = 0; j <= slices; ++j) {
        //            float phi = j * deltaPhi;  // 当前经度
        //            float x = r * (float)Math.Cos(phi);
        //            float z = r * (float)Math.Sin(phi);

        //            // 计算顶点坐标
        //            gl.glVertex3f(x, y, z);
        //        }
        //    }
        //    gl.glEnd();
        //}
        // 绘制实心球体（替代 glutSolidSphere）
        public static unsafe void SolidSphere(float radius, int slices, int stacks) {
            var gl = GL.Current; if (gl == null) { return; }
            float phi, theta;       // 角度参数
            float x, y, z;          // 顶点坐标
            float nx, ny, nz;       // 法线向量
            int i, j;               // 循环计数器

            // 沿 Z 轴方向的栈（Stack）循环
            for (i = 0; i < stacks; i++) {
                phi = (float)i / stacks * (float)Math.PI;                // 当前栈的起始角度
                float nextPhi = (float)(i + 1) / stacks * (float)Math.PI; // 下一栈的起始角度

                // 沿 XY 平面的切片（Slice）循环
                gl.glBegin(GL.GL_TRIANGLE_STRIP);
                for (j = 0; j <= slices; j++) {
                    theta = (float)j / slices * 2.0f * (float)Math.PI;   // 当前切片的角度

                    // 计算当前栈的顶点
                    x = (float)Math.Cos(theta) * (float)Math.Sin(phi);
                    y = (float)Math.Sin(theta) * (float)Math.Sin(phi);
                    z = (float)Math.Cos(phi);
                    nx = x; ny = y; nz = z;  // 法线与顶点方向相同
                    gl.glNormal3f(nx, ny, nz);
                    gl.glVertex3f(radius * x, radius * y, radius * z);

                    // 计算下一栈的顶点
                    x = (float)Math.Cos(theta) * (float)Math.Sin(nextPhi);
                    y = (float)Math.Sin(theta) * (float)Math.Sin(nextPhi);
                    z = (float)Math.Cos(nextPhi);
                    nx = x; ny = y; nz = z;
                    gl.glNormal3f(nx, ny, nz);
                    gl.glVertex3f(radius * x, radius * y, radius * z);
                }
                gl.glEnd();
            }
        }
    }
}