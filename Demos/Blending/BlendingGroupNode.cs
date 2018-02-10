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
    class BlendingGroupNode : SceneNodeBase, IRenderable
    {
        private BlendFuncSwitch blending;
        private DepthMaskSwitch depthMask = new DepthMaskSwitch(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public BlendingGroupNode(BlendSrcFactor source, BlendDestFactor dest)
        {
            this.blending = new BlendFuncSwitch(source, dest);
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
