using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class TriangleFanRecognizer : PrimitiveRecognizer
    {


        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                if (lastVertexId == array[length - 1])
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                    for (uint i = 0; i < length; i++)
                    {
                        item.IndexIdList.Add(array[i]);
                    }
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
                if (lastVertexId == array[length - 1])
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                    for (uint i = 0; i < length; i++)
                    {
                        item.IndexIdList.Add(array[i]);
                    }
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                if (lastVertexId == array[length - 1])
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                    for (uint i = 0; i < length; i++)
                    {
                        item.IndexIdList.Add(array[i]);
                    }
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                int first = 0;
                while (first < length && array[first] == primitiveRestartIndex) { first++; }
                for (int i = first + 1; i < length; i++)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        if (array[i - 1] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                            for (int t = first; t < i; t++)
                            {
                                item.IndexIdList.Add(array[t]);
                            }
                            lastIndexIdList.Add(item);
                        }
                        first = i + 1;
                        while (first < length && array[first] == primitiveRestartIndex) { first++; }
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
                int first = 0;
                while (first < length && array[first] == primitiveRestartIndex) { first++; }
                for (int i = first + 1; i < length; i++)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        if (array[i - 1] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                            for (int t = first; t < i; t++)
                            {
                                item.IndexIdList.Add(array[t]);
                            }
                            lastIndexIdList.Add(item);
                        }
                        first = i + 1;
                        while (first < length && array[first] == primitiveRestartIndex) { first++; }
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
                int first = 0;
                while (first < length && array[first] == primitiveRestartIndex) { first++; }
                for (int i = first + 1; i < length; i++)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        if (array[i - 1] == lastVertexId)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(length - 1));
                            for (int t = first; t < i; t++)
                            {
                                item.IndexIdList.Add(array[t]);
                            }
                            lastIndexIdList.Add(item);
                        }
                        first = i + 1;
                        while (first < length && array[first] == primitiveRestartIndex) { first++; }
                    }
                }
            }
        }
    }
}
