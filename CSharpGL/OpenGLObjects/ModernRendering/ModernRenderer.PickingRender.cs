using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer : IColorCodedPicking
    {

        private void PickingRender(RenderEventArgs e)
        {
            ShaderProgram program = this.PickingShaderProgram;

            // 绑定shader
            program.Bind();
            var picking = this as IColorCodedPicking;
            // TODO: use uint/int/float or ? use UniformUInt instead
            program.SetUniform("pickingBaseID", picking.PickingBaseID);
            pickingMVP.SetUniform(program);

            foreach (var item in switchList) { item.On(); }

            if (this.vertexArrayObject4Picking == null)
            {
                var vertexArrayObject4Picking = new VertexArrayObject(
                    this.indexBufferPtr, this.positionBufferPtr);
                vertexArrayObject4Picking.Create(e, program);

                this.vertexArrayObject4Picking = vertexArrayObject4Picking;
            }
            //else
            {
                this.vertexArrayObject4Picking.Render(e, program);
            }

            foreach (var item in switchList) { item.Off(); }

            pickingMVP.ResetUniform(program);

            // 解绑shader
            program.Unbind();
        }

    }
}
