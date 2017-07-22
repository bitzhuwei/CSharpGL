using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blending
{
    /// <summary>
    /// 
    /// </summary>
    class BlendingGroupRenderer : SceneNodeBase, IRenderable
    {
        private BlendState blending;
        private DepthMaskState depthMask = new DepthMaskState(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public BlendingGroupRenderer(BlendingSourceFactor source, BlendingDestinationFactor dest)
        {
            this.blending = new BlendState(source, dest);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;

        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.depthMask.On();
            this.blending.On();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            this.blending.Off();
            this.depthMask.Off();
        }

        #endregion
    }
}
