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
        /// 根据<paramref name="differences"/>来修改指定索引处的顶点位置。
        /// </summary>
        /// <param name="differences"></param>
        /// <param name="positionIndexes"></param>
        public void MovePositions(vec3[] differences, uint[] positionIndexes)
        {
            if (positionIndexes == null) { return; }
            if (positionIndexes.Length == 0) { return; }

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                for (int i = 0; i < positionIndexes.Length; i++)
                {
                    array[positionIndexes[i]] = array[positionIndexes[i]] + differences[i];
                }
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
