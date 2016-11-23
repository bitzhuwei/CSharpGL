using System;

namespace CSharpGL
{
    partial class InnerPickableRenderer : IPickable
    {
        /// <summary>
        /// render with specified index buffer.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="temporaryIndexBuffer"></param>
        private void Render4Picking(RenderEventArgs arg, IndexBuffer temporaryIndexBuffer)
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
                mat4 model = this.GetModelMatrix().Value;
                uniformmMVP4Picking.Value = projection * view * model;
            }
            uniformmMVP4Picking.SetUniform(program);

            PickingStateesOn();
            var oneIndexBuffer = temporaryIndexBuffer as OneIndexBuffer;
            if (oneIndexBuffer != null)
            {
                PrimitiveRestartState glState = this.GetPrimitiveRestartState(oneIndexBuffer);
                glState.On();
                this.vertexArrayObject.Render(arg, program, temporaryIndexBuffer);
                glState.Off();
            }
            else
            {
                this.vertexArrayObject.Render(arg, program, temporaryIndexBuffer);
            }
            PickingStateesOff();

            //if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); }

            // 解绑shader
            program.Unbind();
        }

        protected void PickingStateesOff()
        {
            int count = this.stateList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.stateList[i].Off();
            }
        }

        protected void PickingStateesOn()
        {
            int count = this.stateList.Count;
            for (int i = 0; i < count; i++)
            {
                this.stateList[i].On();
            }
        }

        private void UpdatePolygonMode(PickingGeometryType geometryType)
        {
            switch (geometryType)
            {
                case PickingGeometryType.None:
                    // whatever it is.
                    polygonModeState.Mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Point:
                    polygonModeState.Mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Line:
                    polygonModeState.Mode = PolygonMode.Line;
                    break;

                case PickingGeometryType.Triangle:
                    polygonModeState.Mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Quad:
                    polygonModeState.Mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Polygon:
                    polygonModeState.Mode = PolygonMode.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private PrimitiveRestartState ubyteRestartIndexState = null;
        private PrimitiveRestartState ushortRestartIndexState = null;
        private PrimitiveRestartState uintRestartIndexState = null;

        private PrimitiveRestartState GetPrimitiveRestartState(OneIndexBuffer indexBuffer)
        {
            PrimitiveRestartState result = null;
            switch (indexBuffer.ElementType)
            {
                case IndexBufferElementType.UByte:
                    if (this.ubyteRestartIndexState == null)
                    { this.ubyteRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.ubyteRestartIndexState;
                    break;

                case IndexBufferElementType.UShort:
                    if (this.ushortRestartIndexState == null)
                    { this.ushortRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.ushortRestartIndexState;
                    break;

                case IndexBufferElementType.UInt:
                    if (this.uintRestartIndexState == null)
                    { this.uintRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.uintRestartIndexState;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}