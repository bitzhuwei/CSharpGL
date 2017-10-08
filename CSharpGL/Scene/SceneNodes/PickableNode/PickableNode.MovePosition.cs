using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public IList<vec3> MovePositions(vec3 modelSpacePositionDiff, IEnumerable<uint> positionIndexes)
        {
            var list = new List<vec3>();

            VertexBuffer buffer = this.PickingRenderUnit.PositionBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (uint index in positionIndexes)
                {
                    array[index] = array[index] + modelSpacePositionDiff;
                    list.Add(array[index]);
                }
            }
            buffer.UnmapBuffer();

            return list;
        }

        /// <summary>
        /// Move vertexes' position accroding to <paramref name="modelSpacePositionDiff"/>.
        /// <para>根据<paramref name="modelSpacePositionDiff"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="modelSpacePositionDiff"></param>
        /// <param name="positionIndexes"></param>
        /// <returns></returns>
        public vec3[] MovePositions(vec3 modelSpacePositionDiff, params uint[] positionIndexes)
        {
            var list = new vec3[positionIndexes.Length];

            VertexBuffer buffer = this.PickingRenderUnit.PositionBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                int t = 0;
                foreach (uint index in positionIndexes)
                {
                    array[index] = array[index] + modelSpacePositionDiff;
                    list[t++] = array[index];
                }
            }
            buffer.UnmapBuffer();

            return list;
        }
    }
}
