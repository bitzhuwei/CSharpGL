using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class HighlightRenderer
    {
        /// <summary>
        /// <see cref="OneIndexBuffer"/>实际存在多少个元素。
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
            VertexAttributeBuffer positionBuffer = null;
            IBufferable model = this.Model;
            VertexAttributeBuffer[] vertexAttributeBuffers;
            {
                var list = new List<VertexAttributeBuffer>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexAttributeBuffer buffer = model.GetVertexAttributeBuffer(
                               item.NameInIBufferable, item.VarNameInShader);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    if (item.NameInIBufferable == positionNameInIBufferable)
                    {
                        positionBuffer = new VertexAttributeBuffer(
                            "in_Position",// in_Postion same with in the PickingShader.vert shader
                            buffer.BufferId,
                            buffer.Config,
                            buffer.Length,
                            buffer.ByteLength);
                    }
                    list.Add(buffer);
                }
                vertexAttributeBuffers = list.ToArray();
            }

            // init index buffer
            OneIndexBuffer indexBuffer;
            {
                var mode = DrawMode.Points;//any mode is OK as we'll update it later in other place.
                indexBuffer = OneIndexBuffer.Create(BufferUsage.StaticDraw, mode, IndexElementType.UInt, positionBuffer.ByteLength / (positionBuffer.DataSize * positionBuffer.DataTypeByteLength));
                this.maxElementCount = indexBuffer.ElementCount;
                indexBuffer.ElementCount = 0;// 高亮0个图元
                // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
                GLSwitch glSwitch = new PrimitiveRestartSwitch(indexBuffer.Type);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBuffer, vertexAttributeBuffers);
            vertexArrayObject.Initialize(program);

            // sets fields.
            this.Program = program;
            this.vertexAttributeBuffers = vertexAttributeBuffers;
            this.indexBuffer = indexBuffer;
            this.vertexArrayObject = vertexArrayObject;

            this.positionBuffer = positionBuffer;
        }
    }
}