using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    abstract class PrimitiveRecognizer
    {
        public abstract List<RecognizedPrimitiveIndex> Recognize(uint lastVertexId, IntPtr pointer, int length);

        public abstract List<RecognizedPrimitiveIndex> Recognize(uint lastVertexId, IntPtr pointer, int length, uint primitiveRestartIndex);
    }

    class RecognizedPrimitiveIndex
    {
        public RecognizedPrimitiveIndex(uint lastIndexID, params uint[] indexIDs)
        {
            //if (indexIDs.Length == 0) { throw new ArgumentException(); }
            //if (indexIDs[indexIDs.Length - 1] != lastIndexID) { throw new ArgumentException(); }

            this.LastIndexID = lastIndexID;
            this.IndexIDList = new List<uint>();
            this.IndexIDList.AddRange(indexIDs);
        }

        public uint LastIndexID { get; set; }

        public List<uint> IndexIDList { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.IndexIDList.Count - 1; i++)
            {
                builder.Append(this.IndexIDList[i]); builder.Append(", ");
            }

            builder.Append(this.IndexIDList[this.IndexIDList.Count - 1]);
            builder.Append(" | ");
            builder.Append(LastIndexID);

            return builder.ToString();
        }
    }
}
