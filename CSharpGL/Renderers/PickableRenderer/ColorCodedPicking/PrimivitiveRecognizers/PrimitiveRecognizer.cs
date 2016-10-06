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

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList);

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

        protected abstract void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);
    }
}