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

        public override VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.propertyBufferPtr == null)
                {
                    this.propertyBufferPtr = this.GetPositionBufferPtr(varNameInShader);
                }
                return this.propertyBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    this.colorBufferPtr = this.GetColorBufferPtr(varNameInShader);
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.QuadStrip, BufferUsage.StaticDraw))
                {
                    int dimSize = this.DataSource.DimenSize;
                    buffer.DoAlloc(dimSize * 2 * (Marshal.SizeOf(typeof(HalfHexahedronIndex)) / sizeof(uint)));
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
                    this.indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return this.indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public override bool UsesZeroIndexBuffer() { return false; }
    }
}