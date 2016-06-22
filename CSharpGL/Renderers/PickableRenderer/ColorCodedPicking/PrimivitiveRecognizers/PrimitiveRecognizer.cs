using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    abstract class PrimitiveRecognizer
    {

        /// <summary>
        /// 识别出以<see cref="lastVertexId"/>结尾的图元。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBufferPtr"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveIndex> Recognize(
         uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            switch (oneIndexBufferPtr.Type)
            {
                case IndexElementType.UnsignedByte:
                    RecognizeByte(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;
                case IndexElementType.UnsignedShort:
                    RecognizeUShort(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;
                case IndexElementType.UnsignedInt:
                    RecognizeUInt(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList);

        /// <summary>
        /// 识别出以<see cref="lastVertexId"/>结尾的图元。
        /// <para>识别过程中要考虑排除PrimitiveRestartIndex</para>
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBufferPtr"></param>
        /// <param name="primitiveRestartIndex"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveIndex> Recognize(
            uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveIndex>();
            if (lastVertexId != primitiveRestartIndex)
            {
                switch (oneIndexBufferPtr.Type)
                {
                    case IndexElementType.UnsignedByte:
                        RecognizeByte(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;
                    case IndexElementType.UnsignedShort:
                        RecognizeUShort(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;
                    case IndexElementType.UnsignedInt:
                        RecognizeUInt(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex);

    }

    class RecognizedPrimitiveIndex
    {
        private uint Index;
        public RecognizedPrimitiveIndex(uint lastIndexId, uint index, params uint[] indexIds)
        {
            //if (indexIDs.Length == 0) { throw new ArgumentException(); }
            //if (indexIDs[indexIDs.Length - 1] != lastIndexId) { throw new ArgumentException(); }

            this.LastIndexId = lastIndexId;
            this.Index = index;
            this.IndexIdList = new List<uint>();
            this.IndexIdList.AddRange(indexIds);
        }

        public uint LastIndexId { get; set; }

        public List<uint> IndexIdList { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.IndexIdList.Count - 1; i++)
            {
                builder.Append(this.IndexIdList[i]); builder.Append(", ");
            }

            builder.Append(this.IndexIdList[this.IndexIdList.Count - 1]);
            builder.AppendFormat(" | index[{0}] is [{1}]", Index, LastIndexId);

            return builder.ToString();
        }
    }
}
