using CSharpGL;
using SimLab.GridSource;
using SimLab.SimGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace GridViewer
{
    public partial class CatesianGrid
    {
        private IndexBufferPtr indexBufferPtr;

        private IndexBufferPtr GetIndexBufferPtr()
        {
            IndexBufferPtr ptr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.QuadStrip, BufferUsage.StaticDraw))
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

    }
}
