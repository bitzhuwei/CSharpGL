using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal abstract class PrimitiveRecognizer
    {
        /// <summary>
        /// 识别出以<paramref name="singleNodeVertexId"/>结尾的图元。
        /// <para>Recognize the primitive whose indexes end with <paramref name="singleNodeVertexId"/>.</para>
        /// </summary>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public List<RecognizedPrimitiveInfo> Recognize(
         uint singleNodeVertexId, DrawElementsCmd cmd)
        {
            List<RecognizedPrimitiveInfo> primitiveInfoList;

            uint pri = cmd.PrimitiveRestartIndex;
            if (pri == byte.MaxValue || pri == ushort.MaxValue || pri == uint.MaxValue)
            {
                primitiveInfoList = Recognize(singleNodeVertexId, cmd, pri);
            }
            else
            {
                primitiveInfoList = new List<RecognizedPrimitiveInfo>();
                switch (cmd.IndexBufferObject.ElementType)
                {
                    case IndexBufferElementType.UByte:
                        RecognizeByte(singleNodeVertexId, cmd, primitiveInfoList);
                        break;

                    case IndexBufferElementType.UShort:
                        RecognizeUShort(singleNodeVertexId, cmd, primitiveInfoList);
                        break;

                    case IndexBufferElementType.UInt:
                        RecognizeUInt(singleNodeVertexId, cmd, primitiveInfoList);
                        break;

                    default:
                        throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
                }
            }

            return primitiveInfoList;
        }

        protected abstract void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList);

        protected abstract void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList);

        /// <summary>
        /// 识别出以<paramref name="singleNodeVertexId"/>结尾的图元。
        /// <para>识别过程中要考虑排除PrimitiveRestartIndex</para>
        /// </summary>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="cmd"></param>
        /// <param name="primitiveRestartIndex"></param>
        /// <returns></returns>
        protected List<RecognizedPrimitiveInfo> Recognize(
            uint singleNodeVertexId, DrawElementsCmd cmd, uint primitiveRestartIndex)
        {
            var primitiveInfoList = new List<RecognizedPrimitiveInfo>();
            if (singleNodeVertexId != primitiveRestartIndex)
            {
                switch (cmd.IndexBufferObject.ElementType)
                {
                    case IndexBufferElementType.UByte:
                        RecognizeByte(singleNodeVertexId, cmd, primitiveInfoList, primitiveRestartIndex);
                        break;

                    case IndexBufferElementType.UShort:
                        RecognizeUShort(singleNodeVertexId, cmd, primitiveInfoList, primitiveRestartIndex);
                        break;

                    case IndexBufferElementType.UInt:
                        RecognizeUInt(singleNodeVertexId, cmd, primitiveInfoList, primitiveRestartIndex);
                        break;

                    default:
                        throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
                }
            }

            return primitiveInfoList;
        }

        protected abstract void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);

        protected abstract void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex);
    }
}