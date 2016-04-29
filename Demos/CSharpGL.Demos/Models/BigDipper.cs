using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Models
{
    /// <summary>
    /// 北斗七星
    /// </summary>
    class BigDipper
    {
        public vec3[] Positions { get; protected set; }
        public vec3[] Colors { get; protected set; }
        public uint[] Indexes { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} vertexes, {1} indexes", Positions.Length, Indexes.Length);
        }

        public BigDipper()
        {
            {
                Positions = new vec3[BigDipperPositions.Length];
                for (int i = 0; i < BigDipperPositions.Length; i++)
                {
                    Positions[i] = BigDipperPositions[i];
                }
            }
            {
                Colors = new vec3[BigDipperColors.Length];
                for (int i = 0; i < BigDipperColors.Length; i++)
                {
                    Colors[i] = BigDipperColors[i];
                }
            }
        }

        static readonly vec3[] BigDipperPositions;
        static readonly vec3[] BigDipperColors;

        static BigDipper()
        {
            BigDipperPositions = new vec3[7];
            BigDipperPositions[0] = new vec3(0, 2, 0);
            BigDipperPositions[1] = new vec3(1, 2, 0);
            BigDipperPositions[2] = new vec3(2, 1.5f, 0);
            BigDipperPositions[3] = new vec3(3, 1.25f, 0);
            BigDipperPositions[4] = new vec3(3.5f, 0, 0);
            BigDipperPositions[5] = new vec3(4.5f, 0, 0);
            BigDipperPositions[6] = new vec3(5, 1, 0);
            BigDipperPositions = BigDipperPositions.Move2Center();

            BigDipperColors = new vec3[7];
            BigDipperColors[0] = new vec3(1, 0, 0);
            BigDipperColors[1] = new vec3(1, 0.5f, 0);
            BigDipperColors[2] = new vec3(1, 1, 0);
            BigDipperColors[3] = new vec3(0, 1, 0);
            BigDipperColors[4] = new vec3(0, 1, 1);
            BigDipperColors[5] = new vec3(0, 0, 1);
            BigDipperColors[6] = new vec3(0.5f, 0, 1);

        }
    }
}
