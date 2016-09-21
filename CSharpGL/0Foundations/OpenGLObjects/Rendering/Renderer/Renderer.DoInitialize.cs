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

            // init property buffer objects.
            IBufferable bufferable = this.Model;
            VertexAttributeBufferPtr[] propertyBufferPtrs;
            {
                var list = new List<VertexAttributeBufferPtr>();
                foreach (var item in this.attributeNameMap)
                {
                    VertexAttributeBufferPtr bufferPtr = bufferable.GetVertexAttributeBufferPtr(
                        item.NameInIBufferable, item.VarNameInShader);
                    if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }
                    list.Add(bufferPtr);
                }
                propertyBufferPtrs = list.ToArray();
            }

            // init index buffer.
            IndexBufferPtr indexBufferPtr = bufferable.GetIndexBufferPtr();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBufferPtr as OneIndexBufferPtr;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr);
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
        }
    }
}