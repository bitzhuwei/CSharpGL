using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LegacyPointNode : SceneNodeBase, IRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 Vertex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float PointSize
        {
            get { return this.pointSizeState.PointSize; }
            set { this.pointSizeState.PointSize = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public LegacyPointNode()
        {
            this.Color = new vec3(1, 1, 1);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();
        private PointSizeSwitch pointSizeState = new PointSizeSwitch(5.0f);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            this.polygonOffsetState.On();
            this.pointSizeState.On();

            GL.Instance.Begin((uint)DrawMode.Points);
            GL.Instance.Color3f(this.Color.x, this.Color.y, this.Color.z);
            GL.Instance.Vertex3f(this.Vertex.x, this.Vertex.y, this.Vertex.z);
            GL.Instance.End();

            this.pointSizeState.Off();
            this.polygonOffsetState.Off();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
