
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {
        public static void PickMatrix(
            GLdouble x,      // 选择区域中心 x 坐标（窗口坐标系）
            GLdouble y,      // 选择区域中心 y 坐标（窗口坐标系）
            GLdouble width,  // 选择区域宽度（窗口坐标系）
            GLdouble height, // 选择区域高度（窗口坐标系）
            GLint* viewport // 当前视口参数（通过 glGetIntegerv 获取）
            ) {
            var gl = GL.Current; if (gl == null) { return; }

            var m = stackalloc GLdouble[16];
            GLdouble sx, sy, tx, ty;

            // 处理无效的选择区域
            if (width <= 0.0 || height <= 0.0) return;

            // 计算缩放因子
            sx = viewport[2] / width;
            sy = viewport[3] / height;

            // 计算平移因子
            tx = (viewport[2] + 2.0 * (viewport[0] - x)) / width;
            ty = (viewport[3] + 2.0 * (viewport[1] - y)) / height;

            // 构建特殊的正交投影矩阵
            // 这个矩阵会将选择区域映射到一个很小的范围
            for (int i = 0; i < 16; i++) m[i] = 0.0;
            m[0] = sx;
            m[5] = sy;
            m[10] = 1.0;  // 深度方向不缩放
            m[12] = tx;
            m[13] = ty;
            m[15] = 1.0;

            // 将矩阵乘到当前投影矩阵上
            gl.glMultMatrixd(m);
        }
    }
}