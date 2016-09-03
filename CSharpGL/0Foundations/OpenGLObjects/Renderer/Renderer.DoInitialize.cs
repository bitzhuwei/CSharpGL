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
            // init shader program
            var program = new ShaderProgram();
            var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
            program.Initialize(shaders);
            this.Program = program;
            foreach (var item in shaders) { item.Delete(); }

            // init property buffer objects
            var propertyBufferPtrs = new PropertyBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = this.model.GetProperty(
                    item.NameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", this.model)); }
                propertyBufferPtrs[index++] = bufferPtr;
            }

            this.propertyBufferPtrs = propertyBufferPtrs;
            this.indexBufferPtr = this.model.GetIndex();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = this.indexBufferPtr as OneIndexBufferPtr;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr);
                this.switchList.Add(glSwitch);
            }
        }
    }
}