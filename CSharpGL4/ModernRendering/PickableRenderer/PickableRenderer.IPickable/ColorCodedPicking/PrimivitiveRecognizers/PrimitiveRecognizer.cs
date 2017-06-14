using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal abstract class PrimitiveRecognizer
    {
        /// <summary>
        /// 识别出以<paramref name="lastVertexId"/>结尾的图元。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBuffer"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveInfo> Recognize(
         uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveInfo>();
            switch (oneIndexBuffer.ElementType)
            {
                case IndexBufferElementType.UByte:
                    RecognizeByte(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList);
                    break;

                case IndexBufferElementType.UShort:
                    RecognizeUShort(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList);
                    break;

                case IndexBufferElementType.UInt:
                    RecognizeUInt(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList);

        /// <summary>
        /// 识别出以<paramref name="lastVertexId"/>结尾的图元。
        /// <para>识别过程中要考虑排除PrimitiveRestartIndex</para>
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="oneIndexBuffer"></param>
        /// <param name="primitiveRestartIndex"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveInfo> Recognize(
            uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, uint primitiveRestartIndex)
        {
            var lastIndexIdList = new List<RecognizedPrimitiveInfo>();
            if (lastVertexId != primitiveRestartIndex)
            {
                switch (oneIndexBuffer.ElementType)
                {
                    case IndexBufferElementType.UByte:
                        RecognizeByte(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList, primitiveRestartIndex);
                        break;

                    case IndexBufferElementType.UShort:
                        RecognizeUShort(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList, primitiveRestartIndex);
                        break;

                    case IndexBufferElementType.UInt:
                        RecognizeUInt(lastVertexId, pointer, oneIndexBuffer, lastIndexIdList, primitiveRestartIndex);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return lastIndexIdList;
        }

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBuffer oneIndexBuffer, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);
    }
}