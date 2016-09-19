using System;

namespace CSharpGL
{
    /// <summary>
    /// 链条。若干个点用直线连接起来。
    /// </summary>
    internal class ChainModel
    {
        public vec3[] Positions { get; protected set; }
        public vec3[] Colors { get; protected set; }
        public uint[] Indexes { get; protected set; }

        public vec3 Lengths { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} vertexes, {1} indexes", Positions.Length, Indexes.Length);
        }

        private Random random = new Random();

        /// <summary>
        /// 链条。若干个点用直线连接起来。
        /// </summary>
        /// <param name="pointCount">有多少个点</param>
        /// <param name="length">点的范围（长度）</param>
        /// <param name="width">点的范围（宽度）</param>
        /// <param name="height">点的范围（高度）</param>
        public ChainModel(int pointCount = 10, int length = 5, int width = 5, int height = 5)
        {
            var positions = new vec3[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                var point = new vec3();
                point.x = (float)random.NextDouble() * length;
                point.y = (float)random.NextDouble() * width;
                point.z = (float)random.NextDouble() * height;
                positions[i] = point;
            }
            BoundingBox box = positions.Move2Center();
            this.Lengths = box.MaxPosition - box.MinPosition;
            this.Positions = positions;

            this.Colors = new vec3[pointCount];
            {
                for (int i = 0; i < pointCount; i++)
                {
                    uint p = (uint)((256 * 256 * 256) / pointCount * (i + 1));
                    var color = new vec3();
                    color.x = ((p >> 0) & 0xFF) / 255.0f;
                    color.y = ((p >> 8) & 0xFF) / 255.0f;
                    color.z = ((p >> 16) & 0xFF) / 255.0f;
                    this.Colors[i] = color;
                }
            }
        }
    }
}