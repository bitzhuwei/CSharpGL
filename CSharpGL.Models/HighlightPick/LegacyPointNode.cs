using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class LegacyPointNode : SceneNodeBase, IRenderable {
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
        public float PointSize {
            get { return this.pointSizeState.pointSize; }
            set { this.pointSizeState.pointSize = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public LegacyPointNode() {
            this.Color = new vec3(1, 1, 1);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();
        private PointSizeSwitch pointSizeState = new PointSizeSwitch(5.0f);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg) {
            var gl = GL.Current; if (gl == null) return;

            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            this.polygonOffsetState.On();
            this.pointSizeState.On();

            gl.glBegin((uint)DrawMode.Points);
            gl.glColor3f(this.Color.x, this.Color.y, this.Color.z);
            gl.glVertex3f(this.Vertex.x, this.Vertex.y, this.Vertex.z);
            gl.glEnd();

            this.pointSizeState.Off();
            this.polygonOffsetState.Off();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
