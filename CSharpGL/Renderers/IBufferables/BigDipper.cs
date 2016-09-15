using System;

namespace CSharpGL
{
    /// <summary>
    /// 北斗七星
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class BigDipper : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public const string position = "position";

        /// <summary>
        ///
        /// </summary>
        public const string color = "color";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(BigDipperModel.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < BigDipperModel.positions.Length; i++)
                            {
                                array[i] = BigDipperModel.positions[i];
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == color)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(BigDipperModel.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < BigDipperModel.colors.Length; i++)
                            {
                                array[i] = BigDipperModel.colors[i];
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.LineStrip, 0, BigDipperModel.positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
                //using (var buffer = new OneIndexBuffer<uint>(
                //    DrawMode.Lines, BufferUsage.StaticDraw))
                //{
                //    buffer.Alloc(BigDipperModel.positions.Length);
                //    unsafe
                //    {
                //        var array = (uint*)buffer.Header.ToPointer();
                //        for (uint i = 0; i < BigDipperModel.positions.Length; i++)
                //        {
                //            array[i] = i;
                //        }
                //        array[0] = uint.MaxValue;
                //        array[4] = uint.MaxValue;
                //        array[10] = uint.MaxValue;
                //    }
                //    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                //}
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}