using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer
    {

        protected override void DoRender(RenderEventArgs e)
        {
            ShaderProgram program = this.shaderProgram;
            if (program == null) { return; }

            // 绑定shader
            program.Bind();

            var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            foreach (var item in updatedUniforms) { item.SetUniform(program); }

            SwitchesOn();

            IndexBufferPtr indexBufferPtr = this.GetIndexBufferPtr();
            if (this.vertexArrayObject == null)
            {
                PropertyBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
                if (indexBufferPtr != null && propertyBufferPtrs != null)
                {
                    var vertexArrayObject = new VertexArrayObject(
                        indexBufferPtr, propertyBufferPtrs);
                    vertexArrayObject.Create(e, program);

                    this.vertexArrayObject = vertexArrayObject;
                }
            }
            {
                VertexArrayObject vertexArrayObject = this.vertexArrayObject;
                if (vertexArrayObject != null)
                {
                    if (vertexArrayObject.IndexBufferPtr != indexBufferPtr)
                    { vertexArrayObject.IndexBufferPtr = indexBufferPtr; }
                    vertexArrayObject.Render(e, program);
                }
            }

            SwitchesOff();

            foreach (var item in updatedUniforms) { item.ResetUniform(program); item.Updated = false; }

            // 解绑shader
            program.Unbind();
        }

        protected void SwitchesOff()
        {
            foreach (var item in switchList) { item.Off(); }
        }

        protected void SwitchesOn()
        {
            foreach (var item in switchList) { item.On(); }
        }

        internal abstract IndexBufferPtr GetIndexBufferPtr();
    }
}
