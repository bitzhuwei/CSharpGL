
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    partial class InnerPickableRenderer
    {

        /// <summary>
        /// 根据<paramref name="differenceOnWindow"/>来修改指定索引处的顶点位置。
        /// </summary>
        /// <param name="differenceOnWindow"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewport"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(Point differenceOnWindow,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, IEnumerable<uint> positionIndexes)
        {
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    vec3 newWindowPos = new vec3(windowPos.x + differenceOnWindow.X,
                        windowPos.y + differenceOnWindow.Y, windowPos.z);
                    array[index] = glm.unProject(newWindowPos,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// 根据<paramref name="differenceOnWindow"/>来修改指定索引处的顶点位置。
        /// </summary>
        /// <param name="differenceOnWindow"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewport"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(Point differenceOnWindow,
            mat4 viewMatrix, mat4 projectionMatrix, vec4 viewport, params uint[] positionIndexes)
        {
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 windowPos = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    vec3 newWindowPos = new vec3(windowPos.x + differenceOnWindow.X,
                        windowPos.y + differenceOnWindow.Y, windowPos.z);
                    array[index] = glm.unProject(newWindowPos,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
