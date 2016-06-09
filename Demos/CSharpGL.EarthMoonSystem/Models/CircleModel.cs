using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    /// <summary>
    /// 圆形平面（表示黄道、白道）
    /// </summary>
    class CircleModel
    {
        internal vec2[] positions;

        /// <summary>
        /// 圆形平面（表示黄道、白道）
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="sliceParts">把圆形像披萨一样切割为几块。</param>
        /// <returns></returns>
        internal CircleModel(float radius = 1.0f, int sliceParts = 360)
        {
            if (radius <= 0.0f || sliceParts < 2) { throw new Exception(); }

            int vertexCount = (sliceParts + 2);
            this.positions = new vec2[vertexCount];

            // 把星球平铺在一个平面上
            for (int i = 1; i < sliceParts + 2; i++)
            {
                double x = radius * Math.Cos(Math.PI * 2 * (double)(i - 1) / (double)(sliceParts));
                double y = radius * Math.Sin(Math.PI * 2 * (double)(i - 1) / (double)(sliceParts));

                this.positions[i] = new vec2((float)x, (float)y);
            }
        }
    }
}
