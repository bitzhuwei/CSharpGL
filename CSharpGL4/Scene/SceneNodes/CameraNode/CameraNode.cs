using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class CameraNode : SceneNodeBase, IRenderable
    {
        private ICamera camera;

        public CameraNode(ICamera camera)
        {
            this.camera = camera;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        /// <summary>
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // update camera's position.
            var position = new vec4(this.WorldPosition, 1.0f);
            var cascadePosition = this.cascadeModelMatrix * position;
            cascadePosition = cascadePosition / cascadePosition.w;
            this.camera.Position = new vec3(cascadePosition);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
