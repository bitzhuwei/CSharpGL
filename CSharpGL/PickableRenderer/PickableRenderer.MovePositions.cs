
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer
    {

        /// <summary>
        /// 根据<paramref name="differenceOnScreen"/>来修改指定索引处的顶点位置。
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
        /// 根据<paramref name="differenceOnScreen"/>来修改指定索引处的顶点位置。
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
