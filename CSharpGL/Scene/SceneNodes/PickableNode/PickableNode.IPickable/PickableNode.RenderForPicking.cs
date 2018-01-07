using System;
using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableNode
    {
        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Fill);
        private LineWidthState lineWidthState = new LineWidthState(LineWidthState.max);
        private PointSizeState pointSizeState = new PointSizeState(PointSizeState.max);

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        #region IPickable 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public virtual void RenderForPicking(PickingEventArgs arg)
        {
            this.RenderForPicking(arg, this.ControlMode, null);
        }

        #endregion

    }
}