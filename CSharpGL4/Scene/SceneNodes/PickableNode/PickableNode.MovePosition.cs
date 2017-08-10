using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace CSharpGL
{
    public abstract partial class PickableNode
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
        /// <returns></returns>
        public IList<vec3> MovePositions(ivec2 differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, IEnumerable<uint> positionIndexes)
        {
            var list = new List<vec3>();

            VertexBuffer buffer = this.PickingRenderUnit.PositionBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                mat4 modelMatrix = this.GetModelMatrix();
                mat4 modelViewMatrix = viewMatrix * modelMatrix;
                var array = (vec3*)pointer.ToPointer();
                foreach (uint index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index], modelViewMatrix, projectionMatrix, viewport);
                    var newWindowPos = new vec3(
                        windowPos.x + differenceOnScreen.x,
                        windowPos.y + differenceOnScreen.y,
                        windowPos.z);
                    var result = glm.unProject(newWindowPos, modelViewMatrix, projectionMatrix, viewport);
                    array[index] = result;
                    list.Add(result);
                }
            }
            buffer.UnmapBuffer();

            return list;
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
        /// <returns></returns>
        public vec3[] MovePositions(ivec2 differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, params uint[] positionIndexes)
        {
            var list = new vec3[positionIndexes.Length];

            VertexBuffer buffer = this.PickingRenderUnit.PositionBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadWrite);
            unsafe
            {
                mat4 modelMatrix = this.GetModelMatrix();
                mat4 modelViewMatrix = viewMatrix * modelMatrix;
                var array = (vec3*)pointer.ToPointer();
                foreach (uint index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index], modelViewMatrix, projectionMatrix, viewport);
                    var newWindowPos = new vec3(
                        windowPos.x + differenceOnScreen.x,
                        windowPos.y + differenceOnScreen.y,
                        windowPos.z);
                    vec3 result = glm.unProject(newWindowPos, modelViewMatrix, projectionMatrix, viewport);
                    array[index] = result;
                    list[index] = result;
                }
            }
            buffer.UnmapBuffer();

            return list;
        }
    }
}
