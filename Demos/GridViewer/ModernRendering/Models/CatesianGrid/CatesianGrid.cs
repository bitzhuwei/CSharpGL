using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class CatesianGrid : GridViewModel
    {
        public CatesianGrid(CatesianGridderSource dataSource, List<GridBlockProperty> gridProps,
            float minColorCode, float maxColorCode, int defaultBlockPropertyIndex = 0)
            : base(dataSource, gridProps, minColorCode, maxColorCode, defaultBlockPropertyIndex)
        { }

        public override VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.propertyBuffer == null)
                {
                    this.propertyBuffer = this.GetPositionBuffer(varNameInShader);
                }
                return this.propertyBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = this.GetColorBuffer(varNameInShader);
                }
                return this.colorBuffer;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int dimSize = this.DataSource.DimenSize;
                int length = dimSize * 2 * (Marshal.SizeOf(typeof(HalfHexahedronIndex)) / sizeof(uint));
                OneIndexBuffer buffer = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.QuadStrip, IndexElementType.UInt, length);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (HalfHexahedronIndex*)pointer;
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
                    buffer.UnmapBuffer();
                }
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        private IndexBuffer indexBuffer;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public override bool UsesZeroIndexBuffer() { return false; }
    }
}