using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LegacyTriangleRenderer : SceneNodeBase, IRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 Vertex0 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Vertex1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Vertex2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Color0 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Color1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Color2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PolygonMode PolygonMode
        {
            get { return this.polygonModeState.Mode; }
            set { this.polygonModeState.Mode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LineWidth
        {
            get { return this.lineWidthState.LineWidth; }
            set { this.lineWidthState.LineWidth = value; }
        }

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
        public LegacyTriangleRenderer()
        {
            this.Color0 = new vec3(1, 1, 1);
            this.Color1 = new vec3(1, 1, 1);
            this.Color2 = new vec3(1, 1, 1);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        private GLState polygonOffsetState = new PolygonOffsetFillState();
        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Fill);
        private LineWidthState lineWidthState = new LineWidthState();
        private PointSizeState pointSizeState = new PointSizeState();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            this.polygonOffsetState.On();
            this.polygonModeState.On();
            this.lineWidthState.On();

            GL.Instance.Begin((uint)DrawMode.Triangles);
            GL.Instance.Color3f(this.Color0.x, this.Color0.y, this.Color0.z);
            GL.Instance.Vertex3f(this.Vertex0.x, this.Vertex0.y, this.Vertex0.z);
            GL.Instance.Color3f(this.Color1.x, this.Color1.y, this.Color1.z);
            GL.Instance.Vertex3f(this.Vertex1.x, this.Vertex1.y, this.Vertex1.z);
            GL.Instance.Color3f(this.Color2.x, this.Color2.y, this.Color2.z);
            GL.Instance.Vertex3f(this.Vertex2.x, this.Vertex2.y, this.Vertex2.z);
            GL.Instance.End();

            this.lineWidthState.Off();
            this.polygonModeState.Off();
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
