using System;
using System.Linq;

namespace CSharpGL
{
    public partial class HighlightRenderer
    {
        /// <summary>
        /// <see cref="OneIndexBufferPtr"/>实际存在多少个元素。
        /// </summary>
        protected int maxElementCount = 0;

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderCodes.CreateProgram();

            // init property buffer objects.
            IBufferable bufferable = this.model;
            var propertyBufferPtrs = new VertexAttributeBufferPtr[propertyNameMap.Count()];
            VertexAttributeBufferPtr positionBufferPtr = null;
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                VertexAttributeBufferPtr bufferPtr = bufferable.GetProperty(
                    item.NameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }
                propertyBufferPtrs[index++] = bufferPtr;
                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    positionBufferPtr = new VertexAttributeBufferPtr(
                        "in_Position",// in_Postion same with in the PickingShader.vert shader
                        bufferPtr.BufferId,
                        bufferPtr.Config,
                        bufferPtr.Length,
                        bufferPtr.ByteLength,
                        0);
                }
            }

            // init index buffer
            OneIndexBufferPtr indexBufferPtr;
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UnsignedInt,
                     DrawMode.Points, // any mode is OK as we'll update it later in other place.
                     BufferUsage.DynamicDraw))
                {
                    buffer.Create(positionBufferPtr.ByteLength / (positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength));
                    indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
                }
                this.maxElementCount = indexBufferPtr.ElementCount;
                indexBufferPtr.ElementCount = 0;// 高亮0个图元
                // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
                GLSwitch glSwitch = new PrimitiveRestartSwitch(indexBufferPtr);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBufferPtr, propertyBufferPtrs);
            vertexArrayObject.Create(program);

            // sets fields.
            this.Program = program;
            this.propertyBufferPtrs = propertyBufferPtrs;
            this.indexBufferPtr = indexBufferPtr;
            this.vertexArrayObject = vertexArrayObject;

            this.positionBufferPtr = positionBufferPtr;
        }
    }
}