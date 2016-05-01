using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 北斗七星+北极星
    /// <para>Big Dipper and North Star</para>
    /// </summary>
    internal class BigDipperModel
    {
        internal static readonly vec3[] positions;
        internal static readonly vec3[] colors;

        static BigDipperModel()
        {
            positions = new vec3[8];
            positions[0] = new vec3(0, 2, 0);
            positions[1] = new vec3(1, 2, 0);
            positions[2] = new vec3(2, 1.5f, 0);
            positions[3] = new vec3(3, 1.25f, 0);
            positions[4] = new vec3(3.5f, 0, 0);
            positions[5] = new vec3(4.5f, 0, 0);
            positions[6] = new vec3(5, 1, 0);
            positions[7] = new vec3(5.9f, 4.1f, 0);
            positions = positions.Move2Center();

            colors = new vec3[8];
            colors[0] = new vec3(1, 0, 0);
            colors[1] = new vec3(1, 0.5f, 0);
            colors[2] = new vec3(1, 1, 0);
            colors[3] = new vec3(0, 1, 0);
            colors[4] = new vec3(0, 1, 1);
            colors[5] = new vec3(0, 0, 1);
            colors[6] = new vec3(0.5f, 0, 1);
            colors[7] = new vec3(1.0f, 215.0f / 255.0f, 0.0f);

        }
    }
}
