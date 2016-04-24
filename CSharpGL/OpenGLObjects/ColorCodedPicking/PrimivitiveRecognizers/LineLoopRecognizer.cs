using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class LineLoopRecognizer : PrimitiveRecognizer
    {
     
        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(array[0 - 0]);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(array[0 - 0]);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr,
            List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(array[0 - 0]);
                    lastIndexIdList.Add(item);
                }
            }
        }


        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        if (array[i - 1] != primitiveRestartIndex)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                            item.IndexIdList.Add(array[i - 1]);
                            item.IndexIdList.Add(array[i - 0]);
                            lastIndexIdList.Add(item);
                        }
                    }
                }
                if (array[0] == lastVertexId)
                {
                    if (array[length - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                        item.IndexIdList.Add(array[length - 1]);
                        item.IndexIdList.Add(array[0 - 0]);
                        lastIndexIdList.Add(item);
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
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        if (array[i - 1] != primitiveRestartIndex)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                            item.IndexIdList.Add(array[i - 1]);
                            item.IndexIdList.Add(array[i - 0]);
                            lastIndexIdList.Add(item);
                        }
                    }
                }
                if (array[0] == lastVertexId)
                {
                    if (array[length - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                        item.IndexIdList.Add(array[length - 1]);
                        item.IndexIdList.Add(array[0 - 0]);
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
                for (uint i = 1; i < length; i++)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        if (array[i - 1] != primitiveRestartIndex)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                            item.IndexIdList.Add(array[i - 1]);
                            item.IndexIdList.Add(array[i - 0]);
                            lastIndexIdList.Add(item);
                        }
                    }
                }
                if (array[0] == lastVertexId)
                {
                    if (array[length - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, 0 - 0);
                        item.IndexIdList.Add(array[length - 1]);
                        item.IndexIdList.Add(array[0 - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

    }
}
