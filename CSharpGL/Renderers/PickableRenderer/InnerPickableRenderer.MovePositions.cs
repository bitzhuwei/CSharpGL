using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL
{
    partial class InnerPickableRenderer
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
        public void MovePositions(Point differenceOnScreen,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, IEnumerable<uint> positionIndexes)
        {
            this.positionBufferPtr.Bind();
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    var newWindowPos = new vec3(windowPos.x + differenceOnScreen.X,
                        windowPos.y + differenceOnScreen.Y, windowPos.z);
                    array[index] = glm.unProject(newWindowPos,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            this.positionBufferPtr.Unbind();
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
            this.positionBufferPtr.Bind();
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    var newWindowPos = new vec3(windowPos.x + differenceOnScreen.X,
                        windowPos.y + differenceOnScreen.Y, windowPos.z);
                    array[index] = glm.unProject(newWindowPos,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            this.positionBufferPtr.Unbind();
        }
    }
}