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
    public class TetrahedronModel
    {
        public vec3[] position = new vec3[] 
        { 
            new vec3(0, 0, 1),
            new vec3((float)Math.Sqrt(3), 0, 0),
            new vec3(0, 0, -1),
            new vec3(1.0f / (float)Math.Sqrt(3), (float)Math.Sqrt(8.0 / 3.0), 0),
        };
        static readonly vec3 center =
            new vec3(1.0f / (float)Math.Sqrt(3),
                (float)Math.Sqrt(8.0 / 3.0) - (float)Math.Sqrt(3.0 / 2.0),
                0);
        public vec3[] normal;

        public vec3[] color = new vec3[] 
        { 
            new vec3(0, 0, 1),
            new vec3(1, 0, 0),
            new vec3(0, 0, 1),
            new vec3(0, 1, 0),
        };
        public byte[] index = new byte[] { 0, 1, 3, 0, 2, 3, 1, 2, 3, 0, 1, 2, };

        public TetrahedronModel(float radius = 1.0f)
        {
            this.normal = new vec3[this.position.Length];
            for (int i = 0; i < this.position.Length; i++)
            {
                this.normal[i] = (this.position[i] - center).normalize();
            }

            for (int i = 0; i < this.position.Length; i++)
            {
                this.position[i] = this.position[i] * radius;
            }

            this.position = this.position.Move2Center();
        }
    }
}