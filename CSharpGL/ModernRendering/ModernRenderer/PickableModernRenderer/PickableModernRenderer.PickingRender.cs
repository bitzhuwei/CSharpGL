using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableModernRenderer : IColorCodedPicking
    {

        private void ColorCodedPickingRender(RenderEventArgs arg, IndexBufferPtr temporaryIndexBufferPtr = null)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.PickingShaderProgram;

            // 绑定shader
            program.Bind();
            var picking = this as IColorCodedPicking;
            // TODO: use uint/int/float or ? use UniformUInt instead
            program.SetUniform("pickingBaseID", 
                temporaryIndexBufferPtr == null ? picking.PickingBaseID : 0u);
            pickingMVP.SetUniform(program);

            PickingSwitchesOn();

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

            PickingSwitchesOff();

            pickingMVP.ResetUniform(program);

            // 解绑shader
            program.Unbind();
        }

        private void PickingSwitchesOff()
        {
            foreach (var item in this.switchList4Picking)
            {
                item.Off();
            }
        }

        private void PickingSwitchesOn()
        {
            foreach (var item in this.switchList4Picking)
            {
                item.On();
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
