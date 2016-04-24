using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class QuadStripRecognizer : PrimitiveRecognizer
    {
        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 3; i < length; i += 2)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(array[i - 0]);
                        lastIndexIdList.Add(item);
                    }
                }
            }

            return lastIndexIdList;
        }

        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 3; i < length; i += 2)
                {
                    if (array[i - 0] == lastVertexId)
                    {
                        if (array[i - 3] != primitiveRestartIndex
                            && array[i - 2] != primitiveRestartIndex
                            && array[i - 1] != primitiveRestartIndex)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, i - 0);
                            item.IndexIdList.Add(array[i - 3]);
                            item.IndexIdList.Add(array[i - 2]);
                            item.IndexIdList.Add(array[i - 1]);
                            item.IndexIdList.Add(array[i - 0]);
                            lastIndexIdList.Add(item);
                        }
                    }
                }
            }

            return lastIndexIdList;
        }

    }
}
