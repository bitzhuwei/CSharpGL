using System;
using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {

        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Fill);
        private LineWidthState lineWidthState = new LineWidthState(LineWidthState.max);
        private PointSizeState pointSizeState = new PointSizeState(PointSizeState.max);

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        #region IPickable 成员

        public virtual void RenderForPicking(PickEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.polygonModeState.Mode = UpdatePolygonMode(arg.GeometryType);

            ShaderProgram program = this.PickProgram;

            // 绑定shader
            program.Bind();
            program.glUniform("pickingBaseId", (int)(((IPickable)this).PickingBaseId));
            {
                mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
                mat4 view = arg.Scene.Camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                program.glUniform("MVP", projection * view * model);
            }

            this.polygonModeState.On();
            this.lineWidthState.On();
            this.pointSizeState.On();

            this.pickVertexArrayObject.Render(new RenderEventArgs(arg.Scene), program);

            this.pointSizeState.Off();
            this.lineWidthState.Off();
            this.polygonModeState.Off();

            // 解绑shader
            program.Unbind();
        }

        #endregion


        private PolygonMode UpdatePolygonMode(PickingGeometryType geometryType)
        {
            PolygonMode mode;
            switch (geometryType)
            {
                case PickingGeometryType.None:
                    // whatever it is.
                    mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Point:
                    mode = PolygonMode.Point;
                    break;

                case PickingGeometryType.Line:
                    mode = PolygonMode.Line;
                    break;

                case PickingGeometryType.Triangle:
                    mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Quad:
                    mode = PolygonMode.Fill;
                    break;

                case PickingGeometryType.Polygon:
                    mode = PolygonMode.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return mode;
        }

    }
}