using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        /// Position buffer.
        /// </summary>
        public VertexAttributeBufferPtr PositionBufferPtr { get { return this.innerPickableRenderer.PositionBufferPtr; } }

        /// <summary>
        /// Move vertexes' position accroding to difference on screen.
        /// <para>根据<paramref name="differenceOnScreen"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="differenceOnScreen"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewport"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(Point differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, IEnumerable<uint> positionIndexes)
        {
            if (positionIndexes == null) { return; }
            if (positionIndexes.Count() == 0) { return; }

            this.innerPickableRenderer.MovePositions(differenceOnScreen, viewMatrix, projectionMatrix, viewport, positionIndexes);
        }

        /// <summary>
        /// Move vertexes' position accroding to difference on screen.
        /// <para>根据<paramref name="differenceOnScreen"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="differenceOnScreen"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewport"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(Point differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, params uint[] positionIndexes)
        {
            if (positionIndexes == null) { return; }
            if (positionIndexes.Length == 0) { return; }

            this.innerPickableRenderer.MovePositions(differenceOnScreen, viewMatrix, projectionMatrix, viewport, positionIndexes);
        }
    }
}