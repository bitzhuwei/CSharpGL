using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableModernRenderer : IColorCodedPicking
    {
        PolygonModeSwitch polygonModeSwitch4Picking = new PolygonModeSwitch();

        private void PickingRender(RenderEventArgs e)
        {
            UpdatePolygonMode(e.PickingGeometryType);

            ShaderProgram program = this.PickingShaderProgram;

            // 绑定shader
            program.Bind();
            var picking = this as IColorCodedPicking;
            // TODO: use uint/int/float or ? use UniformUInt instead
            program.SetUniform("pickingBaseID", picking.PickingBaseID);
            pickingMVP.SetUniform(program);

            foreach (var item in switchList) { item.On(); }
            this.polygonModeSwitch4Picking.On();

            if (this.vertexArrayObject4Picking == null)
            {
                var vertexArrayObject4Picking = new VertexArrayObject(
                    this.GetIndexBufferPtr(), this.positionBufferPtr);
                vertexArrayObject4Picking.Create(e, program);

                this.vertexArrayObject4Picking = vertexArrayObject4Picking;
            }
            //else
            {
                this.vertexArrayObject4Picking.Render(e, program);
            }

            this.polygonModeSwitch4Picking.Off();

            foreach (var item in switchList) { item.Off(); }

            pickingMVP.ResetUniform(program);

            // 解绑shader
            program.Unbind();
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
