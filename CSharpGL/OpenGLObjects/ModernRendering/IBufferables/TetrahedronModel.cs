using CSharpGL;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Models
{
    /// <summary>
    /// 一个四面体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_tetrahedron.jpg
    /// </summary>
    internal class TetrahedronModel
    {
        internal static readonly vec3[] position = new vec3[4];
        static readonly vec3 center =
            new vec3(1.0f / (float)Math.Sqrt(3),
                (float)Math.Sqrt(8.0 / 3.0) - (float)Math.Sqrt(3.0 / 2.0),
                0);
        internal static readonly vec3[] normal = new vec3[4];

        internal static readonly vec3[] color = new vec3[] 
        { 
            new vec3(0, 0, 1),
            new vec3(1, 0, 0),
            new vec3(0, 0, 1),
            new vec3(0, 1, 0),
        };

        internal static readonly byte[] index = new byte[] { 0, 1, 3, 0, 2, 3, 1, 2, 3, 0, 1, 2, };

        static TetrahedronModel()
        {
            position[0] = new vec3(0, 0, 1);
            position[1] = new vec3((float)Math.Sqrt(3), 0, 0);
            position[2] = new vec3(0, 0, -1);
            position[3] = new vec3(1.0f / (float)Math.Sqrt(3), (float)Math.Sqrt(8.0 / 3.0), 0);

            for (int i = 0; i < position.Length; i++)
            {
                normal[i] = (position[i] - center).normalize();
            }

            vec3[] tmp = position.Move2Center();
            position[0] = tmp[0];
            position[1] = tmp[1];
            position[2] = tmp[2];
            position[3] = tmp[3];
        }
    }
}