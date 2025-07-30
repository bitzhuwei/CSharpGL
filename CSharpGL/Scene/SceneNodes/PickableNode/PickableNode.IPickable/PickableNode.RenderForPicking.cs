﻿using System;
using System.ComponentModel;
namespace CSharpGL {
    public partial class PickableNode {
        private PolygonModeSwitch polygonModeState = new PolygonModeSwitch(PolygonMode.Fill);
        private LineWidthSwitch lineWidthState = new LineWidthSwitch(10);
        private PointSizeSwitch pointSizeState = new PointSizeSwitch(10);

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        #region IPickable 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public virtual void RenderForPicking(PickingEventArgs arg) {
            this.RenderForPicking(arg, null);
        }

        #endregion

    }
}