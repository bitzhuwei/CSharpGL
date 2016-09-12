using System;
using System.Linq;

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
            ShaderProgram program = InitializeProgram();

            // init property buffer objects.
            IBufferable bufferable = this.model;
            var propertyBufferPtrs = new VertexAttributeBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                VertexAttributeBufferPtr bufferPtr = bufferable.GetProperty(
                    item.NameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }
                propertyBufferPtrs[index++] = bufferPtr;
            }

            // init index buffer.
            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();

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

        private ShaderProgram InitializeProgram()
        {
            var program = new ShaderProgram();
            var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
            program.Initialize(shaders);
            foreach (var item in shaders) { item.Delete(); }
            return program;
        }
    }
}