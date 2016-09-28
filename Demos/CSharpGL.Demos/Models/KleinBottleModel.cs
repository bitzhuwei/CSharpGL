using System;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Klein bottle model.
    /// </summary>
    internal class KleinBottleModel : IBufferable
    {
        private double interval;

        public KleinBottleModel(double interval = 0.02)
        {
            this.interval = interval;
        }

        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBufferPtr;

        private IndexBufferPtr indexBufferPtr = null;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    this.positionBufferPtr = GetPositionBufferPtr(varNameInShader);
                }
                return this.positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private VertexAttributeBufferPtr GetPositionBufferPtr(string varNameInShader)
        {
            using (var buffer = new VertexAttributeBuffer<vec3>(
                varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
            {
                int uCount = (int)(Math.PI / interval);
                int vCount = (int)(Math.PI * 2 / interval);
                buffer.Create(uCount * vCount);
                unsafe
                {
                    int index = 0;
                    var array = (vec3*)buffer.Header.ToPointer();
                    for (double u = 0; u < Math.PI; u += interval)
                    {
                        for (double v = 0; v < Math.PI * 2; v += interval)
                        {
                            double sinU = Math.Sin(u), cosU = Math.Cos(u);
                            double sinV = Math.Sin(v), cosV = Math.Cos(v);
                            double x = -2.0 / 15.0 * cosU * (3 * cosV - 30 * sinU + 90 * Math.Pow(cosU, 4) * sinU - 60 * Math.Pow(cosU, 6) * sinU + 5 * cosU * cosV * sinU);
                            double y = -1.0 / 15.0 * sinU * (3 * cosV - 3 * Math.Pow(cosU, 2) * cosV - 48 * Math.Pow(cosU, 4) * cosV + 48 * Math.Pow(cosU, 6) * cosV - 60 * sinU + 5 * cosU * cosV * sinU - 5 * Math.Pow(cosU, 3) * cosV * sinU - 80 * Math.Pow(cosU, 5) * cosV * sinU + 80 * Math.Pow(cosU, 7) * cosV * sinU);
                            double z = 2.0 / 15.0 * (3.0 + 5 * cosU * sinU) * sinV;
                            array[index++] = new vec3((float)x, (float)y, (float)z);
                        }
                    }
                }

                positionBufferPtr = buffer.GetBufferPtr();

                return positionBufferPtr;
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                int uCount = (int)(Math.PI / interval);
                int vCount = (int)(Math.PI * 2 / interval);
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.Points, 0, uCount * vCount))
                {
                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}