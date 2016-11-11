using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderCodes.CreateProgram();

            // init vertex attribute buffer objects.
            IBufferable model = this.Model;
            VertexAttributeBuffer[] vertexAttributeBuffers;
            {
                var list = new List<VertexAttributeBuffer>();
                foreach (AttributeMap.NamePair item in this.attributeMap)
                {
                    VertexAttributeBuffer buffer = model.GetVertexAttributeBuffer(
                        item.NameInIBufferable, item.VarNameInShader);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    list.Add(buffer);
                }
                vertexAttributeBuffers = list.ToArray();
            }

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
            var vertexArrayObject = new VertexArrayObject(indexBuffer, vertexAttributeBuffers);
            vertexArrayObject.Initialize(program);

            // sets fields.
            this.Program = program;
            this.vertexAttributeBuffers = vertexAttributeBuffers;
            this.indexBuffer = indexBuffer;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}