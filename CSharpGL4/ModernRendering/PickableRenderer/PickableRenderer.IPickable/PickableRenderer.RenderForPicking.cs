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
            this.RenderForPicking(arg, null);
        }

        #endregion


    }
}