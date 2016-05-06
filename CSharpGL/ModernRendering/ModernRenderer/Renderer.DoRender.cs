using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class Renderer
    {

        protected override void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.shaderProgram;
            if (program == null) { return; }

            // 绑定shader
            program.Bind();

            var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            foreach (var item in updatedUniforms) { item.SetUniform(program); }

            int count = this.switchList.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList[i].On();
            }

            IndexBufferPtr indexBufferPtr = this.GetIndexBufferPtr();
            if (this.vertexArrayObject == null)
            {
                PropertyBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
                if (indexBufferPtr != null && propertyBufferPtrs != null)
                {
                    var vertexArrayObject = new VertexArrayObject(
                        indexBufferPtr, propertyBufferPtrs);
                    vertexArrayObject.Create(arg, program);

                    this.vertexArrayObject = vertexArrayObject;
                }
            }
            {
                VertexArrayObject vertexArrayObject = this.vertexArrayObject;
                if (vertexArrayObject != null)
                {
                    if (vertexArrayObject.IndexBufferPtr != indexBufferPtr)
                    { vertexArrayObject.IndexBufferPtr = indexBufferPtr; }
                    vertexArrayObject.Render(arg, program);
                }
            }

            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }

            foreach (var item in updatedUniforms) { item.ResetUniform(program); item.Updated = false; }

            // 解绑shader
            program.Unbind();
        }

        internal abstract IndexBufferPtr GetIndexBufferPtr();
    }
}
