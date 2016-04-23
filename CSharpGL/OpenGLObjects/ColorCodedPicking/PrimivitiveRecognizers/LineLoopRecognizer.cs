using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class LineLoopRecognizer : PrimitiveRecognizer
    {
        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, int length)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
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

            return lastIndexIdList;
        }

        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, int length, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
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

            return lastIndexIdList;
        }

    }
}
