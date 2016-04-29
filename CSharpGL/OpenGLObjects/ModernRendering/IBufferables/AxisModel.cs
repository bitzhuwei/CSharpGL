using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 3D坐标系
    /// </summary>
    internal class AxisModel
    {
        internal vec3[] positions;
        internal vec3[] colors;
        internal uint[] indexes;

        internal DrawMode mode = DrawMode.TriangleFan;

        public AxisModel(uint partCount = 12, float radius = 1.0f)
        {
            this.positions = GeneratePositions(partCount);
            for (int i = 0; i < this.positions.Length; i++)
            {
                this.positions[i] *= radius;
            }
            this.colors = GenrateColors(partCount);
            this.indexes = GenerateIndexes(partCount);
        }

        private uint[] GenerateIndexes(uint partCount)
        {
            var indexes = new uint[3 * (3 * (1 + partCount + 1))];
            int index = 0;
            // x axis
            indexes[index++] = 0;
            for (uint i = 0; i < partCount; i++)
            {
                indexes[index++] = i + 1;
            }
            indexes[index++] = uint.MaxValue;
            indexes[index++] = (uint)(1 + partCount);
            for (uint i = 0; i < partCount; i++)
            {
                indexes[index++] = (uint)(i + 1 + (1 + partCount));
            }
            indexes[index++] = uint.MaxValue;
            indexes[index++] = (uint)((3 + 2 * partCount - 1));
            for (uint i = 0; i < partCount; i++)
            {
                indexes[index++] = (uint)(i + 1 + (1 + partCount));
            }
            indexes[index++] = uint.MaxValue;
            // y axis
            for (uint i = 0; i < 3 * (1 + partCount + 1); i++)
            {
                uint value = indexes[i];
                if (value == uint.MaxValue)
                { indexes[index++] = uint.MaxValue; }
                else
                { indexes[index++] = value + 3 + 2 * partCount; }
            }
            // z axis
            for (uint i = 0; i < 3 * (1 + partCount + 1); i++)
            {
                uint value = indexes[i];
                if (value == uint.MaxValue)
                { indexes[index++] = uint.MaxValue; }
                else
                { indexes[index++] = value + 3 + 2 * partCount + 3 + 2 * partCount; }
            }

            return indexes;
        }

        private vec3[] GenrateColors(uint partCount)
        {
            Random r = new Random();
            var colors = new vec3[3 * (3 + 2 * partCount)];
            int index = 0;
            for (int i = 0; i < 3 + 2 * partCount; i++)
            {
                colors[index++] = new vec3((float)r.NextDouble(), 0, 0);
            }
            for (int i = 0; i < 3 + 2 * partCount; i++)
            {
                colors[index++] = new vec3(0, (float)r.NextDouble(), 0);
            }
            for (int i = 0; i < 3 + 2 * partCount; i++)
            {
                colors[index++] = new vec3(0, 0, (float)r.NextDouble());
            }
            return colors;
        }

        private static vec3[] GeneratePositions(uint partCount)
        {
            var positions = new vec3[3 * (3 + 2 * partCount)];
            const float stickLength = 0.75f;
            const float r1 = 0.2f;
            const float r2 = 0.4f;
            int index = 0;
            {
                // x axis
                positions[index++] = new vec3(0, 0, 0);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r1 * (float)Math.Cos(angle);
                    float sin = r1 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(stickLength, cos, sin);
                }
                positions[index++] = new vec3(stickLength, 0, 0);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r2 * (float)Math.Cos(angle);
                    float sin = r2 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(stickLength, cos, sin);
                }
                positions[index++] = new vec3(1.0f, 0, 0);
            }
            {
                // y axis
                positions[index++] = new vec3(0, 0, 0);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r1 * (float)Math.Cos(angle);
                    float sin = r1 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(cos, stickLength, sin);
                }
                positions[index++] = new vec3(0, stickLength, 0);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r2 * (float)Math.Cos(angle);
                    float sin = r2 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(cos, stickLength, sin);
                }
                positions[index++] = new vec3(0, 1.0f, 0);
            }
            {
                // z axis
                positions[index++] = new vec3(0, 0, 0);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r1 * (float)Math.Cos(angle);
                    float sin = r1 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(cos, sin, stickLength);
                }
                positions[index++] = new vec3(0, 0, stickLength);
                for (int i = 0; i < partCount; i++)
                {
                    double angle = 2 * Math.PI * i / partCount;
                    float cos = r2 * (float)Math.Cos(angle);
                    float sin = r2 * (float)Math.Sin(angle);
                    positions[index++] = new vec3(cos, sin, stickLength);
                }
                positions[index++] = new vec3(0, 0, 1.0f);
            }
            return positions;
        }

    }
}

