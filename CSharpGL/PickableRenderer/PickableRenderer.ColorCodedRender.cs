using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer : IColorCodedPicking
    {

        private void ColorCodedRender(RenderEventArgs arg, IndexBufferPtr temporaryIndexBufferPtr = null)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.PickingShaderProgram;

            // 绑定shader
            program.Bind();
            // TODO: use uint/int/float or ? use UniformUInt instead
            program.SetUniform("pickingBaseId",
                temporaryIndexBufferPtr == null ? this.PickingBaseId : 0u);
            UniformMat4 uniformmMVP4Picking = this.uniformmMVP4Picking;
            bool mvpUpdated = uniformmMVP4Picking.Updated;
            if (mvpUpdated) { uniformmMVP4Picking.SetUniform(program); }

            PickingSwitchesOn();
            GLSwitch primitiveRestartIndexSwitch = null;
            var oneIndexBufferPtr = temporaryIndexBufferPtr as OneIndexBufferPtr;
            if (oneIndexBufferPtr != null)
            {
                primitiveRestartIndexSwitch = new PrimitiveRestartSwitch(oneIndexBufferPtr);
                primitiveRestartIndexSwitch.On();
            }

            if (this.vertexArrayObject4Picking == null)
            {
                var vertexArrayObject4Picking = new VertexArrayObject(
                    this.GetIndexBufferPtr(), this.positionBufferPtr);
                vertexArrayObject4Picking.Create(arg, program);

                this.vertexArrayObject4Picking = vertexArrayObject4Picking;
            }
            //else
            {
                this.vertexArrayObject4Picking.Render(arg, program, temporaryIndexBufferPtr);
            }

            if (oneIndexBufferPtr != null)
            {
                primitiveRestartIndexSwitch.Off();
            }
            PickingSwitchesOff();

            if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); uniformmMVP4Picking.Updated = false; }


            // 解绑shader
            program.Unbind();
        }

        protected void PickingSwitchesOff()
        {
            int count = this.switchList4Picking.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList4Picking[i].Off();
            }
        }

        protected void PickingSwitchesOn()
        {
            int count = this.switchList4Picking.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList4Picking[i].On();
            }
        }

        private void UpdatePolygonMode(GeometryType geometryType)
        {
            switch (geometryType)
            {
                case GeometryType.Point:
                    polygonModeSwitch4Picking.Mode = PolygonModes.Points;
                    break;
                case GeometryType.Line:
                    polygonModeSwitch4Picking.Mode = PolygonModes.Lines;
                    break;
                case GeometryType.Triangle:
                    polygonModeSwitch4Picking.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Quad:
                    polygonModeSwitch4Picking.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Polygon:
                    polygonModeSwitch4Picking.Mode = PolygonModes.Filled;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
