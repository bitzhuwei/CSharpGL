using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class PointsRecognizer : PrimitiveRecognizer
    {
        public override List<RecognizedPrimitiveIndex> Recognize(
           uint lastVertexId, IntPtr pointer, int length)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
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

            return lastIndexIdList;
        }

        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, int length, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
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

                        i += 3;
                    }
                }
            }

            return lastIndexIdList;
        }

    }
}
