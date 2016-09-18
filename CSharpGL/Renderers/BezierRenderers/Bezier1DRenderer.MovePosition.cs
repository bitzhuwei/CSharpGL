using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL
{
    public partial class Bezier1DRenderer
    {

        /// <summary>
        /// Move vertexes' position accroding to difference on screen.
        /// <para>根据<paramref name="differenceOnScreen"/>来修改指定索引处的顶点位置。</para>
        /// </summary>
        /// <param name="differenceOnScreen"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewport"></param>
        /// <param name="positionIndexes"></param>
        public override void MovePositions(Point differenceOnScreen, mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, IEnumerable<uint> positionIndexes)
        {
            base.MovePositions(differenceOnScreen, viewMatrix, projectionMatrix, viewport, positionIndexes);

            UpdateEvaluator();
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
        public override void MovePositions(Point differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, params uint[] positionIndexes)
        {
            base.MovePositions(differenceOnScreen, viewMatrix, projectionMatrix, viewport, positionIndexes);

            UpdateEvaluator();
        }

        private void UpdateEvaluator()
        {
            IntPtr pointer = this.PositionBufferPtr.MapBuffer(MapBufferAccess.ReadOnly);
            int length = this.PositionBufferPtr.Length;
            var array = new UnmanagedArray<vec3>(length);
            unsafe
            {
                var header = (vec3*)array.Header.ToPointer();
                var bufferHeader = (vec3*)pointer.ToPointer();
                for (int i = 0; i < length; i++)
                {
                    header[i] = bufferHeader[i];
                }
            }
            this.Evaluator1DRenderer.Setup(array);
            array.Dispose();
            this.PositionBufferPtr.UnmapBuffer();
        }
    }
}