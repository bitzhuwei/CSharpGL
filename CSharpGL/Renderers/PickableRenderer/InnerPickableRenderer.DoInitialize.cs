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

            VertexBuffer positionBuffer = null;
            IBufferable model = this.Model;
            VertexBuffer[] vertexAttributeBuffers;
            {
                var list = new List<VertexBuffer>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexBuffer buffer = model.GetVertexAttributeBuffer(
                     item.NameInIBufferable, item.VarNameInShader);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }

                    if (item.NameInIBufferable == this.PositionNameInIBufferable)
                    {
                        positionBuffer = new VertexBuffer(
                            "in_Position",// in_Postion same with in the PickingShader.vert shader
                            buffer.BufferId,
                            buffer.Config,
                            buffer.Length,
                            buffer.ByteLength);
                        break;
                    }
                    list.Add(buffer);
                }
                vertexAttributeBuffers = list.ToArray();
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBuffer == null || positionBuffer.Config != VBOConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            // init index buffer.
            IndexBuffer indexBuffer = model.GetIndexBuffer();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBuffer as OneIndexBuffer;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr.Type);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBuffer, positionBuffer);
            vertexArrayObject.Initialize(program);

            // sets fields.
            this.Program = program;
            this.vertexAttributeBuffers = new VertexBuffer[] { positionBuffer };
            this.indexBuffer = indexBuffer;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}