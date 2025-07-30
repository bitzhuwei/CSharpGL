using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class LegacyTriangleNode : SceneNodeBase, IRenderable {
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
        public PolygonMode PolygonMode {
            get { return this.polygonModeState.mode; }
            set { this.polygonModeState.mode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LineWidth {
            get { return this.lineWidthState.lineWidth; }
            set { this.lineWidthState.lineWidth = value; }
        }

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
        public LegacyTriangleNode() {
            this.Color0 = new vec3(1, 1, 1);
            this.Color1 = new vec3(1, 1, 1);
            this.Color2 = new vec3(1, 1, 1);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();
        private PolygonModeSwitch polygonModeState = new PolygonModeSwitch(PolygonMode.Line);
        private LineWidthSwitch lineWidthState = new LineWidthSwitch(5.0f);
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
            this.polygonModeState.On();
            this.lineWidthState.On();
            this.pointSizeState.On();

            gl.glBegin((uint)DrawMode.Triangles);
            gl.glColor3f(this.Color0.x, this.Color0.y, this.Color0.z);
            gl.glVertex3f(this.Vertex0.x, this.Vertex0.y, this.Vertex0.z);
            gl.glColor3f(this.Color1.x, this.Color1.y, this.Color1.z);
            gl.glVertex3f(this.Vertex1.x, this.Vertex1.y, this.Vertex1.z);
            gl.glColor3f(this.Color2.x, this.Color2.y, this.Color2.z);
            gl.glVertex3f(this.Vertex2.x, this.Vertex2.y, this.Vertex2.z);
            gl.glEnd();

            this.pointSizeState.Off();
            this.lineWidthState.Off();
            this.polygonModeState.Off();
            this.polygonOffsetState.Off();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
