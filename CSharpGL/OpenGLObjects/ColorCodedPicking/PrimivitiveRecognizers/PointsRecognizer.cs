using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class PointsRecognizer : PrimitiveRecognizer
    {


        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 0; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                for (uint i = 0; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                for (uint i = 0; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                while (i + 0 < length)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        i++;
                    }
                    else
                    {
                        if (array[i + 0] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i + 0);
                            item.IndexIdList.Add(array[i + 0]);
                            lastIndexIdList.Add(item);
                        }

                        i++;
                    }
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                uint i = 0;
                while (i + 0 < length)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        i++;
                    }
                    else
                    {
                        if (array[i + 0] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i + 0);
                            item.IndexIdList.Add(array[i + 0]);
                            lastIndexIdList.Add(item);
                        }

                        i++;
                    }
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                uint i = 0;
                while (i + 0 < length)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        i++;
                    }
                    else
                    {
                        if (array[i + 0] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i + 0);
                            item.IndexIdList.Add(array[i + 0]);
                            lastIndexIdList.Add(item);
                        }

                        i++;
                    }
                }
            }
        }
    }
}
