using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    partial class InnerPickableRenderer : IColorCodedPicking
    {

        private void ColorCodedRender(RenderEventArgs arg, IndexBufferPtr temporaryIndexBufferPtr = null)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.ShaderProgram;

            // 绑定shader
            program.Bind();
            program.SetUniform("pickingBaseId",
                temporaryIndexBufferPtr == null ? (int)this.PickingBaseId : 0);
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

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.indexBufferPtr, this.positionBufferPtr);
                vertexArrayObject.Create(arg, program);

                this.vertexArrayObject = vertexArrayObject;
            }
            //else
            {
                this.vertexArrayObject.Render(arg, program, temporaryIndexBufferPtr);
            }

            if (oneIndexBufferPtr != null)
            {
                primitiveRestartIndexSwitch.Off();
            }
            PickingSwitchesOff();

            if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); }


            // 解绑shader
            program.Unbind();
        }

        protected void PickingSwitchesOff()
        {
            int count = this.switchList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }
        }

        protected void PickingSwitchesOn()
        {
            int count = this.switchList.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList[i].On();
            }
        }

        private void UpdatePolygonMode(GeometryType geometryType)
        {
            switch (geometryType)
            {
                case GeometryType.Point:
                    polygonModeSwitch.Mode = PolygonModes.Points;
                    break;
                case GeometryType.Line:
                    polygonModeSwitch.Mode = PolygonModes.Lines;
                    break;
                case GeometryType.Triangle:
                    polygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Quad:
                    polygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Polygon:
                    polygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
