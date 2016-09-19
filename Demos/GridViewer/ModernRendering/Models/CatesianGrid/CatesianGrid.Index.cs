using CSharpGL;
using System.Runtime.InteropServices;

namespace GridViewer
{
    public partial class CatesianGrid
    {
        private IndexBufferPtr indexBufferPtr;

        private IndexBufferPtr GetIndexBufferPtr()
        {
            IndexBufferPtr ptr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.QuadStrip, BufferUsage.StaticDraw))
            {
                int dimSize = this.DataSource.DimenSize;
                buffer.Create(dimSize * 2 * (Marshal.SizeOf(typeof(HalfHexahedronIndex)) / sizeof(uint)));
                unsafe
                {
                    var array = (HalfHexahedronIndex*)buffer.Header.ToPointer();
                    for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                    {
                        array[gridIndex * 2].dot0 = (uint)(8 * gridIndex + 6);
                        array[gridIndex * 2].dot1 = (uint)(8 * gridIndex + 2);
                        array[gridIndex * 2].dot2 = (uint)(8 * gridIndex + 7);
                        array[gridIndex * 2].dot3 = (uint)(8 * gridIndex + 3);
                        array[gridIndex * 2].dot4 = (uint)(8 * gridIndex + 4);
                        array[gridIndex * 2].dot5 = (uint)(8 * gridIndex + 0);
                        array[gridIndex * 2].dot6 = (uint)(8 * gridIndex + 5);
                        array[gridIndex * 2].dot7 = (uint)(8 * gridIndex + 1);
                        array[gridIndex * 2].restartIndex = uint.MaxValue;

                        array[gridIndex * 2 + 1].dot0 = (uint)(8 * gridIndex + 3);
                        array[gridIndex * 2 + 1].dot1 = (uint)(8 * gridIndex + 0);
                        array[gridIndex * 2 + 1].dot2 = (uint)(8 * gridIndex + 2);
                        array[gridIndex * 2 + 1].dot3 = (uint)(8 * gridIndex + 1);
                        array[gridIndex * 2 + 1].dot4 = (uint)(8 * gridIndex + 6);
                        array[gridIndex * 2 + 1].dot5 = (uint)(8 * gridIndex + 5);
                        array[gridIndex * 2 + 1].dot6 = (uint)(8 * gridIndex + 7);
                        array[gridIndex * 2 + 1].dot7 = (uint)(8 * gridIndex + 4);
                        array[gridIndex * 2 + 1].restartIndex = uint.MaxValue;
                    }
                }
                ptr = buffer.GetBufferPtr() as IndexBufferPtr;
            }

            return ptr;
        }
        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public override bool UsesZeroIndexBuffer() { return false; }

    }

    /// <summary>
    /// 描述用OpenGL.GL_QUAD_STRIP渲染六面体时的三个面+一个PrimitiveRestart索引。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HalfHexahedronIndex
    {
        /// <summary>
        /// 第0个顶点的索引值
        /// </summary>
        public uint dot0;

        /// <summary>
        /// 第1个顶点的索引值
        /// </summary>
        public uint dot1;

        /// <summary>
        /// 第2个顶点的索引值
        /// </summary>
        public uint dot2;

        public uint dot3;
        public uint dot4;
        public uint dot5;
        public uint dot6;
        public uint dot7;

        /// <summary>
        /// 请始终给此变量赋值uint.MaxValue
        /// </summary>
        public uint restartIndex;
    }
}