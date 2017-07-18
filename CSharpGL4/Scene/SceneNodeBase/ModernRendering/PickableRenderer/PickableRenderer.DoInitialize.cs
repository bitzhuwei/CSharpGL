using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.renderProgramProvider.GetShaderProgram();
            ShaderProgram pickProgram = this.pickProgramProvider.GetShaderProgram();

            // init vertex attribute buffer objects.
            IBufferable model = this.DataSource;
            VertexBuffer positionBuffer = null;
            VertexShaderAttribute[] vertexAttributeBuffers;
            {
                var list = new List<VertexShaderAttribute>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexBuffer buffer = model.GetVertexAttributeBuffer(
                        item.NameInIBufferable, item.VarNameInShader);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    list.Add(new VertexShaderAttribute(buffer, item.VarNameInShader));

                    if (item.VarNameInShader == this.PositionNameInVertexShader)
                    {
                        positionBuffer = buffer;
                    }
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
                GLState glState = new PrimitiveRestartState(ptr.ElementType);
                this.stateList.Add(glState);

                this.picker = new OneIndexPicker(this);
            }
            else
            {
                this.picker = new ZeroIndexPicker(this);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBuffer, vertexAttributeBuffers);
            vertexArrayObject.Initialize(program);
            var pickingVAO = new VertexArrayObject(indexBuffer, new VertexShaderAttribute(positionBuffer, "in_Position"));
            pickingVAO.Initialize(pickProgram);

            // sets fields.
            this.RenderProgram = program;
            this.PickProgram = pickProgram;
            this.vertexShaderAttributes = vertexAttributeBuffers;
            this.positionBuffer = positionBuffer;
            this.indexBuffer = indexBuffer;
            this.vertexArrayObject = vertexArrayObject;
            this.pickVertexArrayObject = pickingVAO;
        }
    }
}