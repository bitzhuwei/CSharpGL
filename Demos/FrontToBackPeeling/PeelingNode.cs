using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {
        private int width;
        private int height;

        public PeelingNode()
        {
            this.query = new Query();

        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            throw new NotImplementedException();
        }

        private void Resize(int width, int height)
        {
            if (this.resources != null) { this.resources.Dispose(); }
            this.resources = new PeelingResource(width, height);
        }

        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode)
        {

        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
