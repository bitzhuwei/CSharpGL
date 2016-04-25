using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class ModernRenderer
    {
        /// <summary>
        /// 根据<paramref name="difference"/>来修改指定索引处的顶点位置。
        /// </summary>
        /// <param name="difference"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(vec3 difference, uint[] positionIndexes)
        {
            if (difference == new vec3(0, 0, 0)) { return; }
            if (positionIndexes == null) { return; }
            if (positionIndexes.Length == 0) { return; }

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                foreach (var index in positionIndexes)
                {
                    array[index] = array[index] + difference;
                }
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
