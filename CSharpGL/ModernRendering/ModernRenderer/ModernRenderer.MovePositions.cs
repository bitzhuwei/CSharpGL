
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class ModernRenderer
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

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 projected = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    vec3 newProjected = new vec3(projected.x + differenceOnScreen.X,
                        projected.y + differenceOnScreen.Y, projected.z);
                    array[index] = glm.unProject(newProjected,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
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

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    vec3 projected = glm.project(array[index],
                        viewMatrix, projectionMatrix, viewport);
                    vec3 newProjected = new vec3(projected.x + differenceOnScreen.X,
                        projected.y + differenceOnScreen.Y, projected.z);
                    array[index] = glm.unProject(newProjected,
                        viewMatrix, projectionMatrix, viewport);
                }
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
