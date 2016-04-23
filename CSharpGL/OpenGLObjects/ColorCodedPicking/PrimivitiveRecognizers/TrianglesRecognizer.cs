using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class TrianglesRecognizer : PrimitiveRecognizer
    {
        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexID, IntPtr pointer, int length)
        {
            var lastIndexIDList = new List<RecognizedPrimitiveIndex>();
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 2; i < length; i += 3)
                {
                    if (array[i] == lastVertexID)
                    {
                        var item = new RecognizedPrimitiveIndex(i);
                        item.IndexIDList.Add(i - 2);
                        item.IndexIDList.Add(i - 1);
                        item.IndexIDList.Add(i - 0);
                        lastIndexIDList.Add(item);
                    }
                }
            }

            return lastIndexIDList;
        }

        public override List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexID, IntPtr pointer, int length, uint primitiveRestartIndex)
        {
            var lastIndexIDList = new List<RecognizedPrimitiveIndex>();
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                while (i + 2 < length)
                {
                    if (array[i] == primitiveRestartIndex)
                    {
                        i++;
                    }
                    else
                    {
                        if (array[i + 2] == lastVertexID)
                        {
                            var item = new RecognizedPrimitiveIndex(i + 2);
                            item.IndexIDList.Add(i + 0);
                            item.IndexIDList.Add(i + 1);
                            item.IndexIDList.Add(i + 2);
                            lastIndexIDList.Add(item);
                        }

                        i += 3;
                    }
                }
            }

            return lastIndexIDList;
        }

    }
}
