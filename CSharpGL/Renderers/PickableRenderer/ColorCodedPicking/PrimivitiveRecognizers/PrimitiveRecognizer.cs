using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGL
{
    internal abstract class PrimitiveRecognizer
    {
        /// <summary>
        /// 识别出以<paramref name="lastVertexId"/>结尾的图元。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBufferPtr"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveInfo> Recognize(
         uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveInfo>();
            switch (oneIndexBufferPtr.Type)
            {
                case IndexElementType.UByte:
                    RecognizeByte(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;

                case IndexElementType.UShort:
                    RecognizeUShort(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;

                case IndexElementType.UInt:
                    RecognizeUInt(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList);

        /// <summary>
        /// 识别出以<paramref name="lastVertexId"/>结尾的图元。
        /// <para>识别过程中要考虑排除PrimitiveRestartIndex</para>
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBufferPtr"></param>
        /// <param name="primitiveRestartIndex"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveInfo> Recognize(
            uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveInfo>();
            if (lastVertexId != primitiveRestartIndex)
            {
                switch (oneIndexBufferPtr.Type)
                {
                    case IndexElementType.UByte:
                        RecognizeByte(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;

                    case IndexElementType.UShort:
                        RecognizeUShort(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;

                    case IndexElementType.UInt:
                        RecognizeUInt(lastVertexId, pointer, oneIndexBufferPtr, lastIndexIdList, primitiveRestartIndex);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex);
    }

    internal class RecognizedPrimitiveInfo
    {
        private uint index;

        public RecognizedPrimitiveInfo(uint lastVertexId, uint index, params uint[] indexIds)
        {
            this.LastVertexId = lastVertexId;
            this.index = index;
            this.VertexIdList = new List<uint>();
            this.VertexIdList.AddRange(indexIds);
        }

        public uint LastVertexId { get; set; }

        public List<uint> VertexIdList { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.VertexIdList.Count - 1; i++)
            {
                builder.Append(this.VertexIdList[i]); builder.Append(", ");
            }

            builder.Append(this.VertexIdList[this.VertexIdList.Count - 1]);
            builder.AppendFormat(" | index buffer[{0}] is <{1}>", index, LastVertexId);

            return builder.ToString();
        }
    }
}