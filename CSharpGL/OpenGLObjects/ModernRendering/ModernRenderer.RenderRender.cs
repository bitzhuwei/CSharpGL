using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer 
    {
       
        private void RenderRender(RenderEventArgs e)
        {
            ShaderProgram program = this.shaderProgram;

            // 绑定shader
            program.Bind();

            var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            foreach (var item in updatedUniforms) { item.SetUniform(program); }

            foreach (var item in switchList) { item.On(); }

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.indexBufferPtr, this.propertyBufferPtrs);
                vertexArrayObject.Create(e, program);

                this.vertexArrayObject = vertexArrayObject;
            }
            //else
            {
                this.vertexArrayObject.Render(e, program);
            }

            foreach (var item in switchList) { item.Off(); }

            foreach (var item in updatedUniforms) { item.ResetUniform(program); item.Updated = false; }

            // 解绑shader
            program.Unbind();
        }

    }
}
