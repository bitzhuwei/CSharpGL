using System;
using System.Collections.Generic;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderProgramProvider.GetShaderProgram();

            VertexShaderAttribute positionBuffer = null;
            IBufferable model = this.DataSource;
            {
                var list = new List<VertexShaderAttribute>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexBuffer buffer = model.GetVertexAttributeBuffer(
                     item.NameInIBufferable, item.VarNameInShader);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }

                    if (item.NameInIBufferable == this.PositionNameInIBufferable)
                    {
                        positionBuffer = new VertexShaderAttribute(buffer, item.VarNameInShader);
                        //positionBuffer.VarNameInVertexShader = "in_Position";// in_Postion same with in the PickingShader.vert shader
                        break;
                    }
                }
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBuffer == null || positionBuffer.Buffer.Config != VBOConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            // init index buffer.
            IndexBuffer indexBuffer = model.GetIndexBuffer();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBuffer as OneIndexBuffer;
            if (ptr != null)
            {
                GLState glState = new PrimitiveRestartState(ptr.ElementType);
                this.stateList.Add(glState);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBuffer, positionBuffer);
            vertexArrayObject.Initialize(program);

            // sets fields.
            this.Program = program;
            this.vertexShaderAttribute = new VertexShaderAttribute[] { positionBuffer };
            this.indexBuffer = indexBuffer;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}