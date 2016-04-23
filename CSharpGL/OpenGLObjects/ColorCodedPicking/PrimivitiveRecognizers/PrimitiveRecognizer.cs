using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    abstract class PrimitiveRecognizer
    {
        /// <summary>
        /// 识别出以<see cref="lastVertexId"/>结尾的图元。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public abstract List<RecognizedPrimitiveIndex> Recognize(uint lastVertexId, IntPtr pointer, int length);

        /// <summary>
        /// 识别出以<see cref="lastVertexId"/>结尾的图元。
        /// <para>识别过程中要考虑排除PrimitiveRestartIndex</para>
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="pointer"></param>
        /// <param name="length"></param>
        /// <param name="primitiveRestartIndex"></param>
        /// <returns></returns>
        public abstract List<RecognizedPrimitiveIndex> Recognize(uint lastVertexId, IntPtr pointer, int length, uint primitiveRestartIndex);
    }

    class RecognizedPrimitiveIndex
    {
        public RecognizedPrimitiveIndex(uint lastIndexId, params uint[] indexIDs)
        {
            //if (indexIDs.Length == 0) { throw new ArgumentException(); }
            //if (indexIDs[indexIDs.Length - 1] != lastIndexId) { throw new ArgumentException(); }

            this.LastIndexID = lastIndexId;
            this.IndexIdList = new List<uint>();
            this.IndexIdList.AddRange(indexIDs);
        }

        public uint LastIndexID { get; set; }

        public List<uint> IndexIdList { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.IndexIdList.Count - 1; i++)
            {
                builder.Append(this.IndexIdList[i]); builder.Append(", ");
            }

            builder.Append(this.IndexIdList[this.IndexIdList.Count - 1]);
            builder.Append(" | ");
            builder.Append(LastIndexID);

            return builder.ToString();
        }
    }
}
