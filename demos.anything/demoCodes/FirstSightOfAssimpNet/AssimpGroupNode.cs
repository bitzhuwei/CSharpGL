using CSharpGL;

namespace FirstSightOfAssimpNet {
    class AssimpGroupNode : GroupNode, IRenderable {
        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch();
        public PolygonMode PolygonMode {
            get { return this.polygonModeSwitch.mode; }
            set { this.polygonModeSwitch.mode = value; }
        }

        private PointSizeSwitch pointSizeSwitch = new PointSizeSwitch(5);
        public float PointSize {
            get { return this.pointSizeSwitch.pointSize; }
            set { this.pointSizeSwitch.pointSize = value; }
        }

        private LineWidthSwitch lineWdithSwitch = new LineWidthSwitch(5);
        public float LineWidth {
            get { return this.lineWdithSwitch.lineWidth; }
            set { this.lineWdithSwitch.lineWidth = value; }
        }

        public AssimpGroupNode(params SceneNodeBase[] nodes)
            : base(nodes) {
        }

        #region IRenderable 成员

        public ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            this.polygonModeSwitch.On();
            this.pointSizeSwitch.On();
            this.lineWdithSwitch.On();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            this.lineWdithSwitch.Off();
            this.pointSizeSwitch.Off();
            this.polygonModeSwitch.Off();
        }

        #endregion
    }

}
