using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class __VeretxBufferArrayHelper
    {
        /// <summary>
        /// Which index in which buffer?
        /// </summary>
        /// <param name="buffers"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, IndexInBuffer>> GetWorkItems(this GLBuffer[] buffers, IEnumerable<uint> indexes)
        {
            var counts = new uint[buffers.Length + 1];
            for (int i = 1; i < counts.Length; i++)
            {
                // counts:  [0]------------[1]------------[2]-----------[3]
                // buffers:     buffers[0]     buffers[1]     buffer[2]
                counts[i] = counts[i - 1] + (uint)buffers[i - 1].Length;
            }

            var updateList = new List<IndexInBuffer>();
            foreach (var index in indexes)
            {
                var dealt = false;
                for (int j = 1; j < counts.Length; j++)
                {
                    if (index < counts[j])
                    {
                        updateList.Add(new IndexInBuffer(j - 1, index - counts[j - 1]));
                        dealt = true;
                        break;
                    }
                }

                if (!dealt) { throw new ArgumentOutOfRangeException(); }
            }

            var workItems = (from item in updateList
                             group item by item.whichBuffer into g
                             select g);//.ToList();

            return workItems;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IndexInBuffer
    {
        /// <summary>
        /// which buffer.
        /// </summary>
        public int whichBuffer;

        /// <summary>
        /// index in 'whichBuffer'.
        /// </summary>
        public uint indexInBuffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whichBuffer"></param>
        /// <param name="indexInBuffer"></param>
        public IndexInBuffer(int whichBuffer, uint indexInBuffer)
        {
            this.whichBuffer = whichBuffer;
            this.indexInBuffer = indexInBuffer;
        }
    }
}
