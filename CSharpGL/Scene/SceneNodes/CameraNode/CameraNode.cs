using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraNode : SceneNodeBase, IRenderable
    {
        private ICamera camera;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        public CameraNode(ICamera camera)
        {
            this.camera = camera;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        /// <summary>
        /// 
        /// </summary>
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
            this.camera.Position = this.GetAbsoluteWorldPosition();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
