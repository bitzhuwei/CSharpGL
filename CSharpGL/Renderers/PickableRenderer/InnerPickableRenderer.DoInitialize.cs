using System;
using System.Collections.Generic;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderCodes.CreateProgram();

            VertexAttributeBuffer positionBufferPtr = null;
            IBufferable model = this.Model;
            VertexAttributeBuffer[] vertexAttributeBufferPtrs;
            {
                var list = new List<VertexAttributeBuffer>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexAttributeBuffer bufferPtr = model.GetVertexAttributeBufferPtr(
                     item.NameInIBufferable, item.VarNameInShader);
                    if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }

                    if (item.NameInIBufferable == this.PositionNameInIBufferable)
                    {
                        positionBufferPtr = new VertexAttributeBuffer(
                            "in_Position",// in_Postion same with in the PickingShader.vert shader
                            bufferPtr.BufferId,
                            bufferPtr.Config,
                            bufferPtr.Length,
                            bufferPtr.ByteLength);
                        break;
                    }
                    list.Add(bufferPtr);
                }
                vertexAttributeBufferPtrs = list.ToArray();
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBufferPtr == null || positionBufferPtr.Config != VertexAttributeConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            // init index buffer.
            IndexBuffer indexBufferPtr = model.GetIndexBufferPtr();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBufferPtr as OneIndexBuffer;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr.Type);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBufferPtr, positionBufferPtr);
            vertexArrayObject.Initialize(program);

            // sets fields.
            this.Program = program;
            this.vertexAttributeBufferPtrs = new VertexAttributeBuffer[] { positionBufferPtr };
            this.indexBufferPtr = indexBufferPtr;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}