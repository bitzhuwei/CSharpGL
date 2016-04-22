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
    class BigDipper : PCIModel
    {
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
            //{
            //    Indexes = new uint[BigDipperIndexes.Length];
            //    for (int i = 0; i < BigDipperIndexes.Length; i++)
            //    {
            //        Indexes[i] = BigDipperIndexes[i];
            //    }
            //}
        }

        static vec3[] BigDipperPositions { get; set; }
        static vec3[] BigDipperColors { get; set; }
        static uint[] BigDipperIndexes { get; set; }

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

            BigDipperIndexes = new uint[7];
            for (uint i = 0; i < BigDipperIndexes.Length; i++)
            {
                BigDipperIndexes[i] = i;
            }

        }
    }
}
