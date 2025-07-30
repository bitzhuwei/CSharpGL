
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glut {
        public static void WireSphere(float radius, int slices, int stacks) {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glBegin(GL.GL_LINE_STRIP);
            // 生成顶点数据
            for (int i = 0; i <= stacks; ++i) {
                var theta = i * Math.PI / stacks;  // 纬度角
                for (int j = 0; j <= slices; ++j) {
                    var phi = j * 2 * Math.PI / slices;  // 经度角
                    var x = radius * Math.Sin(theta) * Math.Cos(phi);
                    var y = radius * Math.Sin(theta) * Math.Sin(phi);
                    var z = radius * Math.Cos(theta);
                    //gl.glVertex3f(x, y, z);
                    gl.glVertex3d(x, y, z);
                }
            }
            gl.glEnd();
        }





    }
}