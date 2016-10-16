using System;

namespace CSharpGL
{
    partial class InnerPickableRenderer : IColorCodedPicking
    {
        /// <summary>
        /// render with specified index buffer.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="temporaryIndexBufferPtr"></param>
        private void Render4Picking(RenderEventArgs arg, IndexBufferPtr temporaryIndexBufferPtr)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.SetUniform("pickingBaseId", 0);
            UniformMat4 uniformmMVP4Picking = this.uniformmMVP4Picking;
            {
                mat4 projection = arg.Camera.GetProjectionMatrix();
                mat4 view = arg.Camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                uniformmMVP4Picking.Value = projection * view * model;
            }
            uniformmMVP4Picking.SetUniform(program);

            PickingSwitchesOn();
            GLSwitch primitiveRestartIndexSwitch = null;
            var oneIndexBufferPtr = temporaryIndexBufferPtr as OneIndexBufferPtr;
            if (oneIndexBufferPtr != null)
            {
                primitiveRestartIndexSwitch = new PrimitiveRestartSwitch(oneIndexBufferPtr);
                primitiveRestartIndexSwitch.On();
                this.vertexArrayObject.Render(arg, program, temporaryIndexBufferPtr);
                primitiveRestartIndexSwitch.Off();
            }
            else
            {
                this.vertexArrayObject.Render(arg, program, temporaryIndexBufferPtr);
            }
            PickingSwitchesOff();

            //if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); }

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

        private void UpdatePolygonMode(PickingGeometryType geometryType)
        {
            switch (geometryType)
            {
                case PickingGeometryType.None:
                    // whatever it is.
                    polygonModeSwitch.Mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Point:
                    polygonModeSwitch.Mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Line:
                    polygonModeSwitch.Mode = PolygonMode.Line;
                    break;

                case PickingGeometryType.Triangle:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Quad:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Polygon:
                    polygonModeSwitch.Mode = PolygonMode.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}