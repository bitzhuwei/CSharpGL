using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CSharpGL
{
    public abstract partial class PickableNode
    {
        /// <summary>
        /// Move vertexes' position accroding to <paramref name="modelSpacePositionDiff"/>.
        /// <para>根据<paramref name="modelSpacePositionDiff"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="modelSpacePositionDiff"></param>
        /// <param name="positionIndexes"></param>
        /// <returns></returns>
        public vec3[] MovePositions(vec3 modelSpacePositionDiff, params uint[] positionIndexes)
        {
            return this.MovePositions(modelSpacePositionDiff, positionIndexes as IEnumerable<uint>);
        }

        /// <summary>
        /// Move vertexes' position accroding to <paramref name="modelSpacePositionDiff"/>.
        /// <para>根据<paramref name="modelSpacePositionDiff"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="modelSpacePositionDiff"></param>
        /// <param name="positionIndexes"></param>
        /// <returns></returns>
        public vec3[] MovePositions(vec3 modelSpacePositionDiff, IEnumerable<uint> positionIndexes)
        {
            var buffers = this.PickingRenderMethod.PositionBuffers;
            IEnumerable<IndexesInBuffer> workItems = buffers.GetWorkItems(positionIndexes);

            var list = new List<vec3>();
            foreach (var item in workItems)
            {
                VertexBuffer buffer = buffers[item.whichBuffer];
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadWrite);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    foreach (var indexInBuffer in item.indexesInBuffer)
                    {
                        array[indexInBuffer] = array[indexInBuffer] + modelSpacePositionDiff;
                        list.Add(array[indexInBuffer]);
                    }
                }
                buffer.UnmapBuffer();
            }

            return list.ToArray();
        }
    }
}
