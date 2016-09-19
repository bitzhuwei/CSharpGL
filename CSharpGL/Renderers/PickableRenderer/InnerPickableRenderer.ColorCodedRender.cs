using System;

namespace CSharpGL
{
    partial class InnerPickableRenderer : IColorCodedPicking
    {
        private void ColorCodedRender(RenderEventArgs arg, IndexBufferPtr temporaryIndexBufferPtr = null)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.SetUniform("pickingBaseId",
                temporaryIndexBufferPtr == null ? (int)this.PickingBaseId : 0);
            UniformMat4 uniformmMVP4Picking = this.uniformmMVP4Picking;
            {
                mat4 projection = arg.Camera.GetProjectionMatrix();
                mat4 view = arg.Camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                uniformmMVP4Picking.Value = projection * view * model;
            }
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
                    polygonModeSwitch.Mode = PolygonMode.Point;
                    break;

                case GeometryType.Line:
                    polygonModeSwitch.Mode = PolygonMode.Line;
                    break;

                case GeometryType.Triangle:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                case GeometryType.Quad:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                case GeometryType.Polygon:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}