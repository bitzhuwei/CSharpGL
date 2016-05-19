using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class Renderer
    {

        protected override void DoInitialize()
        {
            // init shader program
            ShaderProgram program = new ShaderProgram();
            var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
            program.Create(shaders);
            this.shaderProgram = program;
            foreach (var item in shaders) { item.Delete(); }

            // init property buffer objects
            var propertyBufferPtrs = new PropertyBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = this.bufferable.GetProperty(
                    item.nameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(); }
                propertyBufferPtrs[index++] = bufferPtr;
            }

            this.propertyBufferPtrs = propertyBufferPtrs;
            this.indexBufferPtr = this.bufferable.GetIndex();

        }

    }
}
