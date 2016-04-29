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
    /// 一个立方体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000061.jpg
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000062.jpg
    /// </summary>
    internal class CubeModel
    {
        static readonly vec3[] eightVertexes = new vec3[] 
        { 
            new vec3(-1, 1, 1), new vec3(1, 1, 1), new vec3(1, 1, -1), new vec3(-1, 1, -1),
            new vec3(-1, -1, 1), new vec3(1, -1, 1), new vec3(1, -1, -1), new vec3(-1, -1, -1), 
        };

        internal static readonly CubePosition position = new CubePosition()
        {
            faceX = new SqurePosition() { position0 = eightVertexes[1], position1 = eightVertexes[2], position2 = eightVertexes[6], position3 = eightVertexes[5], },
            faceNX = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[3], position2 = eightVertexes[7], position3 = eightVertexes[4], },
            faceY = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[1], position2 = eightVertexes[2], position3 = eightVertexes[3], },
            faceNY = new SqurePosition() { position0 = eightVertexes[4], position1 = eightVertexes[5], position2 = eightVertexes[6], position3 = eightVertexes[7], },
            faceZ = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[1], position2 = eightVertexes[5], position3 = eightVertexes[4], },
            faceNZ = new SqurePosition() { position0 = eightVertexes[3], position1 = eightVertexes[2], position2 = eightVertexes[6], position3 = eightVertexes[7], },
        };
        internal static readonly CubeColor color = new CubeColor()
        {
            faceX = new SqureColor(new vec3(0, 0, 1)),
            faceNX = new SqureColor(new vec3(0, 1, 0)),
            faceY = new SqureColor(new vec3(0, 1, 1)),
            faceNY = new SqureColor(new vec3(1, 0, 0)),
            faceZ = new SqureColor(new vec3(1, 0, 1)),
            faceNZ = new SqureColor(new vec3(1, 1, 0)),
        };
        internal static readonly CubeNormal normal = new CubeNormal()
        {
            faceX = new SqureNormal(new vec3(1, 0, 0)),
            faceNX = new SqureNormal(new vec3(-1, 0, 0)),
            faceY = new SqureNormal(new vec3(0, 1, 0)),
            faceNY = new SqureNormal(new vec3(0, -1, 0)),
            faceZ = new SqureNormal(new vec3(0, 0, 1)),
            faceNZ = new SqureNormal(new vec3(0, 0, -1)),
        };
        internal static readonly byte[] index = new byte[] 
        {
            0, 1, 2, 0, 2, 3, 
            4, 5, 6, 4, 6, 7, 
            8, 9, 10, 8, 10, 11,
            12, 13, 14, 12, 14, 15,
            16, 17, 18, 16, 18, 19,
            20, 21, 22, 20, 22, 23 
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct CubeColor
        {
            public SqureColor faceX;
            public SqureColor faceNX;
            public SqureColor faceY;
            public SqureColor faceNY;
            public SqureColor faceZ;
            public SqureColor faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SqureColor
        {
            public vec3 color0;
            public vec3 color1;
            public vec3 color2;
            public vec3 color3;

            public SqureColor(vec3 color)
            {
                this.color0 = color;
                this.color1 = color;
                this.color2 = color;
                this.color3 = color;
            }

            public override string ToString()
            {
                return string.Format("color: {0}", color0);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct CubePosition
        {
            public SqurePosition faceX;
            public SqurePosition faceNX;
            public SqurePosition faceY;
            public SqurePosition faceNY;
            public SqurePosition faceZ;
            public SqurePosition faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SqurePosition
        {
            public vec3 position0;
            public vec3 position1;
            public vec3 position2;
            public vec3 position3;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct CubeNormal
        {
            public SqureNormal faceX;
            public SqureNormal faceNX;
            public SqureNormal faceY;
            public SqureNormal faceNY;
            public SqureNormal faceZ;
            public SqureNormal faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SqureNormal
        {
            public vec3 normal0;
            public vec3 normal1;
            public vec3 normal2;
            public vec3 normal3;

            public SqureNormal(vec3 normal)
            {
                this.normal0 = normal;
                this.normal1 = normal;
                this.normal2 = normal;
                this.normal3 = normal;
            }

            public override string ToString()
            {
                return string.Format("normal: {0}", normal0);
            }
        }


    }
}