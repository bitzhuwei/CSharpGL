using System;
using System.Linq;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoInitialize()
        {
            // init shader program
            ShaderProgram program = PickingShaderHelper.GetPickingShaderProgram();

            // init property buffer objects
            IBufferable bufferable = this.model;
            var propertyBufferPtrs = new PropertyBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = bufferable.GetProperty(
                    item.NameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }
                propertyBufferPtrs[index++] = bufferPtr;

                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    this.positionBufferPtr = new PropertyBufferPtr(
                        "in_Position",// in_Postion same with in the PickingShader.vert shader
                        bufferPtr.BufferId,
                        bufferPtr.DataSize,
                        bufferPtr.DataType,
                        bufferPtr.Length,
                        bufferPtr.ByteLength);
                }
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (this.positionBufferPtr.DataSize != 3 || this.positionBufferPtr.DataType != OpenGL.GL_FLOAT)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            // init index buffer.
            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = this.indexBufferPtr as OneIndexBufferPtr;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBufferPtr, positionBufferPtr);
            vertexArrayObject.Create(program);

            // set fields.
            this.Program = program;
            this.propertyBufferPtrs = propertyBufferPtrs;
            this.indexBufferPtr = indexBufferPtr;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}