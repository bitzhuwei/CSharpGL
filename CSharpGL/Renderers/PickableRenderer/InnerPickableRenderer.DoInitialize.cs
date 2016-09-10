using System;
using System.Linq;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            PropertyBufferPtr positionBufferPtr = null;
            IBufferable bufferable = this.model;
            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = bufferable.GetProperty(
                    item.NameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }

                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    positionBufferPtr = new PropertyBufferPtr(
                        "in_Position",// in_Postion same with in the PickingShader.vert shader
                        bufferPtr.BufferId,
                        bufferPtr.DataSize,
                        bufferPtr.DataType,
                        bufferPtr.Length,
                        bufferPtr.ByteLength);
                    break;
                }
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBufferPtr == null || positionBufferPtr.DataSize != 3 || positionBufferPtr.DataType != OpenGL.GL_FLOAT)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            this.positionBufferPtr = positionBufferPtr;
        }
    }
}