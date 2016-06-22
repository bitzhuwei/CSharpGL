using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            positions = new vec3[11];
            positions[0] = new vec3(0, 2, 0);
            positions[1] = new vec3(1, 2, 0);
            positions[2] = new vec3(2, 1.5f, 0);
            positions[3] = new vec3(3, 1.25f, 0);
            positions[4] = new vec3(3.5f, 0, 0);
            positions[5] = new vec3(4.5f, 0, 0);
            positions[6] = new vec3(5, 1, 0);
            positions[7] = new vec3(5.9f, 4.1f, 0);
            positions[8] = new vec3(6.1f, 4.2f, 0);
            positions[9] = new vec3(6.2f, 3.9f, 0);
            positions[10] = new vec3(6.4f, 3.9f, 0);
            positions.Move2Center();

            colors = new vec3[11];
            colors[0] = new vec3(1, 0, 0);
            colors[1] = new vec3(1, 0.5f, 0);
            colors[2] = new vec3(1, 1, 0);
            colors[3] = new vec3(0, 1, 0);
            colors[4] = new vec3(0, 1, 1);
            colors[5] = new vec3(0, 0, 1);
            colors[6] = new vec3(0.5f, 0, 1);
            colors[7] = new vec3(1.0f, 215.0f / 255.0f, 0.0f);
            colors[8] = new vec3(1.0f * 0.9f, 215.0f / 255.0f * 0.9f, 0.0f);
            colors[9] = new vec3(1.0f * 0.8f, 215.0f / 255.0f * 0.8f, 0.0f);
            colors[10] = new vec3(1.0f * 0.7f, 215.0f / 255.0f * 0.7f, 0.0f);

        }
    }
}
